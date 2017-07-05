using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using UploadTraceData.AppService;
using UploadTraceData.Common;
using UploadTraceData.DbContext;
using UploadTraceData.Models;
using SqlSugar;
using RestSharp;
using System.Net;
namespace UploadTraceData
{
    public partial class UploadTraceDataService : ServiceBase
    {
        public UploadTraceDataService()
        {
            InitializeComponent();
        }
        private System.Timers.Timer timer = null;
        protected override void OnStart(string[] args)
        {
            try
            {
                int taskMinute = 60;
                var taskInterval = ConfigurationManager.AppSettings["TimerInterval"];
                if (!string.IsNullOrEmpty(taskInterval))
                {
                    int.TryParse(taskInterval, out taskMinute);
                }
                timer = new System.Timers.Timer();
                timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
                //10分钟执行一次
                timer.Interval = taskMinute * 60 * 1000;
                timer.Enabled = true;
                timer.Start();
               
                LogNHelper.Info(":服务已经启动");
            }
            catch (Exception ex)
            {
                LogNHelper.Exception(ex);
            }
           

        }

        protected override void OnStop()
        {
            LogNHelper.Info(":服务已经停止");
        }

        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs args)
        {
            try
            {

                LogNHelper.Info("上传开始");

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
                //LogNHelper.Info(url);
               // string url = ConfigurationManager.AppSettings["serverIp"];
                //LogNHelper.Info("现在url:" + url);

                RestClient _apiClient = new RestClient();
                _apiClient.BaseUrl = new Uri(url);
                var testReq = new RestRequest();
                IRestResponse response = _apiClient.Execute(testReq);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var uploadApp = new UploadAppService(url);

                    uploadApp.UploadBatchs();
                    uploadApp.UploadHeadsoff();
                    uploadApp.UploadPostDeAcid();
                    uploadApp.UploadPreDeAcid();
                    uploadApp.UploadWeighings();
                    uploadApp.UploadCuttings();
                    LogNHelper.Info("上传完成");
                }
                else
                {
                    LogNHelper.Info("服务器连接失败");
                }
              
            }
            catch (Exception ex)
            {
                LogNHelper.Exception(ex);
            }
        }
    }
}
