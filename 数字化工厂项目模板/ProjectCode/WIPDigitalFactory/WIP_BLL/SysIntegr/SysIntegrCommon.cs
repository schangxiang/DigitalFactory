
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WIP_common;
using WIP_Models;
using WIP_DAL;

namespace WIP_BLL
{
    class SysIntegrCommon
    {
        /// <summary>
        /// 处理请求(重试功能)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="host"></param>
        /// <param name="url"></param>
        /// <param name="param"></param>
        /// <param name="sysCode"></param>
        /// <param name="requestDesc"></param>
        /// <param name="exception"></param>
        /// <param name="businessExceptionParam"></param>
        /// <param name="requestType"></param>
        public static void DoRequestWithRetry<T>(string host, string url, T param, string sysCode, string requestDesc, ExceptionInfoEntity exception,
            BusinessExceptionMgrParam businessExceptionParam,
            RequestType requestType)
        {
            Task.Run(() =>
            {
                CommonDoRequestWithRetry<T>(host, url, param, sysCode, requestDesc, exception, businessExceptionParam, requestType);
            });
        }

        /// <summary>
        /// 处理请求(重试功能)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="host"></param>
        /// <param name="url"></param>
        /// <param name="param"></param>
        /// <param name="sysCode"></param>
        /// <param name="requestDesc"></param>
        /// <param name="exception"></param>
        /// <param name="businessExceptionParam"></param>
        /// <param name="requestType"></param>
        /// <param name="execCount"></param>
        private static void CommonDoRequestWithRetry<T>(string host, string url, T param, string sysCode, string requestDesc, ExceptionInfoEntity exception,
            BusinessExceptionMgrParam businessExceptionParam,
            RequestType requestType,
            int execCount = 0)
        {
            execCount = execCount + 1;
            bool execResult = false;
            ResponseUpdater _responseUpdater = null;
            try
            {
                switch (requestType)
                {
                    case RequestType.PredictiveTask:// 质量预测发起

                        _responseUpdater = new PredictiveTask_ResUpdater(execResult, exception);

                        break;
                    case RequestType.Other:
                    case RequestType.QualityTaskToLIMS:

                        _responseUpdater = new ResponseUpdater(execResult, exception);

                        break;
                   
                    case RequestType.PushProcessCardInfoToWCS:

                        _responseUpdater = new PushProcessCardInfoToWCS_ResUpdater(execResult, exception);

                        break;
                }

                _responseUpdater.DoResponse<T>(host, url, param, execCount);
                execResult = _responseUpdater._ResponseUpdaterRet.execResult;
                exception = _responseUpdater._ResponseUpdaterRet.exception;

            }
            catch (Exception ex)
            {
                WipLogHelper.GetExceptionInfoForError(ex, ref exception);
                exception.exceptionMsg += ",执行次数:" + execCount.ToString();
                execResult = false;
            }
            finally
            {
                if (!execResult)
                {
                    CommonDoRequestWithRetryByFailure<T>(host, url, param, sysCode, requestDesc, exception, businessExceptionParam, requestType, execCount);
                }
            }
        }

        /// <summary>
        /// 请求失败的处理
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="host"></param>
        /// <param name="url"></param>
        /// <param name="param"></param>
        /// <param name="sysCode"></param>
        /// <param name="requestDesc"></param>
        /// <param name="exception"></param>
        /// <param name="businessExceptionParam"></param>
        /// <param name="requestType"></param>
        /// <param name="execCount"></param>
        private static void CommonDoRequestWithRetryByFailure<T>(string host, string url, T param, string sysCode, string requestDesc, ExceptionInfoEntity exception,
            BusinessExceptionMgrParam businessExceptionParam,
            RequestType requestType,
            int execCount)
        {
            WipLogHelper.WriteExceptionInfo(exception);
            int retryCount = GetRequestRetryCount();
            if (execCount < retryCount)
            {
                Thread.Sleep(1000);//休眠1秒
                CommonDoRequestWithRetry<T>(host, url, param, sysCode, requestDesc, exception, businessExceptionParam, requestType, execCount);
            }
            else
            {//请求次数用尽
                if (businessExceptionParam != null)
                {
                    //重新赋值异常信息值
                    businessExceptionParam.exceptionMsg = businessExceptionParam.exceptionMsg + "-" + exception.exceptionMsg;
                }

                if (requestType == RequestType.QualityStatusToWCS)
                {//如果是质检结果推送给WCS，则不写业务异常，因为有些料是直接送到后道缓存区，然后线下抽样送检的，库存没有东西的

                }
                else
                {
                    exception.exceptionMsg += "执行次数已超过限制值:" + retryCount.ToString();
                    WipLogHelper.WriteExceptionInfo(exception);

                    //发送报警邮件
                    if (IsSendMail(requestType))
                    {
                        SendMailForCommonDoRequestFailure(param, requestDesc, exception, sysCode, host, url, retryCount, businessExceptionParam);
                    }

                    //发送业务异常
                    SendBusinessException(requestType,businessExceptionParam);
                }
            }
        }

        /// <summary>
        ///  发送业务异常
        /// </summary>
        /// <param name="businessExceptionParam"></param>
        private static void SendBusinessException(RequestType requestType, BusinessExceptionMgrParam businessExceptionParam)
        {
            if (businessExceptionParam != null)
            {
                if (requestType == RequestType.QualityTaskToLIMS && businessExceptionParam.exceptionMsg.IndexOf("重复提交") > -1)
                {//质检任务发给LIMS，如果提示 重复提交的话，不要写入业务异常信息表中
                    return;
                }
                BusinessExceptionMgrBLL.GetInstance().AddBusinessException(businessExceptionParam, JwtHelp.GetCurUserName());
            }
        }


        /// <summary>
        /// 是否需要发送邮件
        /// </summary>
        /// <param name="requestType"></param>
        /// <returns></returns>
        private static bool IsSendMail(RequestType requestType)
        {
            if (requestType == RequestType.PredictiveTask)
            {//质量预测发起失败了也不要发邮件
                return false;
            }
            return true;
        }

        /// <summary>
        /// //发送报警邮件(公共请求失败的情况下)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="param"></param>
        /// <param name="requestDesc"></param>
        /// <param name="exception"></param>
        /// <param name="sysCode"></param>
        /// <param name="host"></param>
        /// <param name="url"></param>
        /// <param name="retryCount"></param>
        private static void SendMailForCommonDoRequestFailure<T>(T param, string requestDesc, ExceptionInfoEntity exception,
            string sysCode, string host, string url, int retryCount, BusinessExceptionMgrParam businessExceptionParam)
        {

            var mailTitle = "请求[" + requestDesc + "]" + exception.exceptionMsg;
            var describe = new StringBuilder();
            describe.Append(mailTitle + "!!!<br/>");
            describe.Append("   请求系统：" + sysCode + "<br/>");
            describe.Append("   请求地址：" + host + url + "<br/>");
            describe.Append("   请求参数：" + JsonConvert.SerializeObject(param) + "<br/>");

            //邮箱标题
            var mailSubject = requestDesc + "请求" + retryCount.ToString() + "次失败";
            mailSubject += "[ ";
            if (businessExceptionParam != null)
            {
                mailSubject += "任务号:" + (businessExceptionParam.taskNo == null ? "" : businessExceptionParam.taskNo) + " , ";
                mailSubject += "流转卡号:" + (businessExceptionParam.processCardNumber == null ? "" : businessExceptionParam.processCardNumber);
            }
            mailSubject += " ]";

            IMail mail = new Mail(WIPCommon.GetMailCategoryBySysIntegr(sysCode));
            mail.MailSending(mailSubject, describe.ToString(), "");
        }


        #region 获取配置的请求重试次数

        /// <summary>
        /// 获取配置的请求重试次数
        /// </summary>
        /// <returns></returns>
        public static int GetRequestRetryCount()
        {
            int retryCount = 3;//默认3个
            try
            {
                string RequestRetryCount = BLLHelpler.GetConfigValue("RequestRetryCount");
                int.TryParse(RequestRetryCount, out retryCount);
            }
            catch
            {
            }
            return retryCount;
        }

        #endregion
    }
}
