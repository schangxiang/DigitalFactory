using System;
using System.Collections.Generic;
using System.Data;
using WIP_common;
using WIP_SQLServerDAL;
using WIP_Models;

namespace WIP_BLL
{
    /// <summary> 
    /// 代码集表业务处理类 
    /// </summary> 
    public partial class CodeSetsBLL
    {
        private readonly CodeSetsDAL codeSetsDAL = new CodeSetsDAL();

        #region Add

        /// <summary> 
        /// 增加一条代码集表数据 
        /// </summary> 
        /// <param name="model"></param> 
        /// <returns>插入的最新主键值</returns> 
        public int Add(CodeSetsEntity model, string creator)
        {
            model.creator = model.lastModifier = creator;
            model.createTime = model.lastModifyTime = DateTime.Now;
            model.delFlag = false; 
            return codeSetsDAL.Add(model);
        }

        #endregion

        #region Edit

        /// <summary> 
        /// 更新一条代码集表数据 
        /// </summary> 
        /// <param name="model">要更新的代码集表实体</param> 
        /// <returns>是否更新成功</returns> 
        public bool Update(CodeSetsEntity model)
        {
            model.lastModifyTime = DateTime.Now;
            return codeSetsDAL.Update(model);
        }

        #endregion

        #region Enable

        /// <summary> 
        /// 禁启用代码集表数据 
        /// </summary> 
        /// <param name="code">代码编码</param> 
        /// <param name="delFlag">禁用/启用</param> 
        /// <param name="lastModifier">最后修改人</param> 
        /// <param name="transModel">事务类</param> 
        /// <returns>是否禁启用成功</returns> 
        public bool Enable(string code, string delFlag, string lastModifier)
        {
            return codeSetsDAL.Enable(code, delFlag, lastModifier);
        }

        #endregion 

        #region QueryList(Page)

        /// <summary> 
        /// 获得代码集表数据列表(分页) 
        /// </summary> 
        /// <param name="strOrderBy">排序字段</param> 
        /// <param name="strWhere">查询条件</param> 
        /// <param name="model">分页数据</param> 
        /// <returns>代码集表分页数据</returns> 
        public PageResultModel<CodeSetsEntity> GetModelListForPage(string strOrderBy, string strWhere, QueryCodeSetsModel model)
        {
            DataSet ds = codeSetsDAL.GetListForPage(strOrderBy, strWhere, model);
            List<CodeSetsEntity> list = DataTableToList(ds.Tables[0]);
            int total = codeSetsDAL.GetRecordCount(strWhere);
            PageResultModel<CodeSetsEntity> result = new PageResultModel<CodeSetsEntity>();
            result.total = total;
            result.rows = list;
            return result;
        }

        #endregion

        #region Query(Single)

        /// <summary> 
        /// 得到一个代码集表实体 
        /// </summary> 
        /// <param name="code">代码编码</param> 
        /// <returns>代码集表实体</returns> 
        public CodeSetsEntity GetModel(string code)
        {

            return codeSetsDAL.GetModel(code);
        }

        #endregion

        #region Other

        /// <summary> 
        /// 是否存在该代码集表记录 
        /// </summary> 
        /// <param name="code">代码编码</param> 
        /// <returns></returns> 
        public bool Exists(string code, int? id = null)
        {
            return codeSetsDAL.Exists(code, id);
        }

        #endregion

        #region Common

        /// <summary> 
        /// 获得代码集表数据列表 
        /// </summary> 
        private List<CodeSetsEntity> DataTableToList(DataTable dt)
        {
            List<CodeSetsEntity> modelList = new List<CodeSetsEntity>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                CodeSetsEntity model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new CodeSetsEntity();
                    var dataRow = dt.Rows[n];

                    if (dataRow["id"].ToString() != "")
                    {
                        model.id = int.Parse(dataRow["id"].ToString());
                    }
                    model.code = dataRow["code"].ToString();
                    model.name = dataRow["name"].ToString();
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


        /// <summary> 
        /// 获得代码集表数据列表 
        /// </summary> 
        private List<CodeSetsModel> DataTableToListForAll(DataTable dt)
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

        #region QueryList

        /// <summary> 
        /// 获得代码集表数据列表 
        /// </summary> 
        /// <param name="strWhere">查询条件</param> 
        /// <returns>代码集表数据集合</returns> 
        public List<CodeSetsModel> GetModelList()
        {
            DataSet ds = codeSetsDAL.GetList();
            return DataTableToListForAll(ds.Tables[0]);
        }

        #endregion

    }
}
