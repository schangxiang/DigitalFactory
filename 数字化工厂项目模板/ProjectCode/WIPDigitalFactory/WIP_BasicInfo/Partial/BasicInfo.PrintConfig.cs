using WIP_BLL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using WIP_common;
using WIP_Models;

namespace WIP_BasicInfo
{
    public partial class BasicInfo
    {
        private PrintConfigBLL printConfigBLL = new PrintConfigBLL();

        #region 插入打印配置

        /// <summary> 
        /// 插入打印配置 
        /// </summary> 
        /// <param name="model"></param> 
        /// <returns></returns> 
        public ReturnBody<string> InsertPrintConfig(PrintConfigEntity model)
        {
            ReturnBody<string> retBody = null;
            ExceptionInfoEntity exception = WipLogHelper.GetNewExceptionInfoNoKey<PrintConfigEntity>(namespaceName, "InsertPrintConfig", model);
            try
            {
                #region 验证
                if (model == null)
                {
                    exception.exceptionMsg = ResMsg.PARAMETERNOEMPTY;
                    retBody = BLLHelpler.GetReturnBody<string>(ResCode.PARAMETERNOEMPTY, ResMsg.PARAMETERNOEMPTY, exception);
                    return retBody;
                }
                List<ColumnsModel> columnsList = new List<ColumnsModel>() { 
                     new ColumnsModel(){ ChinaName="打印类型",PropertyName="printType" },
                     new ColumnsModel(){ ChinaName="打印类型描述",PropertyName="printTypeName" },
                     new ColumnsModel(){ ChinaName="打印机名称",PropertyName="printerName" },
                     new ColumnsModel(){ ChinaName="打印模板",PropertyName="printTemplete" }
                };

                ValidateResModel res = ValidateDataHelper.ValidateNullOrEmpty<PrintConfigEntity>(columnsList, model);
                if (res != null && !res.IsValidate)
                {
                    exception.exceptionMsg = res.ValidateMsg;
                    retBody = BLLHelpler.GetReturnBody<string>(ResCode.PARAMETERNOEMPTY, res.ValidateMsg, exception);
                    return retBody;
                }
                //验证重复 
                if (printConfigBLL.Exists(model.printType.ToString()))
                {
                    exception.exceptionMsg = "数据已经存在";
                    retBody = BLLHelpler.GetReturnBody<string>(ResCode.FAILURE, exception.exceptionMsg, exception);
                    return retBody;
                }
                #endregion

                model.delFlag = false;
                model.createTime = model.lastModifyTime = DateTime.Now;

                if (printConfigBLL.Add(model) > 0)
                {
                    retBody = BLLHelpler.GetReturnBody<string>(ResCode.SUCCESS, ResMsg.SUCCESS);
                }
                else
                {//失败 
                    exception.exceptionMsg = "保存数据失败";
                    retBody = BLLHelpler.GetReturnBody<string>(ResCode.FAILURE, exception.exceptionMsg, exception);
                }
                return retBody;
            }
            catch (Exception ex)
            {
                WipLogHelper.GetExceptionInfoForError(ex, ref exception);
                retBody = BLLHelpler.GetReturnBody<string>(ResCode.FAILURE, ResMsg.FAILURE + ":" + ex.Message, exception);
                return retBody;
            }
        }
        public string InsertPrintConfig0(PrintConfigEntity model)
        {
            return "OK";
        }

        #endregion

        #region 更新打印配置

        /// <summary> 
        /// 更新打印配置 
        /// </summary> 
        /// <param name="model"></param> 
        /// <returns></returns> 
        public ReturnBody<string> UpdatePrintConfig(PrintConfigEntity model)
        {
            ReturnBody<string> retBody = null;
            ExceptionInfoEntity exception = WipLogHelper.GetNewExceptionInfoNoKey<PrintConfigEntity>(namespaceName, "UpdatePrintConfig", model);
            try
            {
                #region 验证
                if (model == null)
                {
                    exception.exceptionMsg = ResMsg.PARAMETERNOEMPTY;
                    retBody = BLLHelpler.GetReturnBody<string>(ResCode.PARAMETERNOEMPTY, exception.exceptionMsg, exception);
                    return retBody;
                }
                List<ColumnsModel> columnsList = new List<ColumnsModel>() { 
                     new ColumnsModel(){ ChinaName="打印类型",PropertyName="printType" },
                     new ColumnsModel(){ ChinaName="打印类型描述",PropertyName="printTypeName" },
                     new ColumnsModel(){ ChinaName="打印机名称",PropertyName="printerName" },
                     new ColumnsModel(){ ChinaName="打印模板",PropertyName="printTemplete" }
                };

                ValidateResModel res = ValidateDataHelper.ValidateNullOrEmpty<PrintConfigEntity>(columnsList, model);
                if (res != null && !res.IsValidate)
                {
                    exception.exceptionMsg = res.ValidateMsg;
                    retBody = BLLHelpler.GetReturnBody<string>(ResCode.PARAMETERNOEMPTY, exception.exceptionMsg, exception);
                    return retBody;
                }

                //验证重复 
                if (printConfigBLL.Exists(model.printType.ToString(), model.id))
                {
                    exception.exceptionMsg = "数据已经存在";
                    retBody = BLLHelpler.GetReturnBody<string>(ResCode.FAILURE, exception.exceptionMsg, exception);
                    return retBody;
                } 

                #endregion

                bool result = printConfigBLL.Update(model);
                if (result)
                {
                    retBody = BLLHelpler.GetReturnBody<string>(ResCode.SUCCESS, ResMsg.SUCCESS);
                }
                else
                {
                    exception.exceptionMsg = "更新失败";
                    retBody = BLLHelpler.GetReturnBody<string>(ResCode.FAILURE, exception.exceptionMsg, exception);
                }
                return retBody;
            }
            catch (Exception ex)
            {
                WipLogHelper.GetExceptionInfoForError(ex, ref exception);
                retBody = BLLHelpler.GetReturnBody<string>(ResCode.FAILURE, ResMsg.FAILURE + ":" + ex.Message, exception);
                return retBody;
            }
        }
        public string UpdatePrintConfig0(PrintConfigEntity model)
        {
            return "OK";
        }

        #endregion

        #region 获取打印配置列表（分页）

        /// <summary> 
        /// 获取打印配置列表（分页） 
        /// </summary> 
        /// <returns></returns> 
        public ReturnBody<PageResultModel<PrintConfigModel>> GetPrintConfigList(QueryPrintConfigParam queryModel)
        {
            ExceptionInfoEntity exception = WipLogHelper.GetNewExceptionInfoNoKey<QueryPrintConfigParam>(namespaceName, "GetPrintConfigList", queryModel);
            try
            {
                PageResultModel<PrintConfigModel> list = printConfigBLL.GetModelListForPage(queryModel);
                return BLLHelpler.GetReturnBody<PageResultModel<PrintConfigModel>>(ResCode.SUCCESS, ResMsg.SUCCESS, list);
            }
            catch (Exception ex)
            {
                WipLogHelper.GetExceptionInfoForError(ex, ref exception);
                return BLLHelpler.GetReturnBody<PageResultModel<PrintConfigModel>>(ResCode.FAILURE, ResMsg.FAILURE, exception);
            }
        }
        public string GetPrintConfigList0()
        {
            return "OK";
        }

        #endregion

        #region 获取单个打印配置


        /// <summary> 
        /// 获取单个打印配置 
        /// </summary> 
        /// <param name="model"></param> 
        /// <returns></returns> 
        public ReturnBody<PrintConfigEntity> GetSinglePrintConfig(QueryPrintConfigParam model)
        {
            ExceptionInfoEntity exception = WipLogHelper.GetNewExceptionInfoNoKey<QueryPrintConfigParam>(namespaceName, "GetSinglePrintConfig", model);
            try
            {
                #region 验证
                if (model == null || string.IsNullOrEmpty(model.printType))
                {
                    exception.exceptionMsg = ResMsg.PARAMETERNOEMPTY;
                    return BLLHelpler.GetReturnBody<PrintConfigEntity>(ResCode.PARAMETERNOEMPTY, exception.exceptionMsg, exception);
                }
                #endregion
                var retModel = printConfigBLL.GetModel(model.printType.ToString());
                if (retModel == null)
                {
                    exception.exceptionMsg = "没有找到数据";
                    return BLLHelpler.GetReturnBody<PrintConfigEntity>(ResCode.FAILURE, exception.exceptionMsg, exception);
                }
                return BLLHelpler.GetReturnBody<PrintConfigEntity>(ResCode.SUCCESS, ResMsg.SUCCESS, retModel);
            }
            catch (Exception ex)
            {
                WipLogHelper.GetExceptionInfoForError(ex, ref exception);
                return BLLHelpler.GetReturnBody<PrintConfigEntity>(ResCode.FAILURE, ResMsg.FAILURE, exception);
            }
        }


        public string GetSinglePrintConfig0(QueryPrintConfigParam model)
        {
            return "ok";
        }


        #endregion

        #region 禁启用打印配置表


        /// <summary> 
        /// 禁启用打印配置表 
        /// </summary> 
        /// <param name="model"></param> 
        /// <returns></returns> 
        public ReturnBody<bool> EnablePrintConfig(QueryPrintConfigParam model)
        {
            ExceptionInfoEntity exception = WipLogHelper.GetNewExceptionInfoNoKey<QueryPrintConfigParam>(namespaceName, "EnablePrintConfig", model);
            try
            {
                #region 验证
                if (model == null || string.IsNullOrEmpty(model.printType))
                {
                    exception.exceptionMsg = ResMsg.PARAMETERNOEMPTY;
                    return BLLHelpler.GetReturnBody<bool>(ResCode.PARAMETERNOEMPTY, exception.exceptionMsg, exception);
                }
                #endregion

                string lastModifier = JwtHelp.GetCurUserName();
                var result = printConfigBLL.Enable(model.printType.ToString(), model.delFlag, lastModifier);
                return BLLHelpler.GetReturnBody<bool>(ResCode.SUCCESS, ResMsg.SUCCESS, result);
            }
            catch (Exception ex)
            {
                WipLogHelper.GetExceptionInfoForError(ex, ref exception);
                return BLLHelpler.GetReturnBody<bool>(ResCode.FAILURE, ResMsg.FAILURE, exception);
            }
        }

        public string EnablePrintConfig0()
        {
            return "ok";
        }


        #endregion 
    }
}
