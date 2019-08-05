/*
 * CLR Version：4.0.30319.42000
 * NameSpace：WIP_WIPMgmt.IPartial
 * FileName：IWipMgmt
 * CurrentYear：2019
 * CurrentTime：2019/7/24 13:41:07
 * Author：shaocx
 *
 * <更新记录>
 * ver 1.0.0.0   2019/7/24 13:41:07 新規作成 (by shaocx)
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using WIP_Models;

namespace WIP_WIPMgmt
{
    public partial interface IWipMgmt
    {

        /// <summary>
        /// 查询用户登录记录列表
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>用户登录记录列表</returns>
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getUserLoginLogList?userName={userName}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ReturnBody<List<UserLoginLogEntity>> GetUserLoginLogList(string userName);

        [OperationContract]
        [WebInvoke(Method = "OPTIONS", UriTemplate = "getUserLoginLogList", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string GetUserLoginLogList0();


    }
}
