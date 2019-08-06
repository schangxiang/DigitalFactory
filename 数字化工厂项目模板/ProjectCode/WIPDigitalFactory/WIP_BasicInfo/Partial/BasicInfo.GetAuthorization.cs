using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIP_BLL;
using WIP_common;
using WIP_Models;

namespace WIP_BasicInfo
{
    /// <summary>  
    /// 根据用户获取详细信息  
    /// </summary>
    public partial class BasicInfo
    {
        PR_AuthorizationBLL Authorizationbll = new PR_AuthorizationBLL();
        public ReturnBody<AuthorizationUserModel> GetAuthorizationuser(AuthorizationUserModel model)
        {

            ExceptionInfoEntity exception = WipLog4netHelper.GetNewExceptionInfoNoKey<AuthorizationUserModel>(namespaceName, "GetAuthorizationuser", model);
            try
            {
                #region 验证
                if (model == null || string.IsNullOrEmpty(model.s95id))
                {
                    exception.exceptionMsg = ResMsg.PARAMETERNOEMPTY;
                    return BLLHelpler.GetReturnBody<AuthorizationUserModel>(ResCode.PARAMETERNOEMPTY, exception.exceptionMsg);
                }
                #endregion
                var retModel = Authorizationbll.GetAuthorization(model.s95id);
                if (retModel == null)
                {
                    exception.exceptionMsg = "没有找到相关用户";
                    return BLLHelpler.GetReturnBody<AuthorizationUserModel>(ResCode.FAILURE, exception.exceptionMsg);
                }
                return BLLHelpler.GetReturnBody<AuthorizationUserModel>(ResCode.SUCCESS, ResMsg.SUCCESS, retModel);
            }
            catch (Exception ex)
            {
                WipLog4netHelper.GetExceptionInfoForError(ex, ref exception);
                return BLLHelpler.GetReturnBody<AuthorizationUserModel>(ResCode.FAILURE, ResMsg.FAILURE, exception);
            }
        }
        public string GetAuthorizationuser0()
        {
            return "ok";
        }
    }
}
