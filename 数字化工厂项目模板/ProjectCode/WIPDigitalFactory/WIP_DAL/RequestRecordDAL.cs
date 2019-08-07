using System;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using WIP_Models;
using SysManager.DB.Utilities;

namespace WIP_SQLServerDAL
{
    /// <summary> 
    /// 请求记录表数据访问类 
    /// </summary> 
    public class RequestRecordDAL
    {
        #region Add

        /// <summary> 
        /// 增加一条请求记录表数据 
        /// </summary> 
        /// <param name="model">要插入的请求记录表实体</param> 
        /// <param name="transModel">事务类</param> 
        /// <returns>插入生成的最新主键值</returns> 
        public void Add(RequestRecordEntity model)
        {
            try
            {
                SqlParameter param_id = new SqlParameter();
                param_id.ParameterName = "@id";
                param_id.SqlDbType = SqlDbType.BigInt;
                param_id.Direction = ParameterDirection.Output;

                SqlParameter[] parameters = { 
              new SqlParameter("@host",SqlDbType.NVarChar,50),
              new SqlParameter("@url",SqlDbType.NVarChar,500),
              new SqlParameter("@param",SqlDbType.NVarChar,-1),
              new SqlParameter("@retResult",SqlDbType.NVarChar,-1),
              new SqlParameter("@remark",SqlDbType.NVarChar,1000),
              new SqlParameter("@fullFun",SqlDbType.NVarChar,100),
              new SqlParameter("@happenHost",SqlDbType.NVarChar,100),
              new SqlParameter("@direction",SqlDbType.Int,-1),
              param_id 
            };
                parameters[0].Value = model.host;
                parameters[1].Value = model.url;
                parameters[2].Value = model.param;
                parameters[3].Value = model.retResult;
                parameters[4].Value = model.remark;
                parameters[5].Value = model.fullFun;
                parameters[6].Value = model.happenHost;
                parameters[7].Value = model.direction;
                int rowsAffected;
                SQLServerHelper.RunProcedure("uspWip_AddRequestRecord", parameters, out rowsAffected);
            }
            catch
            {
            }
        }

        #endregion

        #region AddWithKey

        /// <summary> 
        /// 增加一条请求记录表数据 
        /// </summary> 
        /// <param name="model">要插入的请求记录表实体</param> 
        /// <param name="transModel">事务类</param> 
        /// <returns>插入生成的最新主键值</returns> 
        public void AddWithKey(RequestRecordEntity model)
        {
            try
            {
                SqlParameter param_id = new SqlParameter();
                param_id.ParameterName = "@id";
                param_id.SqlDbType = SqlDbType.BigInt;
                param_id.Direction = ParameterDirection.Output;

                SqlParameter[] parameters = { 
                new SqlParameter("@host",SqlDbType.NVarChar,50),
                new SqlParameter("@url",SqlDbType.NVarChar,500),
                new SqlParameter("@param",SqlDbType.NVarChar,-1),
                new SqlParameter("@retResult",SqlDbType.NVarChar,-1),
                new SqlParameter("@remark",SqlDbType.NVarChar,1000),
                new SqlParameter("@fullFun",SqlDbType.NVarChar,100),
                new SqlParameter("@happenHost",SqlDbType.NVarChar,100),
                new SqlParameter("@direction",SqlDbType.Int,-1),
                new SqlParameter("@key1",SqlDbType.NVarChar,100),
                new SqlParameter("@key2",SqlDbType.NVarChar,100),
                param_id 
            };
                parameters[0].Value = model.host;
                parameters[1].Value = model.url;
                parameters[2].Value = model.param;
                parameters[3].Value = model.retResult;
                parameters[4].Value = model.remark;
                parameters[5].Value = model.fullFun;
                parameters[6].Value = model.happenHost;
                parameters[7].Value = model.direction;
                parameters[8].Value = model.key1;
                parameters[9].Value = model.key2;

                int rowsAffected;
                SQLServerHelper.RunProcedure("uspWip_AddRequestRecordWithKey", parameters, out rowsAffected);
            }
            catch
            {
            }
        }

        #endregion

    }
}


