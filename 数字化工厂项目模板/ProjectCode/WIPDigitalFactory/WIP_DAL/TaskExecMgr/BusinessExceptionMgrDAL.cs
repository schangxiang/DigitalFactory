using System;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using WIP_Models;

namespace WIP_DAL
{
    /// <summary> 
    /// 业务异常管理数据访问类 
    /// </summary> 
    public class BusinessExceptionMgrDAL
    {
        #region 单例模式（饿汉模式）

        private static BusinessExceptionMgrDAL _instance = null;
        private BusinessExceptionMgrDAL() { }
        static BusinessExceptionMgrDAL()
        {
            _instance = new BusinessExceptionMgrDAL();
        }
        public static BusinessExceptionMgrDAL GetInstance()
        {
            return _instance;
        }

        #endregion

        #region Add最新版本

        /// <summary> 
        /// 增加一条业务异常管理数据 
        /// </summary> 
        /// <param name="model">要插入的业务异常管理实体</param> 
        /// <param name="transModel">事务类</param> 
        /// <returns>插入生成的最新主键值</returns> 
        public int AddByLastVersion(BusinessExceptionMgrEntity model, TransactionModel transModel = null)
        {
            SqlParameter param_id = new SqlParameter();
            param_id.ParameterName = "@id";
            param_id.SqlDbType = SqlDbType.Int;
            param_id.Direction = ParameterDirection.Output;

            SqlParameter[] parameters = { 
              new SqlParameter("@taskNo",SqlDbType.NVarChar,50),
              new SqlParameter("@taskType",SqlDbType.NVarChar,16),
              new SqlParameter("@processCardNumber",SqlDbType.NVarChar,64),
              new SqlParameter("@sysCode",SqlDbType.NVarChar,16),
              new SqlParameter("@exceptionCode",SqlDbType.NVarChar,20),
              new SqlParameter("@exceptionMsg",SqlDbType.NVarChar,500),
              new SqlParameter("@qaStatus",SqlDbType.NVarChar,16),
              new SqlParameter("@materialStatus",SqlDbType.NVarChar,16),
              new SqlParameter("@materialCode",SqlDbType.NVarChar,64),
              new SqlParameter("@partName",SqlDbType.NVarChar,128),
              new SqlParameter("@partNumber",SqlDbType.NVarChar,64),
              new SqlParameter("@quantity",SqlDbType.Int,4),
              new SqlParameter("@disposeResult",SqlDbType.NVarChar,200),
              new SqlParameter("@disposeStatus",SqlDbType.NChar,1),
              new SqlParameter("@disposeNote",SqlDbType.NVarChar,200),
              new SqlParameter("@timestamp",SqlDbType.DateTime),
              new SqlParameter("@host",SqlDbType.NVarChar,40),
              new SqlParameter("@delFlag",SqlDbType.Bit,1),
              new SqlParameter("@creator",SqlDbType.NVarChar,100),
              new SqlParameter("@createTime",SqlDbType.DateTime),
              new SqlParameter("@lastModifier",SqlDbType.NVarChar,100),
              new SqlParameter("@lastModifyTime",SqlDbType.DateTime),
              new SqlParameter("@line",SqlDbType.NVarChar,50),
              param_id 
            };
            parameters[0].Value = model.taskNo;
            parameters[1].Value = model.taskType;
            parameters[2].Value = model.processCardNumber;
            parameters[3].Value = model.sysCode;
            parameters[4].Value = model.exceptionCode;
            parameters[5].Value = model.exceptionMsg;
            parameters[6].Value = model.qaStatus;
            parameters[7].Value = model.materialStatus;
            parameters[8].Value = model.materialCode;
            parameters[9].Value = model.partName;
            parameters[10].Value = model.partNumber;
            parameters[11].Value = model.quantity;
            parameters[12].Value = model.disposeResult;
            parameters[13].Value = model.disposeStatus;
            parameters[14].Value = model.disposeNote;
            parameters[15].Value = model._timestamp;
            parameters[16].Value = model.host;
            parameters[17].Value = model.delFlag;
            parameters[18].Value = model.creator;
            parameters[19].Value = model.createTime;
            parameters[20].Value = model.lastModifier;
            parameters[21].Value = model.lastModifyTime;
            parameters[22].Value = model.line;

            int rowsAffected;
            string procName = "uspWip_AddBusinessExceptionMgrByLastVersion";
            if (transModel != null)
            {
                DbHelperSQL.RunProcedure(transModel.conn, transModel.trans, procName, parameters, out rowsAffected);
            }
            else
            {
                DbHelperSQL.RunProcedure(procName, parameters, out rowsAffected);
            }
            return (int)parameters[parameters.Length - 1].Value;
        }

        #endregion

        #region 更新业务异常信息为已处理

        /// <summary> 
        /// 更新业务异常信息为已处理 
        /// </summary> 
        /// <param name="model">要更新的业务异常管理实体</param> 
        /// <param name="transModel">事务类</param> 
        /// <returns>是否更新成功</returns> 
        public bool UpdateToHasDo(BusinessExceptionMgrEntity model)
        {
            SqlParameter[] parameters = { 
              new SqlParameter("@id",SqlDbType.Int,4),
              new SqlParameter("@lastModifier",SqlDbType.NVarChar,200),
              new SqlParameter("@disposeResult",SqlDbType.NVarChar,200),
              new SqlParameter("@disposeNote",SqlDbType.NVarChar,200),
              new SqlParameter("@disposeStatus",SqlDbType.NVarChar,10)
            };
            parameters[0].Value = model.id;
            parameters[1].Value = model.lastModifier;
            parameters[2].Value = model.disposeResult;
            parameters[3].Value = model.disposeNote;
            parameters[4].Value = model.disposeStatus;


            int rowsAffected = 0;
            DbHelperSQL.RunProcedure("uspWip_UpdateBusinessExceptionMgr", parameters, out rowsAffected);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region QueryList(Page)

        /// <summary> 
        /// 获得业务异常管理数据列表(分页) 
        /// </summary> 
        /// <param name="strOrderBy">排序字段</param> 
        /// <param name="strWhere">查询条件</param> 
        /// <param name="model">分页实体数据</param> 
        /// <returns>业务异常管理列表DataSet</returns> 
        public DataSet GetListForPage(string strOrderBy, string strWhere, QueryBusinessExceptionMgrModel model)
        {
            SqlParameter[] parameters = { 
                        new SqlParameter("@strOrderBy", SqlDbType.NVarChar,50) , 
                        new SqlParameter("@strWhere", SqlDbType.NVarChar,500) , 
                        new SqlParameter("@pageIndex", SqlDbType.Int) , 
                        new SqlParameter("@pageSize", SqlDbType.Int) , 
            };

            parameters[0].Value = strOrderBy;
            parameters[1].Value = strWhere;
            parameters[2].Value = model.pageIndex;
            parameters[3].Value = model.pageSize;
            return DbHelperSQL.RunProcedure("uspWip_GetBusinessExceptionMgrPageList", parameters, "pagetable");
        }

        #endregion

    }
}


