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
    /// 打印配置
    /// </summary>
    public partial interface IBasicInfo
    {
        #region 插入打印配置

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "insertPrintConfig", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ReturnBody<string> InsertPrintConfig(PrintConfigEntity model);

        [OperationContract]
        [WebInvoke(Method = "OPTIONS", UriTemplate = "insertPrintConfig", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string InsertPrintConfig0(PrintConfigEntity model);

        #endregion

        #region 更新打印配置

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "updatePrintConfig", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ReturnBody<string> UpdatePrintConfig(PrintConfigEntity model);

        [OperationContract]
        [WebInvoke(Method = "OPTIONS", UriTemplate = "updatePrintConfig", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string UpdatePrintConfig0(PrintConfigEntity model);

        #endregion

        #region 获取打印配置列表（分页）

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "getPrintConfigList", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ReturnBody<PageResultModel<PrintConfigModel>> GetPrintConfigList(QueryPrintConfigParam queryModel);

        [OperationContract]
        [WebInvoke(Method = "OPTIONS", UriTemplate = "getPrintConfigList", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string GetPrintConfigList0();

        #endregion

        #region 获取单个打印配置

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "getSinglePrintConfig", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ReturnBody<PrintConfigEntity> GetSinglePrintConfig(QueryPrintConfigParam model);

        [OperationContract]
        [WebInvoke(Method = "OPTIONS", UriTemplate = "getSinglePrintConfig", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string GetSinglePrintConfig0(QueryPrintConfigParam model);

        #endregion

        #region 禁启用打印配置表

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "enablePrintConfig", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ReturnBody<bool> EnablePrintConfig(QueryPrintConfigParam model);

        [OperationContract]
        [WebInvoke(Method = "OPTIONS", UriTemplate = "enablePrintConfig", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string EnablePrintConfig0();

        #endregion 
    }
}
