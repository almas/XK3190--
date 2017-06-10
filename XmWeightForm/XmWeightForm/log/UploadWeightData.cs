using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using AppService.Model;
using Dapper_NET20;
using HookApi.Models;
using Newtonsoft.Json;
using XmWeightForm;

namespace AppService
{
    public class UploadWeightData
    {
         private string serverIp = ConfigurationManager.AppSettings["serverIp"];
         public WebApiClient _apiClient = new WebApiClient();
        private string _baseUrl = "";
        public int UploadPerSize = 100;
        public int maxReqSize = 100;
        public UploadWeightData()
        {
            _baseUrl = serverIp;
            //_apiClient.BaseUrl=new Uri(baseUrl);
        }

        public UploadWeightData(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                url = serverIp;
                log4netHelper.Info("dburl为null");
            }
            _baseUrl = url;
        }
        /// <summary>
        /// 上传批次
        /// </summary>
        public void UploadBatchs()
        {
            bool flag = true;
            int reqTime = 0;
            try
            {
                string uploadbatchUrl = _baseUrl + "/Api/XmSlaughterUpload/UploadBatchs";
                
                using (var db = DapperDao.GetInstance())
                {
                    do
                    {
                        //本次请求超过最大请求次数停止请求
                        if (reqTime >= maxReqSize)
                        {
                            break;
                        }
                        string sql = "select top " + UploadPerSize + " * from Batches where upload=0 order by yearNum";
                        var batchs = db.Query<BatchInput>(sql,null).ToList();
                        if (batchs.Any())
                        {
                            if (batchs.Count < UploadPerSize)
                            {
                                flag = false;
                            }

                            //var dataStr = JsonConvert.SerializeObject(dataObj);
                            var response = _apiClient.RequestUploadUrl(uploadbatchUrl, RequestMethod.POST, "batchs", batchs);
                            if (response.StatusCode == HttpStatusCode.OK)
                            {
                                var respResult =
                                    JsonConvert.DeserializeObject<RestApiResultDto>(response.Content.ToString());
                                if (respResult.Status)
                                {
                                    var ids = batchs.Select(s => s.batchId).Distinct().ToArray();
                                    db.Execute("update Batches set upload=1 where batchId in @ids", new {ids = ids});
                                }
                            }
                            reqTime++;
                        }
                        else
                        {
                            flag = false;
                        }
                    } while (flag);
                   
                }
            }
            catch (Exception ex)
            {
                log4netHelper.Exception(ex);
            }
          
        }

        /// <summary>
        /// 上传去头数据
        /// </summary>
        public void UploadHeadsoff()
        {

            bool flag = true;
            int reqTime = 0;
            try
            {
                string uploadheadUrl = _baseUrl + "/Api/XmSlaughterUpload/UploadHeadsoff";
                using (var db = DapperDao.GetInstance())
                {
                    do
                    {
                        //本次请求超过最大请求次数停止请求
                        if (reqTime >= maxReqSize)
                        {
                            break;
                        }
                        string sql = "select top " + UploadPerSize +" * from Headsoff where uploaded=0 order by attachTime";
                        var headsOff = db.Query<Headsoff>(sql, null).ToList();
                        if (headsOff.Any())
                        {
                            if (headsOff.Count < UploadPerSize)
                            {
                                flag = false;
                            }

                            //var dataObj = new
                            //{
                            //    headsoff = headsOff
                            //};

                            //var dataStr = JsonConvert.SerializeObject(dataObj);
                            var response = _apiClient.RequestUploadUrl(uploadheadUrl, RequestMethod.POST, "headsoff", headsOff);
                            if (response.StatusCode == HttpStatusCode.OK)
                            {
                                var respResult =
                                    JsonConvert.DeserializeObject<RestApiResultDto>(response.Content.ToString());
                                if (respResult.Status)
                                {
                                    var ids = headsOff.Select(s => s.animalId).Distinct().ToArray();
                                    db.Execute("update Headsoff set uploaded=1 where animalId in @ids", new { ids = ids });
                                }
                            }
                        

                        }
                        else
                        {
                            flag = false;
                        }

                        reqTime++;
                    } while (flag);
                  
                }
            }
            catch (Exception ex)
            {
                log4netHelper.Exception(ex);
            }
        }

        /// <summary>
        /// 称重数据
        /// </summary>
        public void UploadWeighings()
        {
            bool flag = true;
            int reqTime = 0;
            try
            {
                string upweightUrl = _baseUrl + "/Api/XmSlaughterUpload/UploadWeighings";
                using (var db = DapperDao.GetInstance())
                {
                    do
                    {
                        //本次请求超过最大请求次数停止请求
                        if (reqTime >= maxReqSize)
                        {
                            break;
                        }
                        string squeryql = "select top "+UploadPerSize+" * from Weighings where uploaded=0 order by weighingTime";
                        var weightings = db.Query<Weighings>(squeryql,null).ToList();
                        if (weightings.Any())
                        {
                            if (weightings.Count < UploadPerSize)
                            {
                                flag = false;
                            }

                            //var dataObj = new
                            //{
                            //    weightings = weightings
                            //};
                            //var dataStr = JsonConvert.SerializeObject(dataObj);

                            var response = _apiClient.RequestUploadUrl(upweightUrl, RequestMethod.POST, "weightings", weightings);
                            if (response.StatusCode == HttpStatusCode.OK)
                            {
                               var respResult =JsonConvert.DeserializeObject<RestApiResultDto>(response.Content.ToString());
                                if (respResult.Status)
                                {
                                    string sql = "";
                                    foreach (var item in weightings)
                                    {
                                        var atime = item.attachTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
                                        sql += "update Weighings set uploaded=1 where hookId='" + item.hookId + "' and attachTime='" + atime + "';";
                                    }

                                    if (!string.IsNullOrEmpty(sql))
                                    {
                                        db.Execute(sql,null);
                                    }

                                }
                            }
                        }
                        else
                        {
                            flag = false;
                        }

                        reqTime++;
                    } while (flag);
                   
                }
            }
            catch (Exception ex)
            {
                log4netHelper.Exception(ex);
            }
        }
        /// <summary>
        /// 排酸前
        /// </summary>
        public void UploadPreDeAcid()
        {
            bool flag = true;
            int reqTime = 0;
            try
            {
                string uppreacidUrl = _baseUrl + "/Api/XmSlaughterUpload/UploadPreDeAcid";
                using (var db = DapperDao.GetInstance())
                {
                    do
                    {
                        //本次请求超过最大请求次数停止请求
                        if (reqTime >= maxReqSize)
                        {
                            break;
                        }

                        string querysql = "select top " + UploadPerSize +
                                          " * from PreDeAcid where uploaded=0 order by weighingTime";
                        var preDeAcid = db.Query<PreDeAcid>(querysql,null).ToList();
                        if (preDeAcid.Any())
                        {
                            if (preDeAcid.Count < UploadPerSize)
                            {
                                flag = false;
                            }

                            //var dataObj = new
                            //{
                            //    preDeAcid = preDeAcid
                            //};
                            //var dataStr = JsonConvert.SerializeObject(dataObj);

                            var response = _apiClient.RequestUploadUrl(uppreacidUrl,RequestMethod.POST, "preDeAcid", preDeAcid);
                            if (response.StatusCode == HttpStatusCode.OK)
                            {
                                var respResult = JsonConvert.DeserializeObject<RestApiResultDto>(response.Content.ToString());
                                if (respResult.Status)
                                {
                                    string sql = "";
                                    foreach (var item in preDeAcid)
                                    {
                                        var atime = item.attachTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
                                        sql += "update PreDeAcid set uploaded=1 where hookId='" + item.hookId + "' and attachTime='" + atime + "';";
                                    }

                                    if (!string.IsNullOrEmpty(sql))
                                    {
                                        db.Execute(sql,null);
                                    }
                                }
                            }
                        }
                        else
                        {
                            flag = false;
                        }

                        reqTime++;
                    } while (flag);

                }
            }
            catch (Exception ex)
            {
                log4netHelper.Exception(ex);
            }
        }

        /// <summary>
        /// 排酸后
        /// </summary>
        public void UploadPostDeAcid()
        {
            bool flag = true;
            int reqTime = 0;
            try
            {
                string uppostAcidUrl = _baseUrl + "/Api/XmSlaughterUpload/UploadPostDeAcid";
               
                using (var db = DapperDao.GetInstance())
                {
                    do
                    {
                        //本次请求超过最大请求次数停止请求
                        if (reqTime >= maxReqSize)
                        {
                            break;
                        }
                        string querysql = "select top "+UploadPerSize+" * from PostDeAcid where uploaded=0 order by attachTime";
                        var postDeAcid = db.Query<PostDeAcid>(querysql,null).ToList();
                        if (postDeAcid.Any())
                        {
                            if (postDeAcid.Count < UploadPerSize)
                            {
                                flag = false;
                            }

                            //var dataObj = new
                            //{
                            //    postDeAcid = postDeAcid
                            //};
                            //var dataStr = JsonConvert.SerializeObject(dataObj);

                            var response = _apiClient.RequestUploadUrl(uppostAcidUrl, RequestMethod.POST, "postDeAcid", postDeAcid);
                       
                            if (response.StatusCode == HttpStatusCode.OK)
                            {
                                var respResult = JsonConvert.DeserializeObject<RestApiResultDto>(response.Content.ToString());
                                if (respResult.Status)
                                {
                                    string sql = "";
                                    foreach (var item in postDeAcid)
                                    {
                                        var atime = item.attachTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
                                        sql += "update PostDeAcid set uploaded=1 where hookId='" + item.hookId + "' and attachTime='" + atime + "';";
                                    }

                                    if (!string.IsNullOrEmpty(sql))
                                    {
                                        db.Execute(sql,null);
                                    }
                                    //postDeAcid.ForEach(s => s.uploaded = true);
                                    //db.UpdateRange(postDeAcid);

                                }
                            }
                        }
                        else
                        {
                            flag = false;
                        }

                        reqTime++;
                    } while (flag);
                }
            }
            catch (Exception ex)
            {
                log4netHelper.Exception(ex);
            }
        }

      
        /// <summary>
        /// 产品线
        /// </summary>
        public void UploadCuttings()
        {
            bool flag = true;
            int reqTime = 0;
            try
            {
                string upCuttingUrl = _baseUrl + "/Api/XmSlaughterUpload/UploadCuttings";
              
                using (var db = DapperDao.GetInstance())
                {
                    do
                    {
                        //本次请求超过最大请求次数停止请求
                        if (reqTime >= maxReqSize)
                        {
                            break;
                        }

                        string querysql = "select top "+UploadPerSize+" * from Cuttings where uploaded=0 order by producingTime";
                        var cuttings = db.Query<Cuttings>(querysql,null).ToList();
                        if (cuttings.Any())
                        {
                            if (cuttings.Count < UploadPerSize)
                            {
                                flag = false;
                            }
                            //var dataObj = new
                            //{
                            //    cuttings = cuttings
                            //};
                            //var dataStr = JsonConvert.SerializeObject(dataObj);
                            //request.AddParameter("cuttings", dataStr);
                            var response = _apiClient.RequestUploadUrl(upCuttingUrl, RequestMethod.POST, "cuttings", cuttings);
                            if (response.StatusCode == HttpStatusCode.OK)
                            {
                                var respResult = JsonConvert.DeserializeObject<RestApiResultDto>(response.Content.ToString());
                                if (respResult.Status)
                                {
                                    var traceIds = cuttings.Select(s => s.traceId).ToArray();

                                    db.Execute("update Cuttings set uploaded=1 where traceId in @ids", new { ids = traceIds });
                                }
                            }
                        }
                        else
                        {
                            flag = false;
                        }
                        reqTime++;
                    } while (flag);

                }
            }
            catch (Exception ex)
            {
                log4netHelper.Exception(ex);
            }
        }
    }
    public class RestApiResultDto
    {
        public bool Status { get; set; }
    }
}
