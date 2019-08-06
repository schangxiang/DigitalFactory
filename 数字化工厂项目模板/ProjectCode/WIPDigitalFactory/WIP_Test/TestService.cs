using Newtonsoft.Json;
using SysManager.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WIP_BLL;
using WIP_common;
using WIP_DAL;
using WIP_Models;

using WIP_PFMD;

namespace WIP_Test
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class TestService : ITestService
    {
        private string namespaceName = "WIP_Test.TestService";//命名空间

       

        /// <summary>
        /// 加解密数据
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ReturnBody<string> GetEncryptData(GetEncryptData param)
        {
            ExceptionInfoEntity exception = WipLog4netHelper.GetNewExceptionInfoNoKey<GetEncryptData>(namespaceName, "GetEncryptData", param);
            try
            {
                string result = "";
                if (param.isEncrypt == "0")
                {//加密 
                    result = DESEncryptHelper.Encrypt(param.value);
                }
                else if (param.isEncrypt == "1")
                { //解密
                    result = DESEncryptHelper.Decrypt(param.value);
                }
                else
                {
                    return BLLHelpler.GetReturnBody<string>(ResCode.FAILURE, ResMsg.FAILURE, "是否解密值错误");
                }
                return BLLHelpler.GetReturnBody<string>(ResCode.SUCCESS, ResMsg.SUCCESS, result);
            }
            catch (Exception ex)
            {
                WipLog4netHelper.GetExceptionInfoForError(ex, ref exception);
                return BLLHelpler.GetReturnBody<string>(ResCode.FAILURE, ResMsg.FAILURE, exception, "出现错误:" + ex.Message);
            }
        }

        /// <summary>
        /// 生成token
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public ReturnBody<string> GenerateToken(GenerateTokenParam user)
        {
            ExceptionInfoEntity exception = WipLog4netHelper.GetNewExceptionInfoNoKey<GenerateTokenParam>(namespaceName, "GenerateToken", user);
            try
            {
                string token = JwtHelp.GenerateToken(user.Name, null, user.ExpDays);
                return BLLHelpler.GetReturnBody<string>(ResCode.SUCCESS, ResMsg.SUCCESS, token);
            }
            catch (Exception ex)
            {
                WipLog4netHelper.GetExceptionInfoForError(ex, ref exception);
                return BLLHelpler.GetReturnBody<string>(ResCode.FAILURE, ResMsg.FAILURE, exception, "出现错误:" + ex.Message);
            }
        }
        //*/

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ReturnBody<bool> SendMail(MailParam param)
        {
            ExceptionInfoEntity exception = WipLog4netHelper.GetNewExceptionInfoNoKey<MailParam>(namespaceName, "SendMail", param);
            try
            {
                param.describe = "<p class=\"MsoNormal\"><span lang=\"EN-US\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>上汽项目<span lang=\"EN-US\">,ECM</span>联调问题很多<span lang=\"EN-US\">,</span>项目已经红色预警<span lang=\"EN-US\">,</span>我们将在周末继续配合法方修正各个关键点<span lang=\"EN-US\">.<o:p></o:p></span></p>";

                IMail _mail = new Mail(MailCategory.缺省);
                _mail.MailSending(param.mailSubject, param.describe, param.file_Path);
                return BLLHelpler.GetReturnBody<bool>(ResCode.SUCCESS, ResMsg.SUCCESS, true);
            }
            catch (Exception ex)
            {
                WipLog4netHelper.GetExceptionInfoForError(ex, ref exception);
                return BLLHelpler.GetReturnBody<bool>(ResCode.FAILURE, ResMsg.FAILURE, exception, false);
            }
        }
    }
}
