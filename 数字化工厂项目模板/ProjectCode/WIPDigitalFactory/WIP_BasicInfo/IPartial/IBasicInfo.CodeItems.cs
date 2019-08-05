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
        #region 插入代码项表

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "insertCodeItems", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ReturnBody<string> InsertCodeItems(CodeItemsEntity model);

        [OperationContract]
        [WebInvoke(Method = "OPTIONS", UriTemplate = "insertCodeItems", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string InsertCodeItems0(CodeItemsEntity model);

        #endregion

        #region 更新代码项表

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "updateCodeItems", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ReturnBody<string> UpdateCodeItems(CodeItemsEntity model);

        [OperationContract]
        [WebInvoke(Method = "OPTIONS", UriTemplate = "updateCodeItems", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string UpdateCodeItems0(CodeItemsEntity model);

        #endregion

        #region 获取代码项表列表（分页）

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "getCodeItemsList", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ReturnBody<PageResultModel<CodeItemsEntity>> GetCodeItemsList(QueryCodeItemsModel queryModel);

        [OperationContract]
        [WebInvoke(Method = "OPTIONS", UriTemplate = "getCodeItemsList", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string GetCodeItemsList0();



        #endregion

        #region 获取指定代码集的代码项表列表

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "getAllCodeItemsByCodeSet", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ReturnBody<List<CodeSetsModel>> GetAllCodeItemsByCodeSet(GetAllCodeItemsByCodeSetParam param);

        [OperationContract]
        [WebInvoke(Method = "OPTIONS", UriTemplate = "getAllCodeItemsByCodeSet", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string GetAllCodeItemsByCodeSet0();

        #endregion

        #region 获取单个代码项表

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "getSingleCodeItems", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ReturnBody<CodeItemsEntity> GetSingleCodeItems(QueryCodeItemsModel model);

        [OperationContract]
        [WebInvoke(Method = "OPTIONS", UriTemplate = "getSingleCodeItems", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string GetSingleCodeItems0(QueryCodeItemsModel model);

        #endregion

        #region 禁启用代码项表

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "enableCodeItems", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ReturnBody<bool> EnableCodeItems(QueryCodeItemsModel model);

        [OperationContract]
        [WebInvoke(Method = "OPTIONS", UriTemplate = "enableCodeItems", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string EnableCodeItems0(QueryCodeItemsModel model);

        #endregion 
    }
}
