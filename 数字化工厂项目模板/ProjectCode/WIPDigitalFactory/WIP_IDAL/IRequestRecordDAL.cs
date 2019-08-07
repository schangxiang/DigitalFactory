using System;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using WIP_Models;
using SysManager.DB.Utilities;

namespace WIP_IDAL
{
    /// <summary> 
    /// 请求记录表数据访问类 
    /// </summary> 
    public interface IRequestRecordDAL
    {
        #region Add

        /// <summary> 
        /// 增加一条请求记录表数据 
        /// </summary> 
        /// <param name="model">要插入的请求记录表实体</param> 
        /// <param name="transModel">事务类</param> 
        /// <returns>插入生成的最新主键值</returns> 
        void Add(RequestRecordEntity model);


        #endregion

        #region AddWithKey

        /// <summary> 
        /// 增加一条请求记录表数据 
        /// </summary> 
        /// <param name="model">要插入的请求记录表实体</param> 
        /// <param name="transModel">事务类</param> 
        /// <returns>插入生成的最新主键值</returns> 
        void AddWithKey(RequestRecordEntity model);


        #endregion

    }
}


