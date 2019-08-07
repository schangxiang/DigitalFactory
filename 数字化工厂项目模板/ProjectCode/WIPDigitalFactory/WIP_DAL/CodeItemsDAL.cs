using System;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using WIP_Models;
using SysManager.DB.Utilities;

namespace WIP_SQLServerDAL
{
    /// <summary> 
    /// 代码项表数据访问类 
    /// </summary> 
    public partial class CodeItemsDAL
    {
        #region Add

        /// <summary> 
        /// 增加一条代码项表数据 
        /// </summary> 
        /// <param name="model">要插入的代码项表实体</param> 
        /// <param name="transModel">事务类</param> 
        /// <returns>插入生成的最新主键值</returns> 
        public int Add(CodeItemsEntity model, TransactionModel transModel = null)
        {
            SqlParameter param_id = new SqlParameter();
            param_id.ParameterName = "@id";
            param_id.SqlDbType = SqlDbType.Int;
            param_id.Direction = ParameterDirection.Output;

            SqlParameter[] parameters = { 
              new SqlParameter("@code",SqlDbType.NVarChar,100),
              new SqlParameter("@name",SqlDbType.NVarChar,200),
              new SqlParameter("@setCode",SqlDbType.NVarChar,20),
              new SqlParameter("@note",SqlDbType.NVarChar,200),
              new SqlParameter("@delFlag",SqlDbType.Bit,1),
              new SqlParameter("@creator",SqlDbType.NVarChar,256),
              new SqlParameter("@createTime",SqlDbType.DateTime),
              new SqlParameter("@lastModifier",SqlDbType.NVarChar,256),
              new SqlParameter("@lastModifyTime",SqlDbType.DateTime),
              param_id 
            };
            parameters[0].Value = model.code;
            parameters[1].Value = model.name;
            parameters[2].Value = model.setCode;
            parameters[3].Value = model.note;
            parameters[4].Value = model.delFlag;
            parameters[5].Value = model.creator;
            parameters[6].Value = model.createTime;
            parameters[7].Value = model.lastModifier;
            parameters[8].Value = model.lastModifyTime;


            int rowsAffected;
            if (transModel != null)
            {
                SQLServerHelper.RunProcedure(transModel.conn, transModel.trans, "uspWip_AddCodeItems", parameters, out rowsAffected);
            }
            else
            {
                SQLServerHelper.RunProcedure("uspWip_AddCodeItems", parameters, out rowsAffected);
            }
            return (int)parameters[parameters.Length - 1].Value;
        }

        #endregion

        #region Edit

        /// <summary> 
        /// 更新一条代码项表数据 
        /// </summary> 
        /// <param name="model">要更新的代码项表实体</param> 
        /// <param name="transModel">事务类</param> 
        /// <returns>是否更新成功</returns> 
        public bool Update(CodeItemsEntity model, TransactionModel transModel = null)
        {
            SqlParameter[] parameters = { 
              new SqlParameter("@id",SqlDbType.Int,4),
              new SqlParameter("@code",SqlDbType.NVarChar,100),
              new SqlParameter("@name",SqlDbType.NVarChar,200),
              new SqlParameter("@setCode",SqlDbType.NVarChar,20),
              new SqlParameter("@note",SqlDbType.NVarChar,200),
              new SqlParameter("@delFlag",SqlDbType.Bit,1),
              new SqlParameter("@lastModifier",SqlDbType.NVarChar,256),
              new SqlParameter("@lastModifyTime",SqlDbType.DateTime),
            };
            parameters[0].Value = model.id;
            parameters[1].Value = model.code;
            parameters[2].Value = model.name;
            parameters[3].Value = model.setCode;
            parameters[4].Value = model.note;
            parameters[5].Value = model.delFlag;
            parameters[6].Value = model.lastModifier;
            parameters[7].Value = model.lastModifyTime;


            int rowsAffected = 0;
            if (transModel != null)
            {
                SQLServerHelper.RunProcedure(transModel.conn, transModel.trans, "uspWip_UpdateCodeItems", parameters, out rowsAffected);
            }
            else
            {
                SQLServerHelper.RunProcedure("uspWip_UpdateCodeItems", parameters, out rowsAffected);
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

        #region Del

        /// <summary> 
        /// 删除一条代码项表数据 
        /// </summary> 
        /// <param name="id">主键</param> 
        /// <param name="transModel">事务类</param> 
        /// <returns>是否删除成功</returns> 
        public bool Delete(string id, TransactionModel transModel = null)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from udtWip_CodeItems ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = { 
                    new SqlParameter("@id", SqlDbType.NVarChar,50) 
            };
            parameters[0].Value = id;

            int rows = 0;
            if (transModel != null)
            {
                rows = SQLServerHelper.ExecuteSql(transModel.conn, transModel.trans, strSql.ToString(), parameters);
            }
            else
            {
                rows = SQLServerHelper.ExecuteSql(strSql.ToString(), parameters);
            }
            if (rows > 0)
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
        /// 禁启用代码项表数据 
        /// </summary> 
        /// <param name="id">主键</param> 
        /// <param name="delFlag">禁用1/启用0</param> 
        /// <param name="lastModifier">最后修改人</param> 
        /// <param name="transModel">事务类</param> 
        /// <returns>是否禁启用成功</returns> 
        public bool Enable(string id, string delFlag, string lastModifier, TransactionModel transModel = null)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" UPDATE udtWip_CodeItems  SET delflag=@delFlag ");
            strSql.Append(" ,lastModifier=@lastModifier ");
            strSql.Append(" ,lastModifyTime=@lastModifyTime ");
            strSql.Append(" WHERE id=@id");
            SqlParameter[] parameters = {  
                    new SqlParameter("@delFlag", SqlDbType.NVarChar,10) , 
                    new SqlParameter("@lastModifier", SqlDbType.NVarChar,20) , 
                    new SqlParameter("@lastModifyTime", SqlDbType.DateTime) , 
                    new SqlParameter("@id", SqlDbType.NVarChar,50)  
            };
            parameters[0].Value = delFlag;
            parameters[1].Value = lastModifier;
            parameters[2].Value = DateTime.Now;
            parameters[3].Value = id;

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
        /// 获得代码项表数据列表(分页) 
        /// </summary> 
        /// <param name="strOrderBy">排序字段</param> 
        /// <param name="strWhere">查询条件</param> 
        /// <param name="model">分页实体数据</param> 
        /// <returns>代码项表列表DataSet</returns> 
        public DataSet GetListForPage(string strOrderBy, string strWhere, QueryCodeItemsModel model)
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
            return SQLServerHelper.RunProcedure("uspWip_GetCodeItemsPageList", parameters, "pagetable");
        }

        /// <summary> 
        /// 获取代码项表记录总数 
        /// </summary> 
        /// <param name="strWhere">查询条件</param> 
        /// <returns>代码项表记录总数</returns> 
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM udtWip_CodeItems AS codeItems ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = SQLServerHelper.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        #endregion

        #region Query(Single)

        /// <summary> 
        /// 得到一个代码项表实体 
        /// </summary> 
        /// <param name="id">主键</param> 
        /// <returns>代码项表实体</returns> 
        public CodeItemsEntity GetModel(string setCode, string code)
        {
            SqlParameter[] parameters = { 
                    new SqlParameter("@setCode", SqlDbType.VarChar,50),
                    new SqlParameter("@code", SqlDbType.VarChar,50)
            };
            parameters[0].Value = setCode;
            parameters[1].Value = code;

            DataSet ds = SQLServerHelper.RunProcedure("uspWip_GetSingleCodeItems", parameters, "pagetable");

            CodeItemsEntity model = new CodeItemsEntity();

            if (ds.Tables[0].Rows.Count > 0)
            {
                var dataRow = ds.Tables[0].Rows[0];

                if (dataRow["id"].ToString() != "")
                {
                    model.id = int.Parse(dataRow["id"].ToString());
                }
                model.code = dataRow["code"].ToString();
                model.name = dataRow["name"].ToString();
                model.setCode = dataRow["setCode"].ToString();
                model.note = dataRow["note"].ToString();
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

        #region QueryList

        /// <summary> 
        /// 获得代码项表数据列表 
        /// </summary> 
        /// <param name="strWhere">查询条件</param> 
        /// <returns>代码项表列表DataSet</returns> 
        public DataSet GetList(string strWhere)
        {
            SqlParameter[] parameters = { 
                        new SqlParameter("@strWhere", SqlDbType.NVarChar,500)  
            };
            parameters[0].Value = strWhere;
            return SQLServerHelper.RunProcedure("uspWip_GetCodeItemsList", parameters, "table");
        }

        #endregion 

        #region Other

        /// <summary> 
        /// 是否存在该代码项表记录 
        /// </summary> 
        /// <param name="id">主键</param> 
        /// <returns>是否存在该代码项表记录</returns> 
        public bool Exists(string setCode, string code, int? id = null)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM udtWip_CodeItems");
            strSql.Append(" where ");
            strSql.Append("  setCode = @setCode AND code=@code  ");
            if (id != null)
            {
                strSql.Append("   AND id <> " + id.ToString());
            }
            SqlParameter[] parameters = { 
                    new SqlParameter("@setCode", SqlDbType.NVarChar,50),     
                     new SqlParameter("@code", SqlDbType.NVarChar,50)
                                        };
            parameters[0].Value = setCode;
            parameters[1].Value = code;

            return SQLServerHelper.Exists(strSql.ToString(), parameters);
        }

        #endregion

    }
}


