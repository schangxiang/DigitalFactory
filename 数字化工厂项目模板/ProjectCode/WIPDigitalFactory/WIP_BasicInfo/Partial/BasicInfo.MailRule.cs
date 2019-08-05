using WIP_BLL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using WIP_common;
using WIP_Models;
using WIP_PFMD;

namespace WIP_BasicInfo
{
    public partial class BasicInfo
    {

        #region 获取邮件类别列表

        /// <summary> 
        /// 获取邮件类别列表
        /// </summary> 
        /// <returns></returns> 
        public ReturnBody<List<MailRuleEntity>> GetMailRuleList()
        {
            ExceptionInfoEntity exception = WipLogHelper.GetNewExceptionInfo<string>(namespaceName, "GetMailRuleList", "", "", "");
            try
            {
                List<MailRuleEntity> list = MailRuleBLL.GetInstance().GetMailRuleList();
                return BLLHelpler.GetReturnBody<List<MailRuleEntity>>(ResCode.SUCCESS, ResMsg.SUCCESS, list);
            }
            catch (Exception ex)
            {
                WipLogHelper.GetExceptionInfoForError(ex, ref exception);
                return BLLHelpler.GetReturnBody<List<MailRuleEntity>>(ResCode.FAILURE, ResMsg.FAILURE, exception);
            }
        }
        public string GetMailRuleList0()
        {
            return "OK";
        }

        #endregion

        #region 获取邮件人员列表

        /// <summary> 
        /// 获取邮件人员列表
        /// </summary> 
        /// <returns></returns> 
        public ReturnBody<List<MailPersonModel>> GetMailPersonList(QueryMailPersonParam param)
        {
            ExceptionInfoEntity exception = WipLogHelper.GetNewExceptionInfo<string>(namespaceName, "GetMailPersonList", "", "", "");
            try
            {
                if (param == null || string.IsNullOrEmpty(param.categoryId))
                {
                    return BLLHelpler.GetReturnBody<List<MailPersonModel>>(ResCode.PARAMETERNOEMPTY, ResMsg.PARAMETERNOEMPTY, null);
                }
                List<MailPersonModel> list = MailRuleBLL.GetInstance().GetMailPersonList(param.categoryId);
                return BLLHelpler.GetReturnBody<List<MailPersonModel>>(ResCode.SUCCESS, ResMsg.SUCCESS, list);
            }
            catch (Exception ex)
            {
                WipLogHelper.GetExceptionInfoForError(ex, ref exception);
                return BLLHelpler.GetReturnBody<List<MailPersonModel>>(ResCode.FAILURE, ResMsg.FAILURE, exception);
            }
        }
        public string GetMailPersonList0()
        {
            return "OK";
        }

        #endregion

        #region 更新邮箱人员

        /// <summary> 
        /// 更新邮箱人员
        /// </summary> 
        /// <returns></returns> 
        public ReturnBody<string> UpdateMailPerson(UpdateMailPersonParam param)
        {
            ExceptionInfoEntity exception = WipLogHelper.GetNewExceptionInfo<UpdateMailPersonParam>(namespaceName, "UpdateMailPerson", param, "", "");
            try
            {
                MethodReturnResultModel ret = MailRuleBLL.GetInstance().UpdateMailPerson(param, JwtHelp.GetCurUserName());
                if (ret != null && ret.IsSuccess)
                {
                    return BLLHelpler.GetReturnBody<string>(ResCode.SUCCESS, ResMsg.SUCCESS, "");
                }
                else
                {
                    return BLLHelpler.GetReturnBody<string>(ResCode.FAILURE, ResMsg.FAILURE, "");
                }
            }
            catch (Exception ex)
            {
                WipLogHelper.GetExceptionInfoForError(ex, ref exception);
                return BLLHelpler.GetReturnBody<string>(ResCode.FAILURE, ResMsg.FAILURE, exception);
            }
        }
        public string UpdateMailPerson0()
        {
            return "OK";
        }

        #endregion

    }
}
