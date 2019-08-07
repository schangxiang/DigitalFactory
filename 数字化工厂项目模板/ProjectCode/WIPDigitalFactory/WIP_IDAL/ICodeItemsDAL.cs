using System;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using WIP_Models;
using SysManager.DB.Utilities;

namespace WIP_IDAL
{
    /// <summary> 
    /// 代码项表数据访问类 
    /// </summary> 
    public interface ICodeItemsDAL
    {
        #region Add

        /// <summary> 
        /// 增加一条代码项表数据 
        /// </summary> 
        /// <param name="model">要插入的代码项表实体</param> 
        /// <param name="transModel">事务类</param> 
        /// <returns>插入生成的最新主键值</returns> 
        int Add(CodeItemsEntity model, TransactionModel transModel = null);


        #endregion

        #region Edit

        /// <summary> 
        /// 更新一条代码项表数据 
        /// </summary> 
        /// <param name="model">要更新的代码项表实体</param> 
        /// <param name="transModel">事务类</param> 
        /// <returns>是否更新成功</returns> 
        bool Update(CodeItemsEntity model, TransactionModel transModel = null);


        #endregion

        #region Del

        /// <summary> 
        /// 删除一条代码项表数据 
        /// </summary> 
        /// <param name="id">主键</param> 
        /// <param name="transModel">事务类</param> 
        /// <returns>是否删除成功</returns> 
        bool Delete(string id, TransactionModel transModel = null);

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
        bool Enable(string id, string delFlag, string lastModifier, TransactionModel transModel = null);

        #endregion


        #region QueryList(Page)

        /// <summary> 
        /// 获得代码项表数据列表(分页) 
        /// </summary> 
        /// <param name="strOrderBy">排序字段</param> 
        /// <param name="strWhere">查询条件</param> 
        /// <param name="model">分页实体数据</param> 
        /// <returns>代码项表列表DataSet</returns> 
        DataSet GetListForPage(string strOrderBy, string strWhere, QueryCodeItemsModel model);

        /// <summary> 
        /// 获取代码项表记录总数 
        /// </summary> 
        /// <param name="strWhere">查询条件</param> 
        /// <returns>代码项表记录总数</returns> 
        int GetRecordCount(string strWhere);

        #endregion

        #region Query(Single)

        /// <summary> 
        /// 得到一个代码项表实体 
        /// </summary> 
        /// <param name="id">主键</param> 
        /// <returns>代码项表实体</returns> 
        CodeItemsEntity GetModel(string setCode, string code);


        #endregion

        #region QueryList

        /// <summary> 
        /// 获得代码项表数据列表 
        /// </summary> 
        /// <param name="strWhere">查询条件</param> 
        /// <returns>代码项表列表DataSet</returns> 
        DataSet GetList(string strWhere);


        #endregion

        #region Other

        /// <summary> 
        /// 是否存在该代码项表记录 
        /// </summary> 
        /// <param name="id">主键</param> 
        /// <returns>是否存在该代码项表记录</returns> 
        bool Exists(string setCode, string code, int? id = null);


        #endregion

    }
}


