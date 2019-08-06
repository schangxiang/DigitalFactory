using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WIP_BLL;
using WIP_common;
using WIP_Models;

namespace WIP_BasicInfo
{
    public partial class BasicInfo
    {
        private CodeItemsBLL codeItemsBLL = new CodeItemsBLL();

        #region 插入代码项表

        /// <summary> 
        /// 插入代码项表 
        /// </summary> 
        /// <param name="model"></param> 
        /// <returns></returns> 
        public ReturnBody<string> InsertCodeItems(CodeItemsEntity model)
        {
            ReturnBody<string> retBody = null;
            ExceptionInfoEntity exception = WipLogHelper.GetExceptionInfo<CodeItemsEntity>(namespaceName, "InsertCodeItems", model);
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
                     new ColumnsModel(){ ChinaName="代码项编码",PropertyName="code" },
                     new ColumnsModel(){ ChinaName="代码项名称",PropertyName="name" },
                     new ColumnsModel(){ ChinaName="代码编码",PropertyName="setCode" },
                     new ColumnsModel(){ ChinaName="说明",PropertyName="note" },
                     new ColumnsModel(){ ChinaName="创建时间",PropertyName="createTime",DataType=typeof(DateTime),IsNullable=true },
                     new ColumnsModel(){ ChinaName="修改时间",PropertyName="lastModifyTime",DataType=typeof(DateTime),IsNullable=true },
                };

                ValidateResModel res = ValidateDataHelper.ValidateNullOrEmpty<CodeItemsEntity>(columnsList, model);
                if (res != null && !res.IsValidate)
                {
                    exception.exceptionMsg = res.ValidateMsg;
                    retBody = BLLHelpler.GetReturnBody<string>(ResCode.PARAMETERNOEMPTY, res.ValidateMsg, exception);
                    return retBody;
                }
                //验证重复 
                if (codeItemsBLL.Exists(model.setCode, model.code))
                {
                    exception.exceptionMsg = "数据已经存在";
                    retBody = BLLHelpler.GetReturnBody<string>(ResCode.FAILURE, exception.exceptionMsg, exception);
                    return retBody;
                }
                #endregion

                model.delFlag = false;
                model.createTime = model.lastModifyTime = DateTime.Now;

                if (codeItemsBLL.Add(model) > 0)
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
        public string InsertCodeItems0(CodeItemsEntity model)
        {
            return "OK";
        }

        #endregion

        #region 更新代码项表

        /// <summary> 
        /// 更新代码项表 
        /// </summary> 
        /// <param name="model"></param> 
        /// <returns></returns> 
        public ReturnBody<string> UpdateCodeItems(CodeItemsEntity model)
        {
            ReturnBody<string> retBody = null;
            ExceptionInfoEntity exception = WipLogHelper.GetExceptionInfo<CodeItemsEntity>(namespaceName, "UpdateCodeItems", model);
            try
            {
                #region 验证
                if (model == null || model.id == 0)
                {
                    exception.exceptionMsg = ResMsg.PARAMETERNOEMPTY;
                    retBody = BLLHelpler.GetReturnBody<string>(ResCode.PARAMETERNOEMPTY, exception.exceptionMsg, exception);
                    return retBody;
                }
                List<ColumnsModel> columnsList = new List<ColumnsModel>() { 
                     new ColumnsModel(){ ChinaName="代码项编码",PropertyName="code" },
                     new ColumnsModel(){ ChinaName="代码项名称",PropertyName="name" },
                     new ColumnsModel(){ ChinaName="代码编码",PropertyName="setCode" },
                     new ColumnsModel(){ ChinaName="说明",PropertyName="note" },
                     new ColumnsModel(){ ChinaName="创建时间",PropertyName="createTime",DataType=typeof(DateTime),IsNullable=true },
                     new ColumnsModel(){ ChinaName="修改时间",PropertyName="lastModifyTime",DataType=typeof(DateTime),IsNullable=true },
                };

                ValidateResModel res = ValidateDataHelper.ValidateNullOrEmpty<CodeItemsEntity>(columnsList, model);
                if (res != null && !res.IsValidate)
                {
                    exception.exceptionMsg = res.ValidateMsg;
                    retBody = BLLHelpler.GetReturnBody<string>(ResCode.PARAMETERNOEMPTY, exception.exceptionMsg, exception);
                    return retBody;
                }
                //验证重复 
                if (codeItemsBLL.Exists(model.setCode, model.code, model.id))
                {
                    exception.exceptionMsg = "数据已经存在";
                    retBody = BLLHelpler.GetReturnBody<string>(ResCode.FAILURE, exception.exceptionMsg, exception);
                    return retBody;
                }

                #endregion

                bool result = codeItemsBLL.Update(model);
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
        public string UpdateCodeItems0(CodeItemsEntity model)
        {
            return "OK";
        }

        #endregion

        #region 获取代码项表列表（分页）

        /// <summary> 
        /// 获取代码项表列表（分页） 
        /// </summary> 
        /// <returns></returns> 
        public ReturnBody<PageResultModel<CodeItemsEntity>> GetCodeItemsList(QueryCodeItemsModel queryModel)
        {
            var strOrderBy = " codeItems.lastModifyTime DESC";
            var strWhere = "";
            ExceptionInfoEntity exception = WipLogHelper.GetExceptionInfo<QueryCodeItemsModel>(namespaceName, "GetCodeItemsList", queryModel);
            try
            {
                if (queryModel != null)
                {
                    if (!string.IsNullOrEmpty(queryModel.code))
                    {
                        strWhere += " codeItems.code LIKE '%" + queryModel.code + "%',";
                    }
                    if (!string.IsNullOrEmpty(queryModel.name))
                    {
                        strWhere += " codeItems.name LIKE '%" + queryModel.name + "%',";
                    }
                    if (!string.IsNullOrEmpty(queryModel.setCode))
                    {
                        strWhere += " codeItems.setCode LIKE '%" + queryModel.setCode + "%',";
                    }
                    if (!string.IsNullOrEmpty(queryModel.delFlag))
                    {
                        strWhere += " codeItems.delFlag ='" + queryModel.delFlag + "',";
                    }
                    if (!string.IsNullOrEmpty(strWhere))
                        strWhere = strWhere.Substring(0, strWhere.Length - 1);

                }
                PageResultModel<CodeItemsEntity> list = codeItemsBLL.GetModelListForPage(strOrderBy, strWhere, queryModel);
                return BLLHelpler.GetReturnBody<PageResultModel<CodeItemsEntity>>(ResCode.SUCCESS, ResMsg.SUCCESS, list);
            }
            catch (Exception ex)
            {
                WipLogHelper.GetExceptionInfoForError(ex, ref exception);
                return BLLHelpler.GetReturnBody<PageResultModel<CodeItemsEntity>>(ResCode.FAILURE, ResMsg.FAILURE, exception);
            }
        }
        public string GetCodeItemsList0()
        {
            return "OK";
        }

        #endregion

        #region 获取单个代码项表


        /// <summary> 
        /// 获取单个代码项表 
        /// </summary> 
        /// <param name="model"></param> 
        /// <returns></returns> 
        public ReturnBody<CodeItemsEntity> GetSingleCodeItems(QueryCodeItemsModel model)
        {
            ExceptionInfoEntity exception = WipLogHelper.GetExceptionInfo<QueryCodeItemsModel>(namespaceName, "GetSingleCodeItems", model);
            try
            {
                #region 验证
                if (model == null || string.IsNullOrEmpty(model.setCode) || string.IsNullOrEmpty(model.code))
                {
                    exception.exceptionMsg = ResMsg.PARAMETERNOEMPTY;
                    return BLLHelpler.GetReturnBody<CodeItemsEntity>(ResCode.PARAMETERNOEMPTY, exception.exceptionMsg, exception);
                }
                #endregion
                var retModel = codeItemsBLL.GetModel(model.setCode, model.code);
                if (retModel == null)
                {
                    exception.exceptionMsg = "没有找到数据";
                    return BLLHelpler.GetReturnBody<CodeItemsEntity>(ResCode.FAILURE, exception.exceptionMsg, exception);
                }
                return BLLHelpler.GetReturnBody<CodeItemsEntity>(ResCode.SUCCESS, ResMsg.SUCCESS, retModel);
            }
            catch (Exception ex)
            {
                WipLogHelper.GetExceptionInfoForError(ex, ref exception);
                return BLLHelpler.GetReturnBody<CodeItemsEntity>(ResCode.FAILURE, ResMsg.FAILURE, exception);
            }
        }


        public string GetSingleCodeItems0(QueryCodeItemsModel model)
        {
            return "ok";
        }


        #endregion

        #region 删除代码项表


        /// <summary> 
        /// 删除代码项表 
        /// </summary> 
        /// <param name="model"></param> 
        /// <returns></returns> 
        public ReturnBody<bool> EnableCodeItems(QueryCodeItemsModel model)
        {
            ExceptionInfoEntity exception = WipLogHelper.GetExceptionInfo<QueryCodeItemsModel>(namespaceName, "DelCodeItems", model);
            try
            {
                #region 验证
                if (model == null || model.id == 0)
                {
                    exception.exceptionMsg = ResMsg.PARAMETERNOEMPTY;
                    return BLLHelpler.GetReturnBody<bool>(ResCode.PARAMETERNOEMPTY, exception.exceptionMsg, exception);
                }
                #endregion
                var result = codeItemsBLL.Enable(model.id.ToString(), model.delFlag, JwtHelp.GetCurUserName());
                return BLLHelpler.GetReturnBody<bool>(ResCode.SUCCESS, ResMsg.SUCCESS, result);
            }
            catch (Exception ex)
            {
                WipLogHelper.GetExceptionInfoForError(ex, ref exception);
                return BLLHelpler.GetReturnBody<bool>(ResCode.FAILURE, ResMsg.FAILURE, exception);
            }
        }


        public string EnableCodeItems0(QueryCodeItemsModel model)
        {
            return "ok";
        }


        #endregion

        #region 获取指定代码集的代码项表列表

        /// <summary> 
        /// 获取指定代码集的代码项表列表
        /// </summary> 
        /// <returns></returns> 
        public ReturnBody<List<CodeSetsModel>> GetAllCodeItemsByCodeSet(GetAllCodeItemsByCodeSetParam param)
        {
            ExceptionInfoEntity exception = WipLogHelper.GetExceptionInfo<GetAllCodeItemsByCodeSetParam>(namespaceName, "GetAllCodeItemsByCodeSet", param);
            try
            {
                string strWhere = " codeItems.setCode='" + param .codeSet+ "' ";
                List<CodeSetsModel> list = codeItemsBLL.GetAllModelList(strWhere);
                return BLLHelpler.GetReturnBody<List<CodeSetsModel>>(ResCode.SUCCESS, ResMsg.SUCCESS, list);
            }
            catch (Exception ex)
            {
                WipLogHelper.GetExceptionInfoForError(ex, ref exception);
                return BLLHelpler.GetReturnBody<List<CodeSetsModel>>(ResCode.FAILURE, ResMsg.FAILURE, exception);
            }
        }
        public string GetAllCodeItemsByCodeSet0()
        {
            return "OK";
        }

        #endregion
    }
}
