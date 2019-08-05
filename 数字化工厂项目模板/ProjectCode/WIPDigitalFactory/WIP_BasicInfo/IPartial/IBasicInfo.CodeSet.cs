using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WIP_Models;

namespace WIP_BasicInfo
{
    public partial interface IBasicInfo
    {
        #region 插入代码项

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "insertCodeSets", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ReturnBody<string> InsertCodeSets(CodeSetsEntity model);

        [OperationContract]
        [WebInvoke(Method = "OPTIONS", UriTemplate = "insertCodeSets", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string InsertCodeSets0(CodeSetsEntity model);

        #endregion

        #region 更新代码项

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "updateCodeSets", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ReturnBody<string> UpdateCodeSets(CodeSetsEntity model);

        [OperationContract]
        [WebInvoke(Method = "OPTIONS", UriTemplate = "updateCodeSets", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string UpdateCodeSets0(CodeSetsEntity model);

        #endregion

        #region 获取代码项列表（分页）

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "getCodeSetsList", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ReturnBody<PageResultModel<CodeSetsEntity>> GetCodeSetsList(QueryCodeSetsModel queryModel);

        [OperationContract]
        [WebInvoke(Method = "OPTIONS", UriTemplate = "getCodeSetsList", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string GetCodeSetsList0();

        #endregion

        #region 获取代码项列表

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "getAllCodeSets", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ReturnBody<List<CodeSetsModel>> GetAllCodeSets();

        [OperationContract]
        [WebInvoke(Method = "OPTIONS", UriTemplate = "getAllCodeSets", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string GetAllCodeSets0();

        #endregion

        #region 获取单个代码项

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "getSingleCodeSets", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ReturnBody<CodeSetsEntity> GetSingleCodeSets(QueryCodeSetsModel model);

        [OperationContract]
        [WebInvoke(Method = "OPTIONS", UriTemplate = "getSingleCodeSets", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string GetSingleCodeSets0(QueryCodeSetsModel model);

        #endregion

        #region 禁启用代码集表

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "enableCodeSets", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ReturnBody<bool> EnableCodeSets(QueryCodeSetsModel model);

        [OperationContract]
        [WebInvoke(Method = "OPTIONS", UriTemplate = "enableCodeSets", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string EnableCodeSets0();

        #endregion 
    }
}
