using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using UploadTraceData.Common;
using UploadTraceData.DbContext;
using UploadTraceData.Dto;
using UploadTraceData.Models;
using Newtonsoft.Json;
using RestSharp;
using SqlSugar;


namespace UploadTraceData.AppService
{
    public class UploadAppService
    {
        //private string serverIp = ConfigurationManager.AppSettings["serverIp"];
        public RestClient _apiClient = new RestClient();
        private string baseUrl = "";
        public int UploadPerSize = 100;
        public int maxReqSize = 2;
        public UploadAppService()
        {
            //baseUrl =serverIp;
            //_apiClient.BaseUrl=new Uri(baseUrl);
        }
        public UploadAppService(string url)
        {
            //if (string.IsNullOrEmpty(url))
            //{
            //    url = serverIp;
            //}
            baseUrl = url;
            _apiClient.BaseUrl = new Uri(baseUrl);
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
                var request = new RestRequest("/Api/XmSlaughterUpload/UploadBatchs", Method.POST);
                using (var db = SugarDao.GetInstance())
                {
                    do
                    {
                        //本次请求超过最大请求次数停止请求
                        if (reqTime >= maxReqSize)
                        {
                            break;
                        }
                        request.Parameters.Clear();
                        var batchs = db.Queryable<Batches>().Where(s => s.upload == false&&s.flag==true).OrderBy(s => s.yearNum).Take(UploadPerSize).ToList();
                        if (batchs.Any())
                        {
                            if (batchs.Count < UploadPerSize)
                            {
                                flag = false;
                            }

                            var dataStr = JsonConvert.SerializeObject(batchs);
                            request.AddParameter("batchs", dataStr);
                            var response = _apiClient.Execute<RestApiResultDto>(request);
                            if (response.StatusCode == HttpStatusCode.OK)
                            {
                                if (response.Data.Status)
                                {
                                    var ids = batchs.Select(s => s.batchId).Distinct().ToArray();
                                    db.Update<Batches>(new { upload = true }, s => ids.Contains(s.batchId));
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
                LogNHelper.Exception(ex);
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
                var request = new RestRequest("/Api/XmSlaughterUpload/UploadHeadsoff", Method.POST);
                using (var db = SugarDao.GetInstance())
                {
                    do
                    {
                        //本次请求超过最大请求次数停止请求
                        if (reqTime >= maxReqSize)
                        {
                            break;
                        }
                        request.Parameters.Clear();
                        var headsOff = db.Queryable<Headsoff>().Where(s => s.uploaded == false).OrderBy(s => s.attachTime).Take(UploadPerSize).ToList();
                        if (headsOff.Any())
                        {
                            if (headsOff.Count < UploadPerSize)
                            {
                                flag = false;
                            }

                            var dataStr = JsonConvert.SerializeObject(headsOff);
                            request.AddParameter("headsoff", dataStr);
                            var response = _apiClient.Execute<RestApiResultDto>(request);
                            if (response.StatusCode == HttpStatusCode.OK)
                            {
                                if (response.Data.Status)
                                {
                                    var ids = headsOff.Select(s => s.animalId).Distinct().ToArray();
                                    db.Update<Headsoff>(new { uploaded = true }, s => ids.Contains(s.animalId));
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
                LogNHelper.Exception(ex);
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
                var request = new RestRequest("/Api/XmSlaughterUpload/UploadWeighings", Method.POST);
                using (var db = SugarDao.GetInstance())
                {
                    do
                    {
                        //本次请求超过最大请求次数停止请求
                        if (reqTime >= maxReqSize)
                        {
                            break;
                        }
                        request.Parameters.Clear();
                        var weightings = db.Queryable<Weighings>().Where(s => s.uploaded == false).OrderBy(s => s.weighingTime).Take(UploadPerSize).ToList();
                        if (weightings.Any())
                        {
                            if (weightings.Count < UploadPerSize)
                            {
                                flag = false;
                            }

                            var dataStr = JsonConvert.SerializeObject(weightings);
                            request.AddParameter("weightings", dataStr);
                            var response = _apiClient.Execute<RestApiResultDto>(request);
                            if (response.StatusCode == HttpStatusCode.OK)
                            {
                                if (response.Data.Status)
                                {
                                    string sql = "";
                                    foreach (var item in weightings)
                                    {
                                        var atime = item.attachTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
                                        sql += "update Weighings set uploaded=1 where hookId='" + item.hookId + "' and attachTime='" + atime + "';";
                                    }

                                    if (!string.IsNullOrEmpty(sql))
                                    {
                                        db.ExecuteCommand(sql);
                                    }
                                    //weightings.ForEach(s => s.uploaded = true);
                                    //db.UpdateRange(weightings);
                                    // var ids = weightings.Select(s => s.batchId).Distinct().ToArray();
                                    // db.Update<Weighings>(new { uploaded = true }, s => ids.Contains(s.batchId));
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
                LogNHelper.Exception(ex);
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
                var request = new RestRequest("/Api/XmSlaughterUpload/UploadPreDeAcid", Method.POST);
                using (var db = SugarDao.GetInstance())
                {
                    do
                    {
                        //本次请求超过最大请求次数停止请求
                        if (reqTime >= maxReqSize)
                        {
                            break;
                        }

                        request.Parameters.Clear();
                        var preDeAcid = db.Queryable<PreDeAcid>().Where(s => s.uploaded == false).OrderBy(s => s.weighingTime).Take(UploadPerSize).ToList();
                        if (preDeAcid.Any())
                        {
                            if (preDeAcid.Count < UploadPerSize)
                            {
                                flag = false;
                            }

                            var dataStr = JsonConvert.SerializeObject(preDeAcid);
                            request.AddParameter("preDeAcid", dataStr);
                            var response = _apiClient.Execute<RestApiResultDto>(request);
                            if (response.StatusCode == HttpStatusCode.OK)
                            {
                                if (response.Data.Status)
                                {
                                    //preDeAcid.ForEach(s => s.uploaded = true);

                                    //db.UpdateRange(preDeAcid);
                                    string sql = "";
                                    foreach (var item in preDeAcid)
                                    {
                                        var atime = item.attachTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
                                        sql += "update PreDeAcid set uploaded=1 where hookId='" + item.hookId + "' and attachTime='" + atime + "';";
                                    }

                                    if (!string.IsNullOrEmpty(sql))
                                    {
                                        db.ExecuteCommand(sql);
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
                LogNHelper.Exception(ex);
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
                var request = new RestRequest("/Api/XmSlaughterUpload/UploadPostDeAcid", Method.POST);
                using (var db = SugarDao.GetInstance())
                {
                    do
                    {
                        //本次请求超过最大请求次数停止请求
                        if (reqTime >= maxReqSize)
                        {
                            break;
                        }
                        request.Parameters.Clear();
                        var postDeAcid = db.Queryable<PostDeAcid>().Where(s => s.uploaded == false).OrderBy(s => s.attachTime).Take(UploadPerSize).ToList();
                        if (postDeAcid.Any())
                        {
                            if (postDeAcid.Count < UploadPerSize)
                            {
                                flag = false;
                            }

                            var dataStr = JsonConvert.SerializeObject(postDeAcid);
                            request.AddParameter("postDeAcid", dataStr);
                            var response = _apiClient.Execute<RestApiResultDto>(request);
                            if (response.StatusCode == HttpStatusCode.OK)
                            {
                                if (response.Data.Status)
                                {
                                    string sql = "";
                                    foreach (var item in postDeAcid)
                                    {
                                        var atime = item.attachTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
                                        sql += "update PostDeAcid set uploaded=1 where hookId='" + item.hookId + "' and attachTime='" + atime + "';";
                                    }

                                    if (!string.IsNullOrEmpty(sql))
                                    {
                                        db.ExecuteCommand(sql);
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
                LogNHelper.Exception(ex);
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
                var request = new RestRequest("/Api/XmSlaughterUpload/UploadCuttings", Method.POST);
                using (var db = SugarDao.GetInstance())
                {
                    do
                    {
                        //本次请求超过最大请求次数停止请求
                        if (reqTime >= maxReqSize)
                        {
                            break;
                        }
                        request.Parameters.Clear();
                        var cuttings = db.Queryable<Cuttings>().Where(s => s.uploaded == false).OrderBy(s => s.producingTime).Take(UploadPerSize).ToList();
                        if (cuttings.Any())
                        {
                            if (cuttings.Count < UploadPerSize)
                            {
                                flag = false;
                            }

                            var dataStr = JsonConvert.SerializeObject(cuttings);
                            request.AddParameter("cuttings", dataStr);
                            var response = _apiClient.Execute<RestApiResultDto>(request);
                            if (response.StatusCode == HttpStatusCode.OK)
                            {
                                if (response.Data.Status)
                                {
                                    var traceIds = cuttings.Select(s => s.traceId).ToArray();

                                    db.Update<Cuttings>(new { uploaded = true }, s => traceIds.Contains(s.traceId));
                                    //cuttings.ForEach(s => s.uploaded = true);
                                    //db.UpdateRange(cuttings);

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
                LogNHelper.Exception(ex);
            }
        }
    }
}