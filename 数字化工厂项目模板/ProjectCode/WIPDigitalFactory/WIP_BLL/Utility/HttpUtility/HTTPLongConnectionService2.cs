using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WIP_BLL
{
    public class HTTPLongConnectionService2
    {
        private static readonly HttpClient _httpClient;
        private static string host_WipHost = BLLHelpler.GetConfigValue("wipHost");//wipHost
        static HTTPLongConnectionService2()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Connection.Add("keep-alive");
            _httpClient.DefaultRequestHeaders.Connection.Add("close");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Add("Authorization", "eyJhbGciOiJIUzM4NCIsInR5cCI6IkpXVCJ9.eyJpYXQiOiIxNTQ3MjYwMDk4IiwiZXhwIjoiMTYxMDMzMjA5OCIsImlzcyI6IlNBR1dXSVAiLCJzdWIiOiJlY21pbnRlZ3JhdGVkIiwidXNlcm5hbWUiOiJlY21pbnRlZ3JhdGVkIiwidXNlcmdyb3VwIjpbeyJsb2dpbm5hbWUiOiJlY21pbnRlZ3JhdGVkIiwiZ3JvdXBJZCI6IjRmNTFjOTlkLThhMjMtNDA0YS05ZTIzLWYzYWE2ZjkxYTgwZiIsImdyb3VwbmFtZSI6IkVDTWludGVncmF0ZWQiLCJyb2xlSWQiOiI2ZDJmZmYxMi0xMjlhLTQyMTctYjc0ZC1mZGU5OWUzNjI3NGQiLCJyb2xlbmFtZSI6IkVDTembhuaIkCJ9XX0.QQ0KpAs5MP2szfuFZbeiIfI8kmDg58Rs-GY6RrwWs1S7r2WmFUL-aRfMdvZvk1Ph");
            _httpClient.Timeout = new TimeSpan(0, 0, 30);
            _httpClient.BaseAddress = new Uri(host_WipHost);

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
        public async Task<string> PostAsync(string url, string parameter)
        {
            var httpContent = new StringContent(parameter, Encoding.UTF8);
            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json") { CharSet = "utf-8" };
            var response = await _httpClient.PostAsync(url, httpContent);

            return await response.Content.ReadAsStringAsync();
        }


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
                        throw new Exception("{" + host_WipHost + "}被调用的HTTP服务接口{" + url + "}内部发生异常");
                    }
                    else
                    {
                        throw new Exception("{" + host_WipHost + "}被调用的HTTP服务接口{" + url + "}内部发生异常{" + response.StatusCode + "}");
                    }
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
