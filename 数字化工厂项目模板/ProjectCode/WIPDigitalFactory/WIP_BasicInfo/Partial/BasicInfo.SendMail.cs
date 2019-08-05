using WIP_BLL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using WIP_common;
using WIP_Models;

namespace WIP_BasicInfo
{
    public partial class BasicInfo
    {
        #region 发送邮件

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ReturnBody<bool> SendMail(MailParam param)
        {
            ExceptionInfoEntity exception = WipLogHelper.GetNewExceptionInfo<MailParam>(namespaceName, "SendMail", param, "", "");
            try
            {
                IMail _mail = new Mail(MailCategory.缺省);
                _mail.MailSending(param.mailSubject, param.describe, param.file_Path);
                return BLLHelpler.GetReturnBody<bool>(ResCode.SUCCESS, ResMsg.SUCCESS, true);
            }
            catch (Exception ex)
            {
                WipLogHelper.GetExceptionInfoForError(ex, ref exception);
                return BLLHelpler.GetReturnBody<bool>(ResCode.FAILURE, ResMsg.FAILURE, exception, false);
            }
        }

        #endregion
    }
}
