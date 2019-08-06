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
        private CodeSetsBLL codeSetsBLL = new CodeSetsBLL();

        #region 插入代码集表

        /// <summary> 
        /// 插入代码集表 
        /// </summary> 
        /// <param name="model"></param> 
        /// <returns></returns> 
        public ReturnBody<string> InsertCodeSets(CodeSetsEntity model)
        {
            ReturnBody<string> retBody = null;
            ExceptionInfoEntity exception = WipLogHelper.GetExceptionInfo<CodeSetsEntity>(namespaceName, "InsertCodeSets", model);
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
                     new ColumnsModel(){ ChinaName="代码编码",PropertyName="code" },
                     new ColumnsModel(){ ChinaName="代码名称",PropertyName="name" },
                     new ColumnsModel(){ ChinaName="说明",PropertyName="note" },
                     new ColumnsModel(){ ChinaName="创建时间",PropertyName="createTime",DataType=typeof(DateTime),IsNullable=true },
                     new ColumnsModel(){ ChinaName="修改时间",PropertyName="lastModifyTime",DataType=typeof(DateTime),IsNullable=true },
                };

                ValidateResModel res = ValidateDataHelper.ValidateNullOrEmpty<CodeSetsEntity>(columnsList, model);
                if (res != null && !res.IsValidate)
                {
                    exception.exceptionMsg = res.ValidateMsg;
                    retBody = BLLHelpler.GetReturnBody<string>(ResCode.PARAMETERNOEMPTY, res.ValidateMsg, exception);
                    return retBody;
                }
                //验证重复 
                if (codeSetsBLL.Exists(model.code.ToString()))
                {
                    exception.exceptionMsg = "数据已经存在";
                    retBody = BLLHelpler.GetReturnBody<string>(ResCode.FAILURE, exception.exceptionMsg, exception);
                    return retBody;
                }
                #endregion

                string creator = JwtHelp.GetCurUserName();
                if (codeSetsBLL.Add(model, creator) > 0)
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
        public string InsertCodeSets0(CodeSetsEntity model)
        {
            return "OK";
        }

        #endregion

        #region 更新代码集表

        /// <summary> 
        /// 更新代码集表 
        /// </summary> 
        /// <param name="model"></param> 
        /// <returns></returns> 
        public ReturnBody<string> UpdateCodeSets(CodeSetsEntity model)
        {
            ReturnBody<string> retBody = null;
            ExceptionInfoEntity exception = WipLogHelper.GetExceptionInfo<CodeSetsEntity>(namespaceName, "UpdateCodeSets", model);
            try
            {
                #region 验证
                if (model == null || model.id==0)
                {
                    exception.exceptionMsg = ResMsg.PARAMETERNOEMPTY;
                    retBody = BLLHelpler.GetReturnBody<string>(ResCode.PARAMETERNOEMPTY, exception.exceptionMsg, exception);
                    return retBody;
                }
                List<ColumnsModel> columnsList = new List<ColumnsModel>() { 
                     new ColumnsModel(){ ChinaName="代码编码",PropertyName="code" },
                     new ColumnsModel(){ ChinaName="代码名称",PropertyName="name" },
                     new ColumnsModel(){ ChinaName="说明",PropertyName="note" },
                     new ColumnsModel(){ ChinaName="创建时间",PropertyName="createTime",DataType=typeof(DateTime),IsNullable=true },
                     new ColumnsModel(){ ChinaName="修改时间",PropertyName="lastModifyTime",DataType=typeof(DateTime),IsNullable=true },
                };

                ValidateResModel res = ValidateDataHelper.ValidateNullOrEmpty<CodeSetsEntity>(columnsList, model);
                if (res != null && !res.IsValidate)
                {
                    exception.exceptionMsg = res.ValidateMsg;
                    retBody = BLLHelpler.GetReturnBody<string>(ResCode.PARAMETERNOEMPTY, exception.exceptionMsg, exception);
                    return retBody;
                }
                //验证重复 
                if (codeSetsBLL.Exists(model.code.ToString(),model.id))
                {
                    exception.exceptionMsg = "数据已经存在";
                    retBody = BLLHelpler.GetReturnBody<string>(ResCode.FAILURE, exception.exceptionMsg, exception);
                    return retBody;
                }

                #endregion

                bool result = codeSetsBLL.Update(model);
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
        public string UpdateCodeSets0(CodeSetsEntity model)
        {
            return "OK";
        }

        #endregion

        #region 获取代码集表列表（分页）

        /// <summary> 
        /// 获取代码集表列表（分页） 
        /// </summary> 
        /// <returns></returns> 
        public ReturnBody<PageResultModel<CodeSetsEntity>> GetCodeSetsList(QueryCodeSetsModel queryModel)
        {
            var strOrderBy = " codeSets.lastModifyTime DESC";
            var strWhere = "";
            ExceptionInfoEntity exception = WipLogHelper.GetExceptionInfo<QueryCodeSetsModel>(namespaceName, "GetCodeSetsList", queryModel);
            try
            {
                if (queryModel != null)
                {
                    if (!string.IsNullOrEmpty(queryModel.code))
                    {
                        strWhere += " codeSets.code LIKE '%" + queryModel.code + "%',";
                    }
                    if (!string.IsNullOrEmpty(queryModel.name))
                    {
                        strWhere += " codeSets.name LIKE '%" + queryModel.name + "%',";
                    }
                    if (!string.IsNullOrEmpty(queryModel.delFlag))
                    {
                        strWhere += " codeSets.delFlag ='" + queryModel.delFlag + "',";
                    }
                    if (!string.IsNullOrEmpty(strWhere))
                        strWhere = strWhere.Substring(0, strWhere.Length - 1);

                }
                PageResultModel<CodeSetsEntity> list = codeSetsBLL.GetModelListForPage(strOrderBy, strWhere, queryModel);
                return BLLHelpler.GetReturnBody<PageResultModel<CodeSetsEntity>>(ResCode.SUCCESS, ResMsg.SUCCESS, list);
            }
            catch (Exception ex)
            {
                WipLogHelper.GetExceptionInfoForError(ex, ref exception);
                return BLLHelpler.GetReturnBody<PageResultModel<CodeSetsEntity>>(ResCode.FAILURE, ResMsg.FAILURE, exception);
            }
        }
        public string GetCodeSetsList0()
        {
            return "OK";
        }

        #endregion

        #region 获取代码集表列表

        /// <summary> 
        /// 获取代码集表列表
        /// </summary> 
        /// <returns></returns> 
        public ReturnBody<List<CodeSetsModel>> GetAllCodeSets()
        {
            ExceptionInfoEntity exception = WipLogHelper.GetExceptionInfo<string>(namespaceName, "GetAllCodeSets", "");
            try
            {
                List<CodeSetsModel> list = codeSetsBLL.GetModelList();
                return BLLHelpler.GetReturnBody<List<CodeSetsModel>>(ResCode.SUCCESS, ResMsg.SUCCESS, list);
            }
            catch (Exception ex)
            {
                WipLogHelper.GetExceptionInfoForError(ex, ref exception);
                return BLLHelpler.GetReturnBody<List<CodeSetsModel>>(ResCode.FAILURE, ResMsg.FAILURE, exception);
            }
        }
        public string GetAllCodeSets0()
        {
            return "OK";
        }

        #endregion

        #region 获取单个代码集表


        /// <summary> 
        /// 获取单个代码集表 
        /// </summary> 
        /// <param name="model"></param> 
        /// <returns></returns> 
        public ReturnBody<CodeSetsEntity> GetSingleCodeSets(QueryCodeSetsModel model)
        {
            ExceptionInfoEntity exception = WipLogHelper.GetExceptionInfo<QueryCodeSetsModel>(namespaceName, "GetSingleCodeSets", model);
            try
            {
                #region 验证
                if (model == null || string.IsNullOrEmpty(model.code))
                {
                    exception.exceptionMsg = ResMsg.PARAMETERNOEMPTY;
                    return BLLHelpler.GetReturnBody<CodeSetsEntity>(ResCode.PARAMETERNOEMPTY, exception.exceptionMsg, exception);
                }
                #endregion
                var retModel = codeSetsBLL.GetModel(model.code.ToString());
                if (retModel == null)
                {
                    exception.exceptionMsg = "没有找到数据";
                    return BLLHelpler.GetReturnBody<CodeSetsEntity>(ResCode.FAILURE, exception.exceptionMsg, exception);
                }
                return BLLHelpler.GetReturnBody<CodeSetsEntity>(ResCode.SUCCESS, ResMsg.SUCCESS, retModel);
            }
            catch (Exception ex)
            {
                WipLogHelper.GetExceptionInfoForError(ex, ref exception);
                return BLLHelpler.GetReturnBody<CodeSetsEntity>(ResCode.FAILURE, ResMsg.FAILURE, exception);
            }
        }


        public string GetSingleCodeSets0(QueryCodeSetsModel model)
        {
            return "ok";
        }


        #endregion

        #region 禁启用代码集表


        /// <summary> 
        /// 禁启用代码集表 
        /// </summary> 
        /// <param name="model"></param> 
        /// <returns></returns> 
        public ReturnBody<bool> EnableCodeSets(QueryCodeSetsModel model)
        {
            ExceptionInfoEntity exception = WipLogHelper.GetExceptionInfo<QueryCodeSetsModel>(namespaceName, "EnableCodeSets", model);
            try
            {
                #region 验证
                if (model == null || string.IsNullOrEmpty(model.code))
                {
                    exception.exceptionMsg = ResMsg.PARAMETERNOEMPTY;
                    return BLLHelpler.GetReturnBody<bool>(ResCode.PARAMETERNOEMPTY, exception.exceptionMsg, exception);
                }
                #endregion

                string lastModifier = JwtHelp.GetCurUserName();
                var result = codeSetsBLL.Enable(model.code.ToString(), model.delFlag, lastModifier);
                return BLLHelpler.GetReturnBody<bool>(ResCode.SUCCESS, ResMsg.SUCCESS, result);
            }
            catch (Exception ex)
            {
                WipLogHelper.GetExceptionInfoForError(ex, ref exception);
                return BLLHelpler.GetReturnBody<bool>(ResCode.FAILURE, ResMsg.FAILURE, exception);
            }
        }

        public string EnableCodeSets0()
        {
            return "ok";
        }


        #endregion 
    }
}
