
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
