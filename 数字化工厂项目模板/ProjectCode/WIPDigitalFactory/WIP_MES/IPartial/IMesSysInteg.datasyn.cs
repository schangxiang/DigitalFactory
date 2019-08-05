using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using WIP_Models;

namespace WIP_MES
{
    public partial interface IMesSysInteg
    {
        #region 基础数据同步

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "datasyn", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ReturnBody<BaseDataSynResultModel> datasyn(List<BaseDataSynParamModel> basedataList);


        [OperationContract]
        [WebInvoke(Method = "OPTIONS", UriTemplate = "datasyn", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string datasyn0();


        #endregion
    }
}
