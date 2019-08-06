using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;
using WIP_common;
using WIP_Models;


namespace WIP_Personnel
{
    [ServiceContract]
    public interface IValidateUser
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "validateuser", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ReturnBody<LogonResult> canLogon(UserInfoLogon logonuser);

        [OperationContract]
        [WebInvoke(Method = "OPTIONS", UriTemplate = "validateuser", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        String canLogonO(UserInfoLogon logonuser);

        [OperationContract]
        [WebGet(UriTemplate = "validateuserg", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        String canLogonTestGet();

        [OperationContract]
        [WebGet(UriTemplate = "validateuserTest", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Dictionary<String, String> testGet();

        #region 修改密码

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Userupdatepwd", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ReturnBody<string> Userupdatepwd(UserPassWordParam pwd);

        [OperationContract]
        [WebInvoke(Method = "OPTIONS", UriTemplate = "Userupdatepwd", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string Userupdatepwd0();


            #endregion

        #region 更新权限到Redis

        /// <summary>
        /// 更新权限到Redis
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "updateAuth", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]

        ReturnBody<string> UpdateAuth();

        #endregion

        #region 获取权限

        /// <summary>
        /// 获取权限
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "getAuth", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]

        ReturnBody<List<RedisModel>> GetAuth();

        #endregion

    }


}
