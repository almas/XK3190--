
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HxUtility
{
    /// <summary>
    /// 定义Web请求响应对象
    /// </summary>
    public class WebApiResponse
    {
        /// <summary>
        /// 获取或设置请求方法
        /// </summary>
        public RequestMethod Method { get; set; }

        /// <summary>
        /// 获取或设置请求URL地址
        /// </summary>
        public Uri Url { get; set; }

        /// <summary>
        /// 获取或设置请求状态码
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// 获取或设置Web请求异常
        /// </summary>
        public WebExceptionStatus ExceptionStatus { get; set; }

        /// <summary>        
        /// 获取或设置请求返回对象
        /// </summary>
        public object Content { get; set; }

        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName { get; set; }
        //public string Content { get; set; }
        /// <summary>
        /// 获取或设置请求错误消息
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// 获取或设置请求时间
        /// </summary>
        public DateTime RequestTime { get; set; }

        /// <summary>
        /// 获取或设置请求响应时间
        /// </summary>
        public DateTime ResponseTime { get; set; }

        /// <summary>
        /// 获取或设置请求总用时
        /// </summary>
        public TimeSpan ElapseTime { get; set; }
    }
}
