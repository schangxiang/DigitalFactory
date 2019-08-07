using System;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using WIP_Models;
using SysManager.DB.Utilities;

namespace WIP_IDAL
{
    /// <summary> 
    /// 代码集表数据访问类 
    /// </summary> 
    public interface ICodeSetsDAL
    {
        #region Add

        /// <summary> 
        /// 增加一条代码集表数据 
        /// </summary> 
        /// <param name="model">要插入的代码集表实体</param> 
        /// <param name="transModel">事务类</param> 
        /// <returns>插入生成的最新主键值</returns> 
        int Add(CodeSetsEntity model, TransactionModel transModel = null);


        #endregion

        #region Edit

        /// <summary> 
        /// 更新一条代码集表数据 
        /// </summary> 
        /// <param name="model">要更新的代码集表实体</param> 
        /// <param name="transModel">事务类</param> 
        /// <returns>是否更新成功</returns> 
        bool Update(CodeSetsEntity model, TransactionModel transModel = null);


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
        bool Enable(string code, string delFlag, string lastModifier, TransactionModel transModel = null);


        #endregion


        #region QueryList(Page)

        /// <summary> 
        /// 获得代码集表数据列表(分页) 
        /// </summary> 
        /// <param name="strOrderBy">排序字段</param> 
        /// <param name="strWhere">查询条件</param> 
        /// <param name="model">分页实体数据</param> 
        /// <returns>代码集表列表DataSet</returns> 
        DataSet GetListForPage(string strOrderBy, string strWhere, QueryCodeSetsModel model);


        /// <summary> 
        /// 获取代码集表记录总数 
        /// </summary> 
        /// <param name="strWhere">查询条件</param> 
        /// <returns>代码集表记录总数</returns> 
         int GetRecordCount(string strWhere);


        #endregion


        #region Query(Single)

        /// <summary> 
        /// 得到一个代码集表实体 
        /// </summary> 
        /// <param name="code">代码编码</param> 
        /// <returns>代码集表实体</returns> 
        CodeSetsEntity GetModel(string code);

        #endregion

        #region Other

        /// <summary> 
        /// 是否存在该代码集表记录 
        /// </summary> 
        /// <param name="code">代码编码</param> 
        /// <returns>是否存在该代码集表记录</returns> 
        bool Exists(string code, int? id = null);

        #endregion


        #region QueryList

        /// <summary> 
        /// 获得代码集表数据列表 
        /// </summary> 
        /// <param name="strWhere">查询条件</param> 
        /// <returns>代码集表列表DataSet</returns> 
        DataSet GetList();


        #endregion

    }
}


