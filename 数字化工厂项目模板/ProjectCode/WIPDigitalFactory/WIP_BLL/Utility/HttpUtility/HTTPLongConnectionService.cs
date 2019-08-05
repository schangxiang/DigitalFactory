using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WIP_BLL
{
    public class HTTPLongConnectionService
    {
        private static readonly HttpClient _httpClient;
        private static string host_MangoDB = BLLHelpler.GetConfigValue("MangoDBHost");//MangoDBHost
        static HTTPLongConnectionService()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Connection.Add("keep-alive");
            _httpClient.DefaultRequestHeaders.Connection.Add("close");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.Timeout = new TimeSpan(0, 0, 30);
            _httpClient.BaseAddress = new Uri(host_MangoDB);

            /*
            //帮HttpClient热身
            _httpClient.SendAsync(new HttpRequestMessage
            {
                Method = new HttpMethod("HEAD"),
                RequestUri = new Uri(BaseURI + url_attachProc)
            })
           .Result.EnsureSuccessStatusCode();
            //*/
        }

        /// <summary>
        /// 异步处理
        /// </summary>
        /// <param name="url"></param>
        /// <param name="parameter"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public async Task<string> postContentForString(string url, string parameter, int timeout = 30)
        {
            try
            {
                var httpContent = new StringContent(parameter, Encoding.UTF8);
                httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json") { CharSet = "utf-8" };
                using (HttpResponseMessage response = await _httpClient.PostAsync(url, httpContent))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        return result;
                    }
                    else if (response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        throw new Exception("{" + host_MangoDB + "}被调用的HTTP服务接口{" + url + "}内部发生异常");
                    }
                    else
                    {
                        throw new Exception("{" + host_MangoDB + "}被调用的HTTP服务接口{" + url + "}内部发生异常{" + response.StatusCode + "}");
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        /*
        public string postContentForString(string url, string parameter, int timeout = 30)
        {
            try
            {
                var httpContent = new StringContent(parameter, Encoding.UTF8);
                httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json") { CharSet = "utf-8" };
                using (HttpResponseMessage response = _httpClient.PostAsync(url, httpContent).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        return result;
                    }
                    else if (response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        throw new Exception("{" + host_MangoDB + "}被调用的HTTP服务接口{" + url + "}内部发生异常");
                    }
                    else
                    {
                        throw new Exception("{" + host_MangoDB + "}被调用的HTTP服务接口{" + url + "}内部发生异常{" + response.StatusCode + "}");
                    }
                }
            }
            catch
            {
                throw;
            }
        }


        //*/
    }
}
