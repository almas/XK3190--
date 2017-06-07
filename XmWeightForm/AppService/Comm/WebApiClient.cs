

using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Configuration;
using System.Diagnostics;

namespace AppService
{
    /// <summary>
    /// 定义网络资源谓词
    /// </summary>
    public enum RequestMethod
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    /// <summary>
    /// 封装WebClient对象的调用，支持GET、POST、PUT、DELETE等动词的访问方式，
    /// 简化对API接口以网络方式访问
    /// </summary>    
    public sealed class WebApiClient
    {
        /// <summary>
        /// 请求指定资源地址的数据
        /// </summary>
        /// <param name="uri">资源访问地址（不包含BaseAddress）</param>
        /// <param name="method">访问方法，允许值包括GET、POST、PUT、DELETE</param>
        /// <param name="data">需要传输给资源服务的数据</param>
        /// <param name="encoding">数据传输编码方式</param>
        /// <returns>返回响应结果对象</returns>
        /// <exception cref="ArgumentNullException">非空参数为NULL</exception>
        /// <exception cref="ArgumentException">给定参数不合法</exception>   
        /// <exception cref="ApplicationException">无效的URL地址</exception>
        public WebApiResponse Request(string uri, RequestMethod method, object data = null, string contentType = null, Encoding encoding = null)
        {
            if (string.IsNullOrEmpty(uri))
                throw new ArgumentNullException("uri");

            Uri url = new Uri(uri);
            WebApiResponse response = new WebApiResponse();
            response.Method = method;
            response.Url = url;
            response.RequestTime = DateTime.Now;

            Stopwatch watch = null;

            try
            {
                WebRequest request = WebRequest.Create(url);
                HttpWebRequest httpRequest = request as HttpWebRequest;
                if (httpRequest == null)
                    throw new ApplicationException(String.Format("Invalid url string: {0}", url));

                // 设置请求相关参数
                httpRequest.ContentType =contentType ?? "application/json";
                httpRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/34.0.1847.116 Safari/537.36";
                httpRequest.Method = method.ToString();

                if (data != null)
                {
                    // 如果data不为空需要转换为JSON字符串，并以二进制传输
                    Encoding encoder = (encoding == null ? Encoding.UTF8 : encoding);
                    string body = JsonConvert.SerializeObject(data);
                    byte[] bodyBytes = encoder.GetBytes(body);

                    // 将请求数据设置到请求对象中
                    httpRequest.ContentLength = bodyBytes.Length;
                    using (Stream requestStream = httpRequest.GetRequestStream())
                        requestStream.Write(bodyBytes, 0, bodyBytes.Length);
                }

                watch = Stopwatch.StartNew();

                using (HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse())
                {
                    watch.Stop();

                    Stream responseStream = httpResponse.GetResponseStream();
                    using (StreamReader reader = new StreamReader(responseStream))
                        response.Content = reader.ReadToEnd();

                    response.StatusCode = httpResponse.StatusCode;
                }
            }
            catch (WebException ex)
            {
                response.ExceptionStatus = ex.Status;
                response.ErrorMessage = ex.Message;
                if (ex.Response != null)
                    response.StatusCode = ((HttpWebResponse)ex.Response).StatusCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            response.ResponseTime = DateTime.Now;
            response.ElapseTime = watch.Elapsed;
            return response;
        }

        public WebApiResponse RequestUploadUrl(string url, RequestMethod method, string key, object data)
        {
            WebApiResponse response = new WebApiResponse();
            try
            {
                if (data == null)
                {
                    return response;
                }
                WebRequest request = WebRequest.Create(url);
                HttpWebRequest httpRequest = request as HttpWebRequest;
                if (httpRequest == null)
                    throw new ApplicationException(String.Format("Invalid url string: {0}", url));

                // 设置请求相关参数
               // httpRequest.ContentType = contentType ?? "application/json";
                httpRequest.ContentType = "application/x-www-form-urlencoded";
                httpRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/34.0.1847.116 Safari/537.36";
                httpRequest.Method =method.ToString();

                    // 如果data不为空需要转换为JSON字符串，并以二进制传输
                    Encoding encoder =Encoding.UTF8;
                    string body = JsonConvert.SerializeObject(data);
                    byte[] bodyBytes = encoder.GetBytes( key + "=" + body);

                    // 将请求数据设置到请求对象中
                    httpRequest.ContentLength = bodyBytes.Length;
                    using (Stream requestStream = httpRequest.GetRequestStream())
                        requestStream.Write(bodyBytes, 0, bodyBytes.Length);
                
                using (HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse())
                {

                    Stream responseStream = httpResponse.GetResponseStream();
                    using (StreamReader reader = new StreamReader(responseStream))
                        response.Content = reader.ReadToEnd();

                    response.StatusCode = httpResponse.StatusCode;
                }
            }
            catch (WebException ex)
            {

                if (ex.Response != null)
                    response.StatusCode = ((HttpWebResponse)ex.Response).StatusCode;
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
            }

            return response;
        }
        /// <summary>
        /// 请求指定资源地址的数据
        /// </summary>
        /// <param name="uri">资源访问地址（不包含BaseAddress）</param>
        /// <param name="method">访问方法，允许值包括GET、POST、PUT、DELETE</param>
        /// <param name="data">需要传输给资源服务的数据</param>
        /// <param name="encoding">数据传输编码方式</param>
        /// <returns>返回响应结果对象</returns>
        /// <exception cref="ArgumentNullException">非空参数为NULL</exception>
        /// <exception cref="ArgumentException">给定参数不合法</exception>   
        /// <exception cref="ApplicationException">无效的URL地址</exception>
        public WebApiResponse HxChatRequest(string uri, RequestMethod method, string token, string data = null, Encoding encoding = null)
        {
            if (string.IsNullOrEmpty(uri))
                throw new ArgumentNullException("uri");

            Uri url = new Uri(uri);
            WebApiResponse response = new WebApiResponse();
            response.Method = method;
            response.Url = url;
            response.RequestTime = DateTime.Now;

            Stopwatch watch = null;

            try
            {
                WebRequest request = WebRequest.Create(url);
                HttpWebRequest httpRequest = request as HttpWebRequest;
                if (httpRequest == null)
                    throw new ApplicationException(String.Format("Invalid url string: {0}", url));

                // 设置请求相关参数
                if (!string.IsNullOrEmpty(token) && token.Length > 1)
                {
                    httpRequest.Headers.Add("Authorization", "Bearer " + token);
                }
                httpRequest.ContentType = "application/json";
                //httpRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/34.0.1847.116 Safari/537.36";
                httpRequest.Method = method.ToString();

                if (method!= RequestMethod.GET && !string.IsNullOrEmpty(data))
                {
                    // 如果data不为空需要转换为JSON字符串，并以二进制传输
                    Encoding encoder = (encoding ?? Encoding.UTF8);
                   // string body = JsonConvert.SerializeObject(data);
                    byte[] bodyBytes = encoder.GetBytes(data);

                    // 将请求数据设置到请求对象中
                    httpRequest.ContentLength = bodyBytes.Length;
                    using (Stream requestStream = httpRequest.GetRequestStream())
                        requestStream.Write(bodyBytes, 0, bodyBytes.Length);
                }

                watch = Stopwatch.StartNew();

                using (HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse())
                {
                    watch.Stop();

                    Stream responseStream = httpResponse.GetResponseStream();
                    using (StreamReader reader = new StreamReader(responseStream))
                        response.Content = reader.ReadToEnd();

                    response.StatusCode = httpResponse.StatusCode;
                }
            }
            catch (WebException ex)
            {
                response.ExceptionStatus = ex.Status;
                response.ErrorMessage = ex.Message;
                if (ex.Response != null)
                    response.StatusCode = ((HttpWebResponse)ex.Response).StatusCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            response.ResponseTime = DateTime.Now;
            response.ElapseTime = watch.Elapsed;
            return response;
        }



        public WebApiResponse HxRequestByteArray(string uri, RequestMethod method, string contentType = null, object data = null, Encoding encoding = null)
        {
            if (string.IsNullOrEmpty(uri))
                throw new ArgumentNullException("uri");

            Uri url = new Uri(uri);
            WebApiResponse response = new WebApiResponse();
            response.Method = method;
            response.Url = url;
            response.RequestTime = DateTime.Now;

            Stopwatch watch = null;

            try
            {
                WebRequest request = WebRequest.Create(url);
                HttpWebRequest httpRequest = request as HttpWebRequest;
                if (httpRequest == null)
                    throw new ApplicationException(String.Format("Invalid url string: {0}", url));

                // 设置请求相关参数
                httpRequest.ContentType = contentType ?? "application/json";
                httpRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/34.0.1847.116 Safari/537.36";
                httpRequest.Method = method.ToString();

                if (data != null)
                {
                    // 如果data不为空需要转换为JSON字符串，并以二进制传输
                    Encoding encoder = (encoding == null ? Encoding.UTF8 : encoding);
                    string body = JsonConvert.SerializeObject(data);
                    byte[] bodyBytes = encoder.GetBytes(body);

                    // 将请求数据设置到请求对象中
                    httpRequest.ContentLength = bodyBytes.Length;
                    using (Stream requestStream = httpRequest.GetRequestStream())
                        requestStream.Write(bodyBytes, 0, bodyBytes.Length);
                }

                watch = Stopwatch.StartNew();
                using (HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse())
                {
                    watch.Stop();
                    Stream responseStream = httpResponse.GetResponseStream();
                  
                        int count = (int)httpResponse.ContentLength;
                        int offset = 0;
                        byte[] buffer = new byte[count];
                        while (count > 0)
                        {
                            int n = responseStream.Read(buffer, offset, count);
                            if (n == 0) break;
                            count -= n;
                            offset += n;
                        }
                        response.Content = buffer;
                    response.FileName = httpResponse.Headers["fileName"];
                    response.StatusCode = httpResponse.StatusCode;
                }
            }
            catch (WebException ex)
            {
                response.ExceptionStatus = ex.Status;
                response.ErrorMessage = ex.Message;
                if (ex.Response != null)
                    response.StatusCode = ((HttpWebResponse)ex.Response).StatusCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            response.ResponseTime = DateTime.Now;
            response.ElapseTime = watch.Elapsed;
            return response;
        }
    }
}
