using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using WIP_Models;

namespace WIP_BasicInfo
{
    public partial interface   IBasicInfo
    {
        #region 获取用户


        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetAuthorizationuser", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]

        ReturnBody<AuthorizationUserModel> GetAuthorizationuser(AuthorizationUserModel model);


        [OperationContract]
        [WebInvoke(Method = "OPTIONS", UriTemplate = "GetAuthorizationuser", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string GetAuthorizationuser0();


        #endregion
    }
}
