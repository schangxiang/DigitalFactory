/*
 * CLR Version：4.0.30319.42000
 * NameSpace：WIP_WIPMgmt.Partial
 * FileName：WipMgmt
 * CurrentYear：2019
 * CurrentTime：2019/7/24 11:48:50
 * Author：shaocx
 *
 * <更新记录>
 * ver 1.0.0.0   2019/7/24 11:48:50 新規作成 (by shaocx)
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIP_BLL;
using WIP_common;
using WIP_Models;
using System.ComponentModel.Composition;
using WIP_IBLL;

namespace WIP_WIPMgmt
{
    public partial class WipMgmt
    {
        string namespaceName = "WIP_WIPMgmt.WipMgmt";
        /// <summary>
        /// 查询用户登录记录列表
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>用户登录记录列表</returns>
        public ReturnBody<List<UserLoginLogEntity>> GetUserLoginLogList(string userName)
        {
            ReturnBody<List<UserLoginLogEntity>> ret = null;
            //请求信息没记录下来
            ExceptionInfoEntity exception = WipLog4netHelper.GetNewExceptionInfoOnly<string>(namespaceName,
               "GetUserLoginLogList", userName,
               "", "");
            try
            {
                ret = new ReturnBody<List<UserLoginLogEntity>>();
                ret.resCode = ResCode.SUCCESS;
                ret.resData = IOCContainer.Container.GetExport<IUserLoginLogBLL>("UserLoginLog").Value.GetUserLoginLogList(userName);
            }
            catch (Exception ex)
            {//异常信息没有记录下来

                WipLog4netHelper.GetExceptionInfoForError(ex, ref exception);
                WipLog4netHelper.WriteExceptionInfo(exception);

                ret.resCode = ResCode.FAILURE;
                ret.resMsg = ex.Message;
            }
            return ret;
        }

        public string GetUserLoginLogList0()
        {
            return "ok";
        }
    }
}
