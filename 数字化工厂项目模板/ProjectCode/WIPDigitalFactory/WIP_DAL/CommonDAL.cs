using SysManager.Common.Utilities;
using SysManager.DB.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using WIP_IDAL;
using WIP_Models;


namespace WIP_SQLServerDAL
{
    public partial class CommonDAL : ICommonDAL
    {

        /// <summary>
        /// 清除数据
        /// </summary>
        /// <param name="procName">存储过程名</param>
        public void ClearData(string procName)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = { };
            SQLServerHelper.RunProcedure(procName, parameters, out rowsAffected, 180);//超时时间是执行3分钟
        }


        /// <summary>
        /// 初始化快照数据
        /// </summary>
        /// <returns></returns>
        public ProcResultModel InitDayReportData(int year, int month, int day, string dayValue)
        {
            SqlParameter[] parameters = {
                  new SqlParameter("@errMsg",SqlDbType.NVarChar,50),
                  new SqlParameter("@year",SqlDbType.Int),
                  new SqlParameter("@month",SqlDbType.Int),
                  new SqlParameter("@day",SqlDbType.Int),
                  new SqlParameter("@dayValue",SqlDbType.NVarChar,10),
            };
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = year;
            parameters[2].Value = month;
            parameters[3].Value = day;
            parameters[4].Value = dayValue;
            ProcResultModel ret = SQLServerHelper.RunProcedureOutParamRetValue("uspWip_InitDayReportData", parameters);
            return ret;
        }


        /// <summary>
        /// 清空表
        /// </summary>
        /// <param name="tableName">要清空的表名</param>
        /// <returns></returns>
        public bool TruncateTable(string tableName)
        {
            string sql = " truncate table " + tableName;
            SQLServerHelper.ExecuteSql(sql);
            return true;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="updateArr">要更新的列集合</param>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public bool UpdateExtend(List<PropertyParam> updateArr, string tableName, TransactionModel transModel = null)
        {
            SqlParam sqlParam = GetStr_UpdateExtend(updateArr, tableName);
            int rows = 0;
            if (transModel != null)
            {
                rows = SQLServerHelper.ExecuteSql(transModel.conn, transModel.trans, sqlParam.StrSql, sqlParam.Parameters);
            }
            else
            {
                rows = SQLServerHelper.ExecuteSql(sqlParam.StrSql, sqlParam.Parameters);
            }
            return rows > 0 ? true : false;
        }

        /// <summary>
        /// 更新一条数据的sql参数
        /// </summary>
        /// <param name="updateArr">要更新的列集合</param>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public SqlParam GetStr_UpdateExtend(List<PropertyParam> updateArr, string tableName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + tableName + " set ");

            PropertyParam param = null;
            List<SqlParameter> ilistStr = new List<SqlParameter>();
            SqlParameter sqlParameter = null;
            List<PropertyParam> whereFileteList = new List<PropertyParam>();
            for (int i = 0; i < updateArr.Count; i++)
            {
                param = updateArr[i];
                if (!param.IsWhereFilter)
                {
                    strSql.Append(" " + param.PropertyName + "=@" + param.PropertyName + " ,");
                    sqlParameter = new SqlParameter("@" + param.PropertyName, param.dbType);
                    if (param.size != null)
                    {
                        sqlParameter.Size = Convert.ToInt32(param.size);
                    }
                    sqlParameter.Value = param.ObjectValue;
                    ilistStr.Add(sqlParameter);
                }
                else
                {
                    whereFileteList.Add(param);
                }
            }
            //单独处理ID列
            var myStr = strSql.ToString().Substring(0, strSql.ToString().Length - 1);
            myStr += " WHERE  ";
            var extend = "_extend";
            if (whereFileteList.Count > 0)
            {
                #region 拼接WHERE

                for (int i = 0; i < whereFileteList.Count; i++)
                {
                    param = whereFileteList[i];
                    if (i == whereFileteList.Count - 1)
                    {
                        if (param.IsWhereFilterExtend)
                        {
                            myStr += string.Format("  {0}=@{1};", param.PropertyName, param.PropertyName + extend);
                        }
                        else
                        {
                            myStr += string.Format("  {0}=@{1};", param.PropertyName, param.PropertyName);
                        }
                    }
                    else
                    {
                        if (param.IsWhereFilterExtend)
                        {
                            myStr += string.Format("  {0}=@{1} AND", param.PropertyName, param.PropertyName + extend);
                        }
                        else
                        {
                            myStr += string.Format("  {0}=@{1} AND", param.PropertyName, param.PropertyName);
                        }
                    }

                    SqlParameter param_ID = null;
                    if (param.IsWhereFilterExtend)
                    {
                        param_ID = new SqlParameter("@" + param.PropertyName + extend, param.dbType);
                    }
                    else
                    {
                        param_ID = new SqlParameter("@" + param.PropertyName, param.dbType);
                    }
                    if (param.size != null)
                    {
                        param_ID.Size = Convert.ToInt32(param.size);
                    }
                    param_ID.Value = param.ObjectValue;
                    ilistStr.Add(param_ID);
                }

                #endregion
            }
            else
            {
                myStr += " 1=1 ";
            }


            SqlParameter[] parameters = ilistStr.ToArray();

            SqlParam sqlParam = new SqlParam()
            {
                StrSql = myStr.ToString(),
                Parameters = parameters
            };
            return sqlParam;
        }

        /// <summary>
        /// 删除数据的sql参数
        /// </summary>
        /// <param name="tableName">要删除的表名</param>
        /// <param name="delName">要删除关联的表字段名</param>
        /// <param name="rowId">要删除的关联id</param>
        /// <returns></returns>
        public SqlParam GetStr_DeleteExtend(string tableName, string delName, int rowId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" UPDATE " + tableName + " SET ");
            strSql.Append(" DELFLAG=1 ");
            strSql.Append(" WHERE " + delName + "=" + rowId.ToString());
            SqlParam sqlParam = new SqlParam()
            {
                StrSql = strSql.ToString(),
                Parameters = null
            };
            return sqlParam;
        }

        /// <summary>
        /// 事务执行
        /// </summary>
        /// <param name="sqlParamList"></param>
        public void ExecuteSqlTranList(List<SqlParam> sqlParamList)
        {
            List<Dictionary<string, object>> ListDic = new List<Dictionary<string, object>>();
            Dictionary<string, object> dicstr = null;
            foreach (var item in sqlParamList)
            {
                dicstr = new Dictionary<string, object>();
                dicstr.Add(item.StrSql, item.Parameters);
                ListDic.Add(dicstr);
            }
            SQLServerHelper.ExecuteSqlTranList(ListDic);//事务执行
        }


        /// <summary>
        /// 生成顺序号
        /// </summary>
        /// <param name="serialNoType"></param>
        /// <returns></returns>
        public string GetSerialNo(SerialNoType serialNoType)
        {
            try
            {
                SqlParameter[] parameters = { 
                    new SqlParameter("@type",SqlDbType.Char,2)
                };
                parameters[0].Value = Convert.ToInt32(serialNoType).ToString();

                ProcResultModel ret = SQLServerHelper.RunProcedureOutParamRetValue("uspWip_GetSerialNoProduce", parameters);
                if (ret.execResult > 0)
                {
                    return ret.execResult.ToString();
                }
                throw new Exception("生成顺序号错误");
            }
            catch
            {
                throw;
            }
        }


        #region 查找 MaterialCode(下发排产任务使用)

        /// <summary>
        /// 查找 MaterialCode(下发排产任务使用)
        /// </summary>
        /// <param name="partNumber">零件号</param>
        /// <param name="heatingOutCode">出热物料号</param>
        /// <param name="quantity">数量</param>
        /// <returns>进热物料号(即MaterialCode)</returns>
        public string GetMaterialCodeForIssueTask(string partNumber, string heatingOutCode, int quantity)
        {
            string materialCode = "";
            SqlParameter[] parameters = { 
               new SqlParameter("@partNumber", SqlDbType.VarChar,50),
               new SqlParameter("@heatingOutCode", SqlDbType.VarChar,50),
               new SqlParameter("@quantity", SqlDbType.Int,-1) 
            };
            parameters[0].Value = partNumber.ToString();
            parameters[1].Value = heatingOutCode.ToString();
            parameters[2].Value = quantity;

            DataSet ds = SQLServerHelper.RunProcedure("uspWip_GetMaterialCodeForIssueTask", parameters, "pagetable");
            int count = ds.Tables[0].Rows.Count;
            if (count > 0)
            {
                var dataRow = ds.Tables[0].Rows[0];
                materialCode = dataRow["materialCode"].ToString();
            }
            else
            {
                throw new Exception("根据零件号:" + partNumber.ToString()
                    + ",出热物料号:" + heatingOutCode
                    + ",数量:" + quantity.ToString() +
                    "查找物料编码的条数为" + count.ToString());
            }
            return materialCode;


            //*/
        }


        #endregion


        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        public List<UserInfoLogon> GetUserAccountView()
        {
            try
            {
                string sql = " SELECT LoginName as Name FROM UserAccountView ";
                DataSet ds = SQLServerHelper.Query(sql);
                return DataTableToListForGetPersonnelGroupViewt(ds.Tables[0]);
            }
            catch
            {
                throw;
            }
        }

        private List<UserInfoLogon> DataTableToListForGetPersonnelGroupViewt(DataTable dt)
        {
            List<UserInfoLogon> modelList = new List<UserInfoLogon>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                UserInfoLogon model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new UserInfoLogon();
                    model.Name = dt.Rows[n]["Name"].ToString();
                    modelList.Add(model);
                }
            }
            return modelList;
        }



        #region 获取邮箱基础数据配置

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        public List<MailBaseData> GetMailBaseData()
        {
            try
            {
                string sql = " SELECT mailAddress,mailDisplayName,mailHost,mailPort,mailPwd FROM udtWip_MailBaseData ";
                DataSet ds = SQLServerHelper.Query(sql);
                return DataTableToListForGetMailBaseData(ds.Tables[0]);
            }
            catch
            {
                throw;
            }
        }

        private List<MailBaseData> DataTableToListForGetMailBaseData(DataTable dt)
        {
            List<MailBaseData> modelList = new List<MailBaseData>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                MailBaseData model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new MailBaseData();
                    model.mailAddress = dt.Rows[n]["mailAddress"].ToString();
                    model.mailDisplayName = dt.Rows[n]["mailDisplayName"].ToString();
                    model.mailHost = dt.Rows[n]["mailHost"].ToString();
                    model.mailPort = Convert.ToInt32(dt.Rows[n]["mailPort"].ToString());
                    model.mailPwd = dt.Rows[n]["mailPwd"].ToString();
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        #endregion
    }
}
