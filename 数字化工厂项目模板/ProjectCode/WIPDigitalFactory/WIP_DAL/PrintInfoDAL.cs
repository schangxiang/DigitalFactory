using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using WIP_Models;
using Newtonsoft.Json;
using SysManager.DB.Utilities;
using WIP_IDAL;


namespace WIP_SQLServerDAL
{
    public partial class PrintInfoDAL : IPrintInfoDAL
    {

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(PrintInfoEntity model, TransactionModel transModel = null)
        {

            SqlParameter param_id = new SqlParameter();
            param_id.ParameterName = "@id";
            param_id.SqlDbType = SqlDbType.Int;
            param_id.Direction = ParameterDirection.Output;

            SqlParameter[] parameters = { 
              new SqlParameter("@printJson",SqlDbType.NVarChar,-1),
              new SqlParameter("@printFlag",SqlDbType.NChar,1),
              new SqlParameter("@printType",SqlDbType.VarChar,5),
              new SqlParameter("@note",SqlDbType.NVarChar,1000),
              new SqlParameter("@delFlag",SqlDbType.Bit,1),
              new SqlParameter("@creator",SqlDbType.NVarChar,100),
              new SqlParameter("@lastModifier",SqlDbType.NVarChar,100),
              new SqlParameter("@processCardNumber",SqlDbType.NVarChar,50),
              param_id 
            };
            parameters[0].Value = model.printJson;
            parameters[1].Value = model.printFlag;
            parameters[2].Value = model.printType;
            parameters[3].Value = model.note;
            parameters[4].Value = model.delFlag;
            parameters[5].Value = model.creator;
            parameters[6].Value = model.lastModifier;
            parameters[7].Value = model.processCardNumber;

            int rowsAffected;
            if (transModel != null)
            {
                SQLServerHelper.RunProcedure(transModel.conn, transModel.trans, "uspWip_AddPrintInfo", parameters, out rowsAffected);
            }
            else
            {
                SQLServerHelper.RunProcedure("uspWip_AddPrintInfo", parameters, out rowsAffected);
            }
            return (int)parameters[parameters.Length - 1].Value;
        }


        /// <summary>
        /// 获取需要打印的数据列表(Service)
        /// </summary>
        /// <param name="printTypeStr">打印类型集合</param>
        /// <returns></returns>
        public DataSet GetNeedPrintList(string printTypeStr)
        {
            try
            {
                SqlParameter[] parameters = {
                    new SqlParameter("@printTypeStr", SqlDbType.NVarChar,100)
                };
                parameters[0].Value = printTypeStr;
                DataSet ds = SQLServerHelper.RunProcedure("uspWip_GetNeedPrintList", parameters, "mydata");
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 重置打印状态
        /// </summary>
        /// <param name="processCardNumber">流转卡号</param>
        /// <param name="id">打印ID</param>
        /// <returns>处理结果</returns>
        public ProcResultModel RestPrint(string processCardNumber, int id)
        {
            try
            {
                SqlParameter[] parameters = {
                    new SqlParameter("@processCardNumber", SqlDbType.NVarChar,50),
                    new SqlParameter("@id", SqlDbType.Int,-1)
                };
                parameters[0].Value = processCardNumber;
                parameters[1].Value = id;

                ProcResultModel ret = SQLServerHelper.RunProcedureOutParamRetValue("uspWip_ResetPrint", parameters);
                return ret;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 更新打印结果
        /// </summary>
        /// <param name="parameters_UpdatePrintResult"></param>
        /// <param name="transModel"></param>
        /// <returns></returns>
        public int UpdatePrintResult(SqlParameter[] parameters_UpdatePrintResult, TransactionModel transModel)
        {
            int rowsAffected = 0;
            return SQLServerHelper.RunProcedure(transModel.conn, transModel.trans, "uspWip_UpdatePrintResult", parameters_UpdatePrintResult, out rowsAffected);
        }

    }
}

