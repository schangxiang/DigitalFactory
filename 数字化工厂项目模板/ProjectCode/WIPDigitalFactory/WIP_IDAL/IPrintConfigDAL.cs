using System;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using WIP_Models;
using SysManager.DB.Utilities;

namespace WIP_IDAL
{
    /// <summary> 
    /// 打印配置数据访问类 
    /// </summary> 
    public interface IPrintConfigDAL
    {
        #region Add

        /// <summary> 
        /// 增加一条打印配置数据 
        /// </summary> 
        /// <param name="model">要插入的打印配置实体</param> 
        /// <param name="transModel">事务类</param> 
        /// <returns>插入生成的最新主键值</returns> 
        int Add(PrintConfigEntity model, TransactionModel transModel = null);


        #endregion

        #region Edit

        /// <summary> 
        /// 更新一条打印配置数据 
        /// </summary> 
        /// <param name="model">要更新的打印配置实体</param> 
        /// <param name="transModel">事务类</param> 
        /// <returns>是否更新成功</returns> 
        bool Update(PrintConfigEntity model, TransactionModel transModel = null);


        #endregion

        #region Enable

        /// <summary> 
        /// 禁启用打印配置表数据 
        /// </summary> 
        /// <param name="printType">打印类型</param> 
        /// <param name="delFlag">禁用1/启用0</param> 
        /// <param name="lastModifier">最后修改人</param> 
        /// <param name="transModel">事务类</param> 
        /// <returns>是否禁启用成功</returns> 
        bool Enable(string printType, string delFlag, string lastModifier, TransactionModel transModel = null);


        #endregion

        #region QueryList(Page)

        /// <summary> 
        /// 获得打印配置数据列表(分页) 
        /// </summary> 
        /// <param name="strOrderBy">排序字段</param> 
        /// <param name="strWhere">查询条件</param> 
        /// <param name="model">分页实体数据</param> 
        /// <returns>打印配置列表DataSet</returns> 
        DataSet GetListForPage(QueryPrintConfigParam model);


        #endregion

        #region Query(Single)

        /// <summary> 
        /// 得到一个打印配置实体 
        /// </summary> 
        /// <param name="printType">打印类型</param> 
        /// <returns>打印配置实体</returns> 
        PrintConfigEntity GetModel(string printType);

        #endregion

        #region Other

        /// <summary> 
        /// 是否存在该打印配置记录 
        /// </summary> 
        /// <param name="printType">打印类型</param> 
        /// <returns>是否存在该打印配置记录</returns> 
        bool Exists(string printType, int? id = null);


        #endregion

    }
}


