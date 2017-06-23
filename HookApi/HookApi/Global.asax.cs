using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Timers;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using HookApi.AppService;
using HookApi.Common;
using HookApi.DbContext;
using HookApi.Models;
using SqlSugar;

namespace HookApi
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

          //  WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);


            ////定义定时器  
            //int tasktime = 2*60*60*1000;
            ////int tasktime = 60 * 1000;
            //System.Timers.Timer myTimer = new System.Timers.Timer(tasktime);

            //myTimer.Elapsed += new ElapsedEventHandler(myTimer_Elapsed);

            //myTimer.Enabled = true;

            //myTimer.AutoReset = true;
        }

        void myTimer_Elapsed(object source, ElapsedEventArgs e)
        {

            try
            {
                
                //var uploadApp = new UploadAppService(url);

                //uploadApp.UploadBatchs();
                //uploadApp.UploadHeadsoff();

                var dtNow = DateTime.Now;
                //if (dtNow.Hour == 12 || dtNow.Hour ==17)
                if (dtNow.Hour >3 &&dtNow.Hour<=20)
                {
                    LogNHelper.Info("上传开始时间:"+dtNow);

                    string url = string.Empty;
                    using (var db = SugarDao.GetInstance())
                    {
                        url = db.Queryable<Params>()
                                .Where(s => s.factoryId == "1001")
                                .Select(s => s.serverUrl)
                                .SingleOrDefault();
                    }

                    //string url = ConfigurationManager.AppSettings["serverIp"];
                    //LogNHelper.Info("现在url:" + url);
                    var uploadApp = new UploadAppService(url);

                    uploadApp.UploadBatchs();
                    uploadApp.UploadHeadsoff();
                    uploadApp.UploadPostDeAcid();
                    uploadApp.UploadPreDeAcid();
                    uploadApp.UploadWeighings();
                    uploadApp.UploadCuttings();
                    LogNHelper.Info("上传完成时间:" + dtNow);
                }

            }

            catch (Exception ex)
            {

                LogNHelper.Exception(ex);

            }

        }
        protected void Application_End(object sender, EventArgs e)
        {

            LogNHelper.Debug("进入iis回收");
            //下面的代码是关键，可解决IIS应用程序池自动回收的问题  
            //Thread.Sleep(1000);
            //这里设置你的web地址，可以随便指向你的任意一个aspx页面甚至不存在的页面，目的是要激发Application_Start  
            //string url = ConfigurationManager.AppSettings["initWebUrl"];
            //try
            //{
            //    HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            //    HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
            //    Stream receiveStream = myHttpWebResponse.GetResponseStream();//得到回写的字节流  
            //    if (receiveStream != null)
            //    {
            //        receiveStream.Close();
            //    }
            //}
            //catch (Exception ex)
            //{
            //   LogNHelper.Exception(ex);
            //}
        }

    }
}