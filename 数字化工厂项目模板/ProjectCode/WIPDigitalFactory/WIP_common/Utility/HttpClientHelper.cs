using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
namespace WIP_common
{
    /// <summary>
    /// HttpClientHelper
    /// </summary>
    public static class HttpClientHelper
    {
        private static readonly object LockObj = new object();

        private static HttpClient _client;

        public static HttpClient HttpClient
        {
            get
            {
                if (_client == null)
                {
                    lock (LockObj)
                    {
                        if (_client == null)
                        {
                            _client = new HttpClient();
                            _client.DefaultRequestHeaders.Accept.Clear();
                            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                            _client.Timeout = new TimeSpan(0, 0, 30);//默认30秒超时
                        }
                    }
                }

                return _client;
            }
        }
    }
}
