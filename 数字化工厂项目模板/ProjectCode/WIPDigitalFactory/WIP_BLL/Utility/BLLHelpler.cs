
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WIP_common;
using WIP_Models;

namespace WIP_BLL
{
    public class BLLHelpler
    {
        private static readonly string namespaceName = "WIP_BLL.BLLHelpler";


        /// <summary>
        /// 获取MangoDB配置的URL
        /// </summary>
        /// <param name="keyName">配置名称</param>
        /// <returns>配置URL</returns>
        public static string GetMangoDBURL(string keyName)
        {
            return GetTheKeyValueCollectionForSysIntegr<MangoDBSection>(keyName).Url;
        }

        #region 获取配置文件信息

        /// <summary>
        /// 获取配置文件信息
        /// </summary>
        /// <param name="configKey"></param>
        /// <returns></returns>
        public static string GetConfigValue(string configKey)
        {
            string configValue = null;
            ExceptionInfoEntity exception = WipLogHelper.GetNewExceptionInfo<string>(namespaceName, "GetConfigValue", configKey, "", "");
            try
            {
                configValue = ConfigurationManager.AppSettings[configKey];
                if (string.IsNullOrEmpty(configValue))
                {
                    throw new Exception("获取配置信息异常,可能不存在该配置或者为空,configKey:" + configKey + ",configValue:" + Convert.ToString(configValue));
                }
            }
            catch (Exception ex)
            {
                WipLogHelper.GetExceptionInfoForError(ex, ref exception);
                WipLogHelper.WriteExceptionInfo(exception);
                throw;
            }
            return configValue;
        }

        #endregion


        /// <summary>
        /// 获取指定的配置对象(系统集成)
        /// </summary>
        /// <param name="keyName">配置名称</param>
        /// <returns></returns>
        public static IntegrKeyValue GetTheKeyValueCollectionForSysIntegr<T>(string keyName)
        {
            ExceptionInfoEntity exception = WipLogHelper.GetNewExceptionInfo<string>(namespaceName, "GetTheKeyValueCollectionForSysIntegr", keyName, "", "");
            try
            {
                //反射获取T类型
                Type t = typeof(T);
                var className = t.Name;//类名

                T configSection = (T)ConfigurationManager.GetSection(className);
                if (configSection == null)
                    throw new ConfigurationErrorsException("Section [" + className + "] is not found.");

                PropertyInfo property = t.GetProperty("KeyValues");
                if (property == null)
                    throw new Exception("Section [" + className + "]的属性KeyValues is not found.");

                Object property_value = property.GetValue(configSection, null);
                IntegrKeyValueCollection keys = (IntegrKeyValueCollection)property_value;
                foreach (IntegrKeyValue item in keys)
                {
                    if (item.Name == keyName)
                        return item;
                }
                throw new ConfigurationErrorsException("Section [" + className + "] 不存在 " + keyName);
            }
            catch (Exception ex)
            {
                WipLogHelper.GetExceptionInfoForError(ex, ref exception);
                WipLogHelper.WriteExceptionInfo(exception);
                throw;
            }
        }


        /// <summary>
        /// 公共返回方法
        /// </summary>
        /// <typeparam name="T">返回T</typeparam>
        /// <param name="redCode">返回编号</param>
        /// <param name="resMsg">返回提示</param>
        /// <param name="t">返回t</param>
        /// <returns></returns>
        public static ReturnBody<T> GetReturnBody<T>(string resCode, string resMsg, T t = default(T))
        {
            return new ReturnBody<T>()
            {
                resCode = resCode,
                resMsg = resMsg,
                resData = t
            };
        }
        /// <summary>
        /// 公共返回方法
        /// </summary>
        /// <typeparam name="T">返回T</typeparam>
        /// <param name="redCode">返回编号</param>
        /// <param name="exception">异常信息</param>
        /// <param name="resMsg">返回提示</param>
        /// <param name="t">返回t</param>
        /// <returns></returns>
        public static ReturnBody<T> GetReturnBody<T>(string resCode, string resMsg, ExceptionInfoEntity exception, T t = default(T))
        {
            if (resCode != ResCode.SUCCESS)
            {
                WipLogHelper.WriteExceptionInfo(exception);
            }
            return new ReturnBody<T>()
            {
                resCode = resCode,
                resMsg = resMsg,
                resData = t
            };
        }

    }
}
