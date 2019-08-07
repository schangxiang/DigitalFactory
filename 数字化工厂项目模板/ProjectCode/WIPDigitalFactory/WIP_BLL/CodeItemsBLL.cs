using System;
using System.Collections.Generic;
using System.Data;
using WIP_common;
using WIP_SQLServerDAL;
using WIP_Models;

namespace WIP_BLL
{
    /// <summary> 
    /// 代码项表业务处理类 
    /// </summary> 
    public partial class CodeItemsBLL
    {
        private readonly CodeItemsDAL codeItemsDAL = new CodeItemsDAL();

        #region Add

        /// <summary> 
        /// 增加一条代码项表数据 
        /// </summary> 
        /// <param name="model"></param> 
        /// <returns>插入的最新主键值</returns> 
        public int Add(CodeItemsEntity model)
        {
            model.createTime = model.lastModifyTime = DateTime.Now;
            model.delFlag = false;
            return codeItemsDAL.Add(model);
        }

        #endregion

        #region Edit

        /// <summary> 
        /// 更新一条代码项表数据 
        /// </summary> 
        /// <param name="model">要更新的代码项表实体</param> 
        /// <returns>是否更新成功</returns> 
        public bool Update(CodeItemsEntity model)
        {
            model.lastModifyTime = DateTime.Now;
            return codeItemsDAL.Update(model);
        }

        #endregion

        #region Del

        /// <summary> 
        /// 删除一条代码项表数据 
        /// </summary> 
        /// <param name="id">主键</param> 
        /// <returns>是否删除成功</returns> 
        public bool Delete(string id)
        {
            return codeItemsDAL.Delete(id);
        }

        #endregion

        #region Enable

        /// <summary> 
        /// 禁启用代码项表数据 
        /// </summary> 
        /// <param name="id">主键</param> 
        /// <param name="delFlag">禁用1/启用0</param> 
        /// <param name="lastModifier">最后修改人</param> 
        /// <param name="transModel">事务类</param> 
        /// <returns>是否禁启用成功</returns> 
        public bool Enable(string id, string delFlag, string lastModifier)
        {
            return codeItemsDAL.Enable(id, delFlag, lastModifier);
        }

        #endregion 

        #region QueryList(Page)

        /// <summary> 
        /// 获得代码项表数据列表(分页) 
        /// </summary> 
        /// <param name="strOrderBy">排序字段</param> 
        /// <param name="strWhere">查询条件</param> 
        /// <param name="model">分页数据</param> 
        /// <returns>代码项表分页数据</returns> 
        public PageResultModel<CodeItemsEntity> GetModelListForPage(string strOrderBy, string strWhere, QueryCodeItemsModel model)
        {
            DataSet ds = codeItemsDAL.GetListForPage(strOrderBy, strWhere, model);
            List<CodeItemsEntity> list = DataTableToList(ds.Tables[0]);
            int total = codeItemsDAL.GetRecordCount(strWhere);
            PageResultModel<CodeItemsEntity> result = new PageResultModel<CodeItemsEntity>();
            result.total = total;
            result.rows = list;
            return result;
        }

        #endregion

        #region Query(Single)

        /// <summary> 
        /// 得到一个代码项表实体 
        /// </summary> 
        /// <param name="id">主键</param> 
        /// <returns>代码项表实体</returns> 
        public CodeItemsEntity GetModel(string setCode, string code)
        {

            return codeItemsDAL.GetModel(setCode, code);
        }

        #endregion

        #region QueryList

        /// <summary> 
        /// 获得代码项表数据列表 
        /// </summary> 
        /// <param name="strWhere">查询条件</param> 
        /// <returns>代码项表数据集合</returns> 
        public List<CodeSetsModel> GetAllModelList(string strWhere)
        {
            DataSet ds = codeItemsDAL.GetList(strWhere);
            return DataTableToListForModelList(ds.Tables[0]);
        }

        private List<CodeSetsModel> DataTableToListForModelList(DataTable dt)
        {
            List<CodeSetsModel> modelList = new List<CodeSetsModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CodeSetsModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new CodeSetsModel();
                    var dataRow = dt.Rows[n];
                    model.code = dataRow["code"].ToString();
                    model.name = dataRow["name"].ToString();
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion 

        #region Other

        /// <summary> 
        /// 是否存在该代码项表记录 
        /// </summary> 
        /// <param name="id">主键</param> 
        /// <returns></returns> 
        public bool Exists(string setCode, string code, int? id = null)
        {
            return codeItemsDAL.Exists(setCode, code, id);
        }

        #endregion

        #region Common

        /// <summary> 
        /// 获得代码项表数据列表 
        /// </summary> 
        private List<CodeItemsEntity> DataTableToList(DataTable dt)
        {
            List<CodeItemsEntity> modelList = new List<CodeItemsEntity>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CodeItemsEntity model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new CodeItemsEntity();
                    var dataRow = dt.Rows[n];

                    if (dataRow["id"].ToString() != "")
                    {
                        model.id = int.Parse(dataRow["id"].ToString());
                    }
                    model.code = dataRow["code"].ToString();
                    model.name = dataRow["name"].ToString();
                    model.setCode = dataRow["setCode"].ToString();
                    model.setCodeName = dataRow["setCodeName"].ToString();
                    model.note = dataRow["note"].ToString();
                    if (dataRow["delFlag"].ToString() != "")
                    {
                        if ((dataRow["delFlag"].ToString() == "1") || (dataRow["delFlag"].ToString().ToLower() == "true"))
                        {
                            model.delFlag = true;
                        }
                        else
                        {
                            model.delFlag = false;
                        }
                    }
                    model.creator = dataRow["creator"].ToString();
                    if (dataRow["createTime"].ToString() != "")
                    {
                        model.createTime = DateTime.Parse(dataRow["createTime"].ToString());
                    }
                    model.lastModifier = dataRow["lastModifier"].ToString();
                    if (dataRow["lastModifyTime"].ToString() != "")
                    {
                        model.lastModifyTime = DateTime.Parse(dataRow["lastModifyTime"].ToString());
                    }



                    modelList.Add(model);
                }
            }
            return modelList;
        }

        #endregion

    }
}
