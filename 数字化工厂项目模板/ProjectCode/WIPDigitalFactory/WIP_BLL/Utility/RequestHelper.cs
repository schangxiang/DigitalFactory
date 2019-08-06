using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SysManager.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WIP_common;
using WIP_Models;

namespace WIP_BLL
{
    public class RequestHelper
    {
        /// <summary>
        /// 公共处理post请求
        /// </summary>
        /// <typeparam name="T">请求参数对象</typeparam>
        /// <typeparam name="T1">返回的data对象</typeparam>
        /// <param name="host">主机名</param>
        /// <param name="url">请求地址</param>
        /// <param name="param">请求参数对象</param>
        ///  <param name="timeout">超时时间，单位：秒，默认为30秒</param>
        /// <returns>返回对象</returns>
        public static ReturnBody<T1> CommonHttpRequestForPost<T, T1>(string host, string url, T param, int timeout = 30)
        {
            try
            {
                Guid guid = Guid.NewGuid();
                WipLog4netHelper.WriteRequestRecord<T>(host, url, param, guid);

                JavaScriptDateTimeConverter convert = new JavaScriptDateTimeConverter();
                var strParam = JsonConvert.SerializeObject(param, Formatting.None, convert);//序列化后的字符串
                string content = new HTTPHelper(host).postContentForString(url,
                                strParam, new Guid(), timeout);
                WipLog4netHelper.WriteRequestRecord<T>(host, url, param, guid, content);
                if (!string.IsNullOrEmpty(content))
                {
                    ReturnBody<T1> result = JsonConvert.DeserializeObject<ReturnBody<T1>>(content);
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return null;
        }

        /// <summary>
        /// 公共处理get请求
        /// </summary>
        /// <typeparam name="T">请求参数对象</typeparam>
        /// <typeparam name="T1">返回的data对象</typeparam>
        /// <param name="host">主机名</param>
        /// <param name="url">请求地址</param>
        /// <param name="param">请求参数对象</param>
        /// <param name="timeout">超时时间，单位：秒，默认为30秒</param>
        /// <returns>返回对象</returns>
        public static ReturnBody<T1> CommonHttpRequestForGet<T, T1>(string host, string url, T param, int timeout = 30)
        {
            try
            {
                Guid guid = Guid.NewGuid();
                WipLog4netHelper.WriteRequestRecord<T>(host, url, param, guid);

                string content = new HTTPHelper(host).getContentForString(url, new Guid(), timeout);
                WipLog4netHelper.WriteRequestRecord<T>(host, url, param, guid, content);
                if (!string.IsNullOrEmpty(content))
                {
                    ReturnBody<T1> result = JsonConvert.DeserializeObject<ReturnBody<T1>>(content);
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return null;
        }

    }
}
