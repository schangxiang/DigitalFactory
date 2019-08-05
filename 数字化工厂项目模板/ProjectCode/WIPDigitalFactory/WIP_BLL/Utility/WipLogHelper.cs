using log4net;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using WIP_common;
using WIP_DAL;
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
        private static RequestRecordDAL requestRecordDAL = new WIP_DAL.RequestRecordDAL();
        private static string str_namespaceName = "WIP_WCSIntegr.WCSIntegr|WIP_PlanManagement.Schedule|WIP_TaskExecute.TaskExecMgr|WIP_LIMSIntegr.LIMSIntegr|WIP_MES.MesSysInteg|WIP_QAMSIntegr.QAMSIntegr";
        private static string str_exceptionFun = "AddWipExchange|AttachProc|RecipeParameters|SynRecipe|AddTransferTime|AddStorageTableExchange";



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
                    LogHelper.WriteErrorLogByLog4Net(typeof(LogHelper), JsonConvert.SerializeObject(exception));
                    dal.AddWithKey(exception);
                }
                catch (Exception ex)
                {
                    LogHelper.WriteErrorLogByLog4Net(typeof(LogHelper), "WriteExceptionInfo记录异常表出现异常,exception:" + JsonConvert.SerializeObject(exception), ex);
                }
            });
        }

        /// <summary>
        /// 写异常信息表数据
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="mailSubject">邮件标题</param>
        /// <param name="mailCategoryId">邮件类型ID</param>
        /// <param name="isSendMail">是否需要发邮件</param>
        public static void WriteExceptionInfo(ExceptionInfoEntity exception,
            string mailSubject, string mailCategoryId, bool isSendMail = false)
        {
            Task.Run(() =>//未找到消费线程，新建线程消费队列
            {
                try
                {
                    //只是记录日志吧 
                    LogHelper.WriteErrorLogByLog4Net(typeof(LogHelper), JsonConvert.SerializeObject(exception));
                    dal.Add(exception);

                    #region 报警邮件

                    if (isSendMail)
                    {
                        MailModel mail = new MailModel()
                        {
                            MailSubject = mailSubject,
                            Describe = new DescribeModel()
                            {
                                exceptionData = exception.exceptionData,
                                exceptionMsg = exception.exceptionMsg,
                                sourceData = exception.sourceData
                            }
                        };
                        MailRuleBLL.GetInstance().MailSendingForException(mail, mailCategoryId);
                    }

                    #endregion

                }
                catch (Exception ex)
                {
                    LogHelper.WriteErrorLogByLog4Net(typeof(LogHelper), "WriteExceptionInfo记录异常表出现异常,exception:" + JsonConvert.SerializeObject(exception), ex);
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

        // 即将废除

        /// <summary>
        /// 初始化异常信息类
        /// </summary>
        /// <typeparam name="T">入参类</typeparam>
        /// <param name="namespaceName">当前命名空间名</param>
        /// <param name="exceptionFun">方法名</param>
        /// <param name="param">入参类</param>
        /// <param name="exceptionSource">异常方向，默认是WIP接收</param>
        /// <param name="msgSource">消息来源，默认是WIPREST服务</param>
        /// <returns></returns>
        public static ExceptionInfoEntity GetNewExceptionInfoNoKey<T>(string namespaceName, string exceptionFun, T param,
            ExceptionSource exceptionSource = ExceptionSource.WIPReceive, ExceptionLevel exceptionLevel = ExceptionLevel.BusinessError
            , string msgSource = WipSource.WIPREST)
        {
            ExceptionInfoEntity exception = GetNewExceptionInfoOnly<T>(namespaceName, exceptionFun, param, "", "", exceptionSource,
                 exceptionLevel, msgSource);
            //记录请求日志
            if (str_namespaceName.IndexOf(namespaceName) > -1 || str_exceptionFun.IndexOf(exceptionFun) > -1)
            {
                #region 异步处理

                Task.Run(() =>
                {
                    RequestRecordEntity requestRecord = new RequestRecordEntity()
                    {
                        direction = 1,//  1  WIP接收   2 WIP 推送
                        happenHost = WIPCommon.GetHostName(msgSource),
                        fullFun = namespaceName + "." + exceptionFun,//方法名
                        param = JsonConvert.SerializeObject(param), //入参
                    };
                    LogHelper.WriteInfoLogByLog4Net(typeof(LogHelper), JsonConvert.SerializeObject(requestRecord));
                    requestRecordDAL.Add(requestRecord);
                });

                #endregion
            }

            return exception;
        }

        //*/

        /// <summary>
        /// 初始化异常信息类
        /// </summary>
        /// <typeparam name="T">入参类</typeparam>
        /// <param name="namespaceName">当前命名空间名</param>
        /// <param name="exceptionFun">方法名</param>
        /// <param name="param">入参类</param>
        /// <param name="exceptionSource">异常方向，默认是WIP接收</param>
        /// <param name="msgSource">消息来源，默认是WIPREST服务</param>
        /// <returns></returns>
        public static ExceptionInfoEntity GetNewExceptionInfo<T>(string namespaceName, string exceptionFun, T param, string taskNo, string processCardNumber,
            ExceptionSource exceptionSource = ExceptionSource.WIPReceive, ExceptionLevel exceptionLevel = ExceptionLevel.BusinessError
             , string msgSource = WipSource.WIPREST)
        {
            ExceptionInfoEntity exception = GetNewExceptionInfoOnly<T>(namespaceName, exceptionFun, param, taskNo, processCardNumber, exceptionSource,
                exceptionLevel, msgSource);
            //记录请求日志
            if (str_namespaceName.IndexOf(namespaceName) > -1 || str_exceptionFun.IndexOf(exceptionFun) > -1)
            {
                #region 异步处理

                Task.Run(() =>
                {
                    RequestRecordEntity requestRecord = new RequestRecordEntity()
                    {
                        key1 = taskNo,
                        key2 = processCardNumber,
                        direction = 1,//  1  WIP接收   2 WIP 推送
                        happenHost = WIPCommon.GetHostName(msgSource),
                        fullFun = namespaceName + "." + exceptionFun,//方法名
                        param = JsonConvert.SerializeObject(param), //入参
                    };
                    LogHelper.WriteInfoLogByLog4Net(typeof(LogHelper), JsonConvert.SerializeObject(requestRecord));
                    requestRecordDAL.AddWithKey(requestRecord);
                });

                #endregion
            }

            return exception;
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
        public static ExceptionInfoEntity GetNewExceptionInfoOnly<T>(string namespaceName, string exceptionFun, T param, string taskNo, string processCardNumber,
            ExceptionSource exceptionSource = ExceptionSource.WIPReceive, ExceptionLevel exceptionLevel = ExceptionLevel.BusinessError
             , string msgSource = WipSource.WIPREST)
        {
            ExceptionInfoEntity exception = new ExceptionInfoEntity()
            {
                host = WIPCommon.GetHostName(msgSource),
                key1 = taskNo,
                key2 = processCardNumber,
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
                LogHelper.WriteErrorLogByLog4Net(typeof(LogHelper), "WriteRequestRecord记录异常表出现异常,exception:" + JsonConvert.SerializeObject(requestRecord), ex);
            }
        }


    }
}
