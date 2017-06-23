using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HookApi.AppService;
using HookApi.Common;
using HookApi.DbContext;
using HookApi.Models;
using SqlSugar;
using RestSharp;
using System.Net;
using System.Configuration;

namespace HookApi.Controllers
{
    public class HookApiController : Controller
    {
        //
        // GET: /HookApi/
        public string BatchCacheKey = "batchCache";
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult PostHookData(string animalId,string attachTime)
        {
            var flag = false;
            try
            {
                if (string.IsNullOrEmpty(animalId))
                {
                    return Json(new { Status = flag, Data = "" });
                }

                var model = new Headsoff();
                if (!string.IsNullOrEmpty(attachTime))
                {
                    model.attachTime = UnixTimSpanHelper.GetTime(attachTime);

                }
                else
                {
                    model.attachTime = DateTime.Now;
                }
                var currentBatch = GetCurrentBatchNumCache();
                model.yearNum = currentBatch.yearNum;
                model.sort = currentBatch.sort;
                //0开始重新生成批次号
                if (animalId == "0")
                {

                    model.sort = currentBatch.sort + 1;
                    //GetNewBatchNumCache();
                    animalId = model.attachTime.ToString("yyyyMMddHHmmss")+"-"+animalId;
                }

                //var batchModel = GetBatchNumCache();
               
                //if (batchModel != null)
                //{
                //    model.yearNum = batchModel.yearNum;
                //    model.sort = batchModel.sort;
                //}
                //1结束 清空批次号
                if (animalId == "1")
                {
                   // CacheHelper.RemoveCache(BatchCacheKey);
                    animalId = model.attachTime.ToString("yyyyMMddHHmmss") + "-" + animalId;
                    model.sort = currentBatch.sort;
                }

                
                model.animalId = animalId.Trim();
               
                model.flag = false;
                model.uploaded = false;
                using (var db = SugarDao.GetInstance())
                {
                    if (animalId.Length > 2)
                    {
                        var isexist = db.Queryable<Headsoff>().Where(s => s.animalId == animalId).Count();
                        if (isexist == 0)
                        {
                            db.Insert(model);
                        }
                    }
                    else
                    {
                        db.Insert(model);
                    }
                    


                }
                flag = true;
            }
            catch (Exception ex)
            {
              LogNHelper.Exception(ex);
            }

            return Json(new { Status = flag, Data = "" });
        }

        /// <summary>
        /// 验证服务器时间
        /// </summary>
        /// <returns></returns>
        public JsonResult ValidateServerTime()
        {
          //  var dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff");

            var dt = DateTime.Now;
            var unixTspan = UnixTimSpanHelper.ConvertDateTimeToTimeSpan(dt);
            return Json(new { Status = true, Data = unixTspan }, JsonRequestBehavior.AllowGet);
        }


        private BatchModel GetCurrentBatchNumCache()
        {
            var batchModel = new BatchModel();
            using (var db = SugarDao.GetInstance())
            {
                var batckId = DateTime.Now.ToString("yyyyMMdd");
                int yearNum = int.Parse(batckId);
                var isexist = db.Queryable<Headsoff>().Where(s => s.yearNum == yearNum)
                    .OrderBy(s => s.sort, OrderByType.Desc).Select(s => s.sort).FirstOrDefault();

                batchModel = new BatchModel();
                batchModel.yearNum = yearNum;
                batchModel.sort = isexist;


            }

            return batchModel;
            //CacheHelper.WriteCache<BatchModel>(batchModel, BatchCacheKey);

            //return batchModel;
        }
        private void GetNewBatchNumCache()
        {
             var batchModel=new BatchModel();
            using (var db = SugarDao.GetInstance())
            {
                var batckId = DateTime.Now.ToString("yyyyMMdd");
                int yearNum = int.Parse(batckId);
                var isexist = db.Queryable<Headsoff>().Where(s => s.yearNum == yearNum)
                    .OrderBy(s => s.sort, OrderByType.Desc).Select(s => s.sort).FirstOrDefault();

                    batchModel = new BatchModel();
                    batchModel.yearNum = yearNum;
                    batchModel.sort = isexist+1;
                

            }
            CacheHelper.WriteCache<BatchModel>(batchModel, BatchCacheKey);

            //return batchModel;
        }
        private BatchModel GetBatchNumCache()
        {
            var batchModel = CacheHelper.GetCache<BatchModel>(BatchCacheKey);
            if (batchModel == null)
            {
                var batckId = DateTime.Now.ToString("yyyyMMdd");
                int yearNum = int.Parse(batckId);

                var querysql = @"select top 1 sort from Batches where yearNum=@yearNum order by sort desc";
                using (var db = SugarDao.GetInstance())
                {

                    var isexist = db.Queryable<Headsoff>().Where(s => s.yearNum == yearNum)
                        .OrderBy(s=>s.sort,OrderByType.Desc).Select(s=>s.sort).FirstOrDefault();
                    if (isexist == 0)
                    {
                        batchModel = new BatchModel();
                        batchModel.yearNum = yearNum;
                        batchModel.sort = 1;
                    }
                    else
                    {
                        batchModel = new BatchModel();
                        batchModel.yearNum = yearNum;
                        batchModel.sort = isexist;
                    }


                }

                CacheHelper.WriteCache<BatchModel>(batchModel, BatchCacheKey);
            }

            return batchModel;
        }

       // private void 
        public JsonResult PostTestData()
        {
            var result = new ReqTestResult();
            try
            {
                string url = string.Empty;
                try
                {
                    using (var db = SugarDao.GetInstance())
                    {
                        url = db.Queryable<Params>()
                                .Where(s => s.factoryId == "1001")
                                .Select(s => s.serverUrl)
                                .SingleOrDefault();
                    }
                }
                catch (Exception ex)
                {
                    LogNHelper.Exception(ex);
                }
                if (string.IsNullOrEmpty(url))
                {
                    url = ConfigurationManager.AppSettings["serverIp"];
                }
                RestClient _apiClient = new RestClient();
                _apiClient.BaseUrl = new Uri(url);
                var testReq = new RestRequest();
                IRestResponse response = _apiClient.Execute(testReq);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var uploadApp = new UploadAppService(url);

                    uploadApp.UploadBatchs();
                    uploadApp.UploadHeadsoff();
                    uploadApp.UploadWeighings();
                    uploadApp.UploadPreDeAcid();
                    uploadApp.UploadPostDeAcid();
                    uploadApp.UploadCuttings();

                    result.Status = true;

                }
                else
                {
                    result.Msg = "服务器连接失败";
                }

            }
            catch (Exception ex)
            {
                LogNHelper.Exception(ex);
                result.Msg = "本地上传异常";
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }

    public class BatchModel
    {
        public int yearNum { get; set; }
        public int sort { get; set; }
    }

    public class ReqTestResult
    {
        public bool Status { get; set; }
        public string Msg { get; set; }
    }
  
}
