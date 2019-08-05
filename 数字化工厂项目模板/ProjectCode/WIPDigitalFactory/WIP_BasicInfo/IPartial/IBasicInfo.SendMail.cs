using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WIP_common;
using WIP_Models;

namespace WIP_BasicInfo
{
    /// <summary>
    /// 发送邮件
    /// </summary>
    public partial interface IBasicInfo
    {
        #region 发送邮件

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "sendMail", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ReturnBody<bool> SendMail(MailParam param);
        

        #endregion
    }
}
