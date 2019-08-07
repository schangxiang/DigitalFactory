using System;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using WIP_Models;
using SysManager.DB.Utilities;

namespace WIP_SQLServerDAL
{
    /// <summary> 
    /// 打印配置数据访问类 
    /// </summary> 
    public partial class PrintConfigDAL
    {
        #region Add

        /// <summary> 
        /// 增加一条打印配置数据 
        /// </summary> 
        /// <param name="model">要插入的打印配置实体</param> 
        /// <param name="transModel">事务类</param> 
        /// <returns>插入生成的最新主键值</returns> 
        public int Add(PrintConfigEntity model, TransactionModel transModel = null)
        {
            SqlParameter param_id = new SqlParameter();
            param_id.ParameterName = "@id";
            param_id.SqlDbType = SqlDbType.Int;
            param_id.Direction = ParameterDirection.Output;

            SqlParameter[] parameters = { 
              new SqlParameter("@printType",SqlDbType.NChar,3),
              new SqlParameter("@printTypeName",SqlDbType.NVarChar,100),
              new SqlParameter("@printerName",SqlDbType.NVarChar,100),
              new SqlParameter("@printTemplete",SqlDbType.NVarChar,20),
              new SqlParameter("@delFlag",SqlDbType.Bit,1),
              new SqlParameter("@creator",SqlDbType.NVarChar,100),
              new SqlParameter("@createTime",SqlDbType.DateTime),
              new SqlParameter("@lastModifier",SqlDbType.NVarChar,100),
              new SqlParameter("@lastModifyTime",SqlDbType.DateTime),
              new SqlParameter("@printArea",SqlDbType.NVarChar,10),
              param_id 
            };
            parameters[0].Value = model.printType;
            parameters[1].Value = model.printTypeName;
            parameters[2].Value = model.printerName;
            parameters[3].Value = model.printTemplete;
            parameters[4].Value = model.delFlag;
            parameters[5].Value = model.creator;
            parameters[6].Value = model.createTime;
            parameters[7].Value = model.lastModifier;
            parameters[8].Value = model.lastModifyTime;
            parameters[9].Value = model.printArea;

            int rowsAffected;
            if (transModel != null)
            {
                SQLServerHelper.RunProcedure(transModel.conn, transModel.trans, "uspWip_AddPrintConfig", parameters, out rowsAffected);
            }
            else
            {
                SQLServerHelper.RunProcedure("uspWip_AddPrintConfig", parameters, out rowsAffected);
            }
            return (int)parameters[parameters.Length - 1].Value;
        }

        #endregion

        #region Edit

        /// <summary> 
        /// 更新一条打印配置数据 
        /// </summary> 
        /// <param name="model">要更新的打印配置实体</param> 
        /// <param name="transModel">事务类</param> 
        /// <returns>是否更新成功</returns> 
        public bool Update(PrintConfigEntity model, TransactionModel transModel = null)
        {
            SqlParameter[] parameters = { 
              new SqlParameter("@id",SqlDbType.Int,4),
              new SqlParameter("@printType",SqlDbType.NChar,3),
              new SqlParameter("@printTypeName",SqlDbType.NVarChar,100),
              new SqlParameter("@printerName",SqlDbType.NVarChar,100),
              new SqlParameter("@printTemplete",SqlDbType.NVarChar,20),
              new SqlParameter("@delFlag",SqlDbType.Bit,1),
              new SqlParameter("@lastModifier",SqlDbType.NVarChar,100),
              new SqlParameter("@lastModifyTime",SqlDbType.DateTime),
              new SqlParameter("@printArea",SqlDbType.NVarChar,10),
            };
            parameters[0].Value = model.id;
            parameters[1].Value = model.printType;
            parameters[2].Value = model.printTypeName;
            parameters[3].Value = model.printerName;
            parameters[4].Value = model.printTemplete;
            parameters[5].Value = model.delFlag;
            parameters[6].Value = model.lastModifier;
            parameters[7].Value = model.lastModifyTime;
            parameters[8].Value = model.printArea;

            int rowsAffected = 0;
            if (transModel != null)
            {
                SQLServerHelper.RunProcedure(transModel.conn, transModel.trans, "uspWip_UpdatePrintConfig", parameters, out rowsAffected);
            }
            else
            {
                SQLServerHelper.RunProcedure("uspWip_UpdatePrintConfig", parameters, out rowsAffected);
            }
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

        #region Enable

        /// <summary> 
        /// 禁启用打印配置表数据 
        /// </summary> 
        /// <param name="printType">打印类型</param> 
        /// <param name="delFlag">禁用1/启用0</param> 
        /// <param name="lastModifier">最后修改人</param> 
        /// <param name="transModel">事务类</param> 
        /// <returns>是否禁启用成功</returns> 
        public bool Enable(string printType, string delFlag, string lastModifier, TransactionModel transModel = null)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" UPDATE PrintConfigEntity  SET delflag=@delFlag ");
            strSql.Append(" ,lastModifier=@lastModifier ");
            strSql.Append(" ,lastModifyTime=@lastModifyTime ");
            strSql.Append(" WHERE printType=@printType");
            SqlParameter[] parameters = {  
                    new SqlParameter("@delFlag", SqlDbType.NVarChar,10) , 
                    new SqlParameter("@lastModifier", SqlDbType.NVarChar,20) , 
                    new SqlParameter("@lastModifyTime", SqlDbType.DateTime) , 
                    new SqlParameter("@printType", SqlDbType.NVarChar,50)  
            };
            parameters[0].Value = delFlag;
            parameters[1].Value = lastModifier;
            parameters[2].Value = DateTime.Now;
            parameters[3].Value = printType;

            int rows = 0;
            if (transModel != null)
            {
                rows = SQLServerHelper.ExecuteSql(transModel.conn, transModel.trans, strSql.ToString(), parameters);
            }
            else
            {
                rows = SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
            }
            return rows > 0 ? true : false;
        }

        #endregion

        #region QueryList(Page)

        /// <summary> 
        /// 获得打印配置数据列表(分页) 
        /// </summary> 
        /// <param name="strOrderBy">排序字段</param> 
        /// <param name="strWhere">查询条件</param> 
        /// <param name="model">分页实体数据</param> 
        /// <returns>打印配置列表DataSet</returns> 
        public DataSet GetListForPage(QueryPrintConfigParam model)
        {
            SqlParameter[] parameters = { 
                        new SqlParameter("@printTypeName", SqlDbType.NVarChar,50) , 
                        new SqlParameter("@printerName", SqlDbType.NVarChar,50) , 
                        new SqlParameter("@printTemplete", SqlDbType.NVarChar,10) , 
                        new SqlParameter("@printArea", SqlDbType.NVarChar,10) , 
                        new SqlParameter("@pageIndex", SqlDbType.Int) , 
                        new SqlParameter("@pageSize", SqlDbType.Int) , 
                        new SqlParameter("@delFlag",SqlDbType.NVarChar,10)
            };

            parameters[0].Value = model.printTypeName;
            parameters[1].Value = model.printerName;
            parameters[2].Value = model.printTemplete;
            parameters[3].Value = model.printArea;
            parameters[4].Value = model.pageIndex;
            parameters[5].Value = model.pageSize;
            parameters[6].Value = model.delFlag;
            return SQLServerHelper.RunProcedure("uspWip_GetPrintConfigPageList", parameters, "pagetable");
        }

        #endregion

        #region Query(Single)

        /// <summary> 
        /// 得到一个打印配置实体 
        /// </summary> 
        /// <param name="printType">打印类型</param> 
        /// <returns>打印配置实体</returns> 
        public PrintConfigEntity GetModel(string printType)
        {
            SqlParameter[] parameters = { 
                    new SqlParameter("@printType", SqlDbType.VarChar,50) 
            };
            parameters[0].Value = printType;

            DataSet ds = SQLServerHelper.RunProcedure("uspWip_GetSinglePrintConfig", parameters, "pagetable");

            PrintConfigEntity model = new PrintConfigEntity();

            if (ds.Tables[0].Rows.Count > 0)
            {
                var dataRow = ds.Tables[0].Rows[0];

                if (dataRow["id"].ToString() != "")
                {
                    model.id = int.Parse(dataRow["id"].ToString());
                }
                model.printType = dataRow["printType"].ToString();
                model.printTypeName = dataRow["printTypeName"].ToString();
                model.printerName = dataRow["printerName"].ToString();
                model.printTemplete = dataRow["printTemplete"].ToString();
                model.printArea = dataRow["printArea"].ToString();
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


                return model;
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region Other

        /// <summary> 
        /// 是否存在该打印配置记录 
        /// </summary> 
        /// <param name="printType">打印类型</param> 
        /// <returns>是否存在该打印配置记录</returns> 
        public bool Exists(string printType, int? id = null)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM PrintConfigEntity");
            strSql.Append(" where ");
            strSql.Append("  printType = @printType  ");
            if (id != null)
            {
                strSql.Append("  AND  id <> " + id.ToString());
            }
            SqlParameter[] parameters = { 
                    new SqlParameter("@printType", SqlDbType.NVarChar,50)           };
            parameters[0].Value = printType;

            return SQLServerHelper.Exists(strSql.ToString(), parameters);
        }

        #endregion

    }
}


