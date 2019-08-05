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
    public partial interface IBasicInfo
    {

        #region 获取邮件类别列表

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "getMailRuleList", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ReturnBody<List<MailRuleEntity>> GetMailRuleList();

        [OperationContract]
        [WebInvoke(Method = "OPTIONS", UriTemplate = "getMailRuleList", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string GetMailRuleList0();

        #endregion


        #region 获取邮件人员列表

        /// <summary> 
        /// 获取邮件人员列表
        /// </summary> 
        /// <returns></returns> 
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "getMailPersonList", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ReturnBody<List<MailPersonModel>> GetMailPersonList(QueryMailPersonParam param);

        [OperationContract]
        [WebInvoke(Method = "OPTIONS", UriTemplate = "getMailPersonList", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string GetMailPersonList0();


        #endregion


        #region 更新邮箱人员

        /// <summary> 
        /// 更新邮箱人员
        /// </summary> 
        /// <returns></returns> 
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "updateMailPerson", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        
        ReturnBody<string> UpdateMailPerson(UpdateMailPersonParam param);

        [OperationContract]
        [WebInvoke(Method = "OPTIONS", UriTemplate = "updateMailPerson", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
       
        string UpdateMailPerson0();

        #endregion

    }
}
