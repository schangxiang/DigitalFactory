using System;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using WIP_Models;


namespace WIP_DAL
{
    /// <summary> 
    /// 异常信息表数据访问类 
    /// </summary> 
    public partial class ExceptionInfoDAL
    {

        #region 单例模式（饿汉模式）

        private static ExceptionInfoDAL _instance = null;
        private ExceptionInfoDAL() { }
        static ExceptionInfoDAL()
        {
            _instance = new ExceptionInfoDAL();
        }
        public static ExceptionInfoDAL GetInstance()
        {
            return _instance;
        }

        #endregion

        /// <summary> 
        /// 增加一条异常信息表数据 
        /// </summary> 
        /// <param name="model">要插入的异常信息表实体</param> 
        /// <returns>插入生成的最新主键值</returns> 
        public int Add(ExceptionInfoEntity model)
        {
            SqlParameter param_id = new SqlParameter();
            param_id.ParameterName = "@id";
            param_id.SqlDbType = SqlDbType.Int;
            param_id.Direction = ParameterDirection.Output;

            SqlParameter[] parameters = {
              new SqlParameter("@exceptionLevel",SqlDbType.NVarChar,2),
              new SqlParameter("@exceptionSource",SqlDbType.NVarChar,2),
              new SqlParameter("@exceptionFun",SqlDbType.NVarChar,100),
              new SqlParameter("@sourceData",SqlDbType.NVarChar,-1),
              new SqlParameter("@exceptionMsg",SqlDbType.NVarChar,-1),
              new SqlParameter("@exceptionData",SqlDbType.NVarChar,-1),
              new SqlParameter("@creator",SqlDbType.NVarChar,256),
              new SqlParameter("@host",SqlDbType.NVarChar,40),
              param_id
            };
            parameters[0].Value = model.exceptionLevel;
            parameters[1].Value = model.exceptionSource;
            parameters[2].Value = model.exceptionFun;
            parameters[3].Value = model.sourceData;
            parameters[4].Value = model.exceptionMsg;
            parameters[5].Value = model.exceptionData;
            parameters[6].Value = model.creator;
            parameters[7].Value = model.host;


            int rowsAffected;
            DbHelperSQL.RunProcedure("uspWip_AddExceptionInfo", parameters, out rowsAffected);
            return (int)parameters[parameters.Length - 1].Value;
        }


        /// <summary> 
        /// 增加一条异常信息表数据 
        /// </summary> 
        /// <param name="model">要插入的异常信息表实体</param> 
        /// <returns>插入生成的最新主键值</returns> 
        public int AddWithKey(ExceptionInfoEntity model)
        {
            SqlParameter param_id = new SqlParameter();
            param_id.ParameterName = "@id";
            param_id.SqlDbType = SqlDbType.Int;
            param_id.Direction = ParameterDirection.Output;

            SqlParameter[] parameters = {
              new SqlParameter("@exceptionLevel",SqlDbType.NVarChar,2),
              new SqlParameter("@exceptionSource",SqlDbType.NVarChar,2),
              new SqlParameter("@exceptionFun",SqlDbType.NVarChar,100),
              new SqlParameter("@sourceData",SqlDbType.NVarChar,-1),
              new SqlParameter("@exceptionMsg",SqlDbType.NVarChar,-1),
              new SqlParameter("@exceptionData",SqlDbType.NVarChar,-1),
              new SqlParameter("@creator",SqlDbType.NVarChar,256),
              new SqlParameter("@host",SqlDbType.NVarChar,40),
              new SqlParameter("@key1",SqlDbType.NVarChar,100),
              new SqlParameter("@key2",SqlDbType.NVarChar,100),
              param_id
            };
            parameters[0].Value = model.exceptionLevel;
            parameters[1].Value = model.exceptionSource;
            parameters[2].Value = model.exceptionFun;
            parameters[3].Value = model.sourceData;
            parameters[4].Value = model.exceptionMsg;
            parameters[5].Value = model.exceptionData;
            parameters[6].Value = model.creator;
            parameters[7].Value = model.host;
            parameters[8].Value = model.key1;
            parameters[9].Value = model.key2;


            int rowsAffected;
            DbHelperSQL.RunProcedure("uspWip_AddExceptionInfoWithKey", parameters, out rowsAffected);
            return (int)parameters[parameters.Length - 1].Value;
        }

    }
}


