using log4net;
using Newtonsoft.Json;
using SysManager.Common.Utilities;
using System;
using System.Threading.Tasks;
using WIP_common;
using WIP_SQLServerDAL;
using WIP_Models;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace WIP_BLL
{
    /// <summary>
    /// 日志帮助
    /// </summary>
    public class WipLogHelper
    {
        private static ExceptionInfoDAL dal = ExceptionInfoDAL.GetInstance();
        private static RequestRecordDAL requestRecordDAL = new WIP_SQLServerDAL.RequestRecordDAL();

        /// <summary>
        /// 写异常信息表数据
        /// </summary>
        /// <param name="exception"></param>
        public static void WriteExceptionInfo(ExceptionInfoEntity exception)
        {
            Task.Run(() =>//未找到消费线程，新建线程消费队列
            {
                try
                {
                    //只是记录日志吧 
                    Log4netHelper.WriteErrorLogByLog4Net(typeof(Log4netHelper), JsonConvert.SerializeObject(exception));
                    dal.AddWithKey(exception);
                }
                catch (Exception ex)
                {
                    Log4netHelper.WriteErrorLogByLog4Net(typeof(Log4netHelper), "WriteExceptionInfo记录异常表出现异常,exception:" + JsonConvert.SerializeObject(exception), ex);
                }
            });
        }

        /// <summary>
        /// Error情况下的异常信息赋值
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="exception"></param>
        public static void GetExceptionInfoForError(Exception ex, ref ExceptionInfoEntity exception)
        {
            exception.exceptionMsg = ex.Message;
            exception.exceptionLevel = Convert.ToInt32(ExceptionLevel.Error).ToString();
            exception.exceptionData = JsonConvert.SerializeObject(ex);
        }


        /// <summary>
        /// 初始化异常信息类(仅仅是获取异常信息对象)
        /// </summary>
        /// <typeparam name="T">入参类</typeparam>
        /// <param name="namespaceName">当前命名空间名</param>
        /// <param name="exceptionFun">方法名</param>
        /// <param name="param">入参类</param>
        /// <param name="exceptionSource">异常方向，默认是WIP接收</param>
        /// <param name="msgSource">消息来源，默认是WIPREST服务</param>
        /// <returns></returns>
        public static ExceptionInfoEntity GetExceptionInfo<T>(string namespaceName, string exceptionFun, T param,
        string key1 = "", string key2 = "",
            ExceptionSource exceptionSource = ExceptionSource.WIPReceive, ExceptionLevel exceptionLevel = ExceptionLevel.BusinessError
             , string msgSource = WipSource.WIPREST)
        {
            ExceptionInfoEntity exception = new ExceptionInfoEntity()
            {
                host = WIPCommon.GetHostName(msgSource),
                key1 = key1,
                key2 = key2,
                exceptionLevel = Convert.ToInt32(exceptionLevel).ToString(),//异常级别：默认是业务错误
                exceptionFun = namespaceName + "." + exceptionFun,//异常方法名
                exceptionSource = Convert.ToInt32(exceptionSource).ToString(),//异常方向
                sourceData = JsonConvert.SerializeObject(param), //入参
                creator = JwtHelp.GetCurUserName()
            };
            return exception;
        }


        /// <summary>
        /// 记录请求日志
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="namespaceName"></param>
        /// <param name="exceptionFun"></param>
        /// <param name="param"></param>
        public static void WriteRequestRecord<T>(string host, string url, T param, Guid guid, string retResult = "")
        {
            RequestRecordEntity requestRecord = null;
            try
            {
                requestRecord = new RequestRecordEntity()
               {
                   direction = 2,//  1  WIP接收   2 WIP 推送
                   happenHost = WIPCommon.GetHostName(),
                   remark = guid.ToString(),
                   host = host,
                   url = url,
                   retResult = retResult,
                   param = JsonConvert.SerializeObject(param), //入参
               };
                requestRecordDAL.Add(requestRecord);
            }
            catch (Exception ex)
            {
                Log4netHelper.WriteErrorLogByLog4Net(typeof(Log4netHelper), "WriteRequestRecord记录异常表出现异常,exception:" + JsonConvert.SerializeObject(requestRecord), ex);
            }
        }


    }
}
