using Newtonsoft.Json;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Threading;
using System.Threading.Tasks;
using WIP_BLL;
using WIP_common;
using WIP_Models;
using WIP_PFMD;
using WIP_Print;

namespace WIP_MES
{
    /// <summary>
    /// MES集成
    /// </summary>
    public partial class MesSysInteg
    {
        #region 基础数据同步

        /// <summary>
        /// 基础数据同步
        /// </summary>
        /// <param name="basedataList"></param>
        /// <returns></returns>
        public ReturnBody<BaseDataSynResultModel> datasyn(List<BaseDataSynParamModel> basedataList)
        {
            ExceptionInfoEntity exception = WipLogHelper.GetNewExceptionInfo<List<BaseDataSynParamModel>>(namespaceName, "datasyn", basedataList,"","");
            try
            {
                #region  验证
                if (basedataList == null)
                {
                    exception.exceptionMsg = "要同步的基础数据为空";
                    return BLLHelpler.GetReturnBody<BaseDataSynResultModel>(ResCode.PARAMETERNOEMPTY, exception.exceptionMsg, exception);
                }
                List<ColumnsModel> columnsList = null;
                ValidateResModel res = null;
                int i = 0;
                List<BaseDataSynParamModel> newBasedataList = new List<BaseDataSynParamModel>();
                List<string> successMaterial = new List<string>();
                List<FailureSaveMaterial> failureMaterialList = new List<FailureSaveMaterial>();
                FailureSaveMaterial failureSaveMaterial = null;
                BaseDataSynResultModel baseModel = new BaseDataSynResultModel();
                foreach (var item in basedataList)
                {
                    i++;
                    //必填项验证
                    columnsList = new List<ColumnsModel>() {
                     new ColumnsModel(){ChinaName="标识",PropertyName="UID"},
                     new ColumnsModel(){ ChinaName="出热MES物料号",PropertyName="heatingOutCode" },
                     new ColumnsModel(){ ChinaName="物料编码",PropertyName="materialCode" },
                     /*
                     new ColumnsModel(){ChinaName="1号线装炉数量",PropertyName="ECM_LINE1"},
                     new ColumnsModel(){ChinaName="2号线装炉数量",PropertyName="ECM_LINE2"},
                     new ColumnsModel(){ChinaName="3号线装炉数量",PropertyName="ECM_LINE3"},
                     new ColumnsModel(){ChinaName="4号线装炉数量",PropertyName="ECM_LINE4"},
                     new ColumnsModel(){ChinaName="5号线装炉数量",PropertyName="ECM_LINE5"},
                     //*/
                     new ColumnsModel(){ChinaName="类型",PropertyName="classification"},
                     new ColumnsModel(){ChinaName="物料出ECM后的去向",PropertyName="directionHeating"}
                };
                    res = ValidateDataHelper.ValidateNullOrEmpty<BaseDataSynParamModel>(columnsList, item);
                    if (res != null && !res.IsValidate)
                    {
                        failureSaveMaterial = new FailureSaveMaterial();
                        failureSaveMaterial.failureReason = "第" + i.ToString() + "个" + res.ValidateMsg;
                        failureSaveMaterial.failureCode = failureCode.empty;
                        failureSaveMaterial.materialCode = item.materialCode;
                        failureSaveMaterial.UID = item.UID;
                        failureMaterialList.Add(failureSaveMaterial);
                        baseModel.FailureCount++;
                        continue;
                    }
                    else
                    {
                        //验证产线装炉量
                        if (item.ECM_LINE1 == 0 && item.ECM_LINE2 == 0
                            && item.ECM_LINE3 == 0 && item.ECM_LINE4 == 0 && item.ECM_LINE5 == 0)
                        {
                            failureSaveMaterial = new FailureSaveMaterial();
                            failureSaveMaterial.failureReason = "第" + i.ToString() + "个五条产线的装炉量不能全是0";
                            failureSaveMaterial.failureCode = failureCode.empty;
                            failureSaveMaterial.materialCode = item.materialCode;
                            failureSaveMaterial.UID = item.UID;
                            failureMaterialList.Add(failureSaveMaterial);
                            baseModel.FailureCount++;
                            continue;
                        }

                        newBasedataList.Add(item);
                    }
                }

                #endregion

                List<Dictionary<string, string>> modelList = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(JsonConvert.SerializeObject(newBasedataList));



                WIP_PFMD.GEBF.BrilliantFactoryClient bfclient = PFMDHelper.GetInstance().GetPfmdCommObject().bfclient;



                Dictionary<string, string> propDict = null;
                bool result = false;

                List<string> materialCodeList = new List<string>();
                foreach (var model in modelList)
                {
                    var new_materialCode = model["materialCode"];
                    materialCodeList.Add(new_materialCode);

                    propDict = new Dictionary<string, string>();
                    foreach (var item in model)
                    {
                        if (item.Key == "materialCode" || item.Key == "UID")
                        {
                            continue;
                        }
                        propDict.Add(item.Key, item.Value);
                    }
                    propDict.Add("heatingInCode", new_materialCode);//进热物料号 【EditBy shaocx,2018-12-13】

                    Dictionary<string, string> dict = bfclient.GetAllProperty(new_materialCode);
                    if (dict != null && dict.Count > 0)
                    {//存在
                        result = bfclient.batchWriteProperty(new_materialCode, propDict);
                        if (!result)
                        {//失败
                            failureSaveMaterial = new FailureSaveMaterial();
                            failureSaveMaterial.failureReason = "第" + i.ToString() + "个修改物料信息失败";
                            failureSaveMaterial.failureCode = failureCode.savefail;
                            failureSaveMaterial.materialCode = model["materialCode"];
                            failureMaterialList.Add(failureSaveMaterial);
                            baseModel.FailureCount++;
                        }
                        else
                        {//成功
                            baseModel.SuccessCount++;
                            successMaterial.Add(model["materialCode"]);
                        }
                    }
                    else
                    {//不存在
                        //逻辑删除标记记为0
                        propDict.Add("delFlag", "0");//逻辑删除为不删除
                        result = bfclient.createMaterial(new_materialCode, "");
                        if (result)
                        {
                            result = bfclient.batchWriteProperty(new_materialCode, propDict);
                        }
                        if (result)
                        {
                            baseModel.SuccessCount++;
                            successMaterial.Add(model["materialCode"]);
                        }
                        else
                        {
                            failureSaveMaterial = new FailureSaveMaterial();
                            failureSaveMaterial.failureReason = "第" + i.ToString() + "个修改物料信息失败";
                            failureSaveMaterial.failureCode = failureCode.savefail;
                            failureSaveMaterial.materialCode = model["materialCode"];
                            failureMaterialList.Add(failureSaveMaterial);
                            baseModel.FailureCount++;
                        }
                    }
                }


                //去掉这里的逻辑 【EditBy shaocx,2019-01-22】
                /*
                //获取所有物料号
                //如果所有的物料号大于同步的物料号，那么多余出来的物料号要修改删除标记为1，表示已删除
                string[] allMaterials = bfclient.getAllMaterials();
                if (allMaterials != null && allMaterials.Length > 0)
                {
                    if (modelList.Count < allMaterials.Length)
                    {
                        foreach (var item in allMaterials)
                        {
                            if (!materialCodeList.Contains(item))
                            {//数据库里有，但是推送的内容里没有
                                bfclient.writeProperty(item, "delFlag", "1");//逻辑删除
                            }
                        }
                    }
                }

                //*/

                baseModel.SuccessMaterial = successMaterial;
                baseModel.FailureMaterial = failureMaterialList;

                if (baseModel.FailureCount > 0)
                {
                    exception.exceptionMsg = ResMsg.FAILURE;
                    exception.exceptionData = JsonConvert.SerializeObject(baseModel);
                    return BLLHelpler.GetReturnBody<BaseDataSynResultModel>(ResCode.FAILURE, ResMsg.FAILURE, exception, baseModel);
                }
                else
                {
                    return BLLHelpler.GetReturnBody<BaseDataSynResultModel>(ResCode.SUCCESS, ResMsg.SUCCESS);
                }
            }
            catch (Exception ex)
            {
                WipLogHelper.GetExceptionInfoForError(ex, ref exception);
                return BLLHelpler.GetReturnBody<BaseDataSynResultModel>(ResCode.FAILURE, ResMsg.FAILURE, exception);
            }
        }

        /// <summary>
        /// 基础数据同步
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string datasyn0()
        {
            return "ok";
        }

        #endregion

    }
}
