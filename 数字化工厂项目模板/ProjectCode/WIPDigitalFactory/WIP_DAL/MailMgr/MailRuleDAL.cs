using System;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using WIP_Models;
using SysManager.DB.Utilities;

namespace WIP_SQLServerDAL
{
    /// <summary> 
    /// 邮件类别数据访问类 
    /// </summary> 
    public class MailRuleDAL
    {
        #region 单例模式（饿汉模式）

        private static MailRuleDAL _instance = null;
        private MailRuleDAL() { }
        static MailRuleDAL()
        {
            _instance = new MailRuleDAL();
        }
        public static MailRuleDAL GetInstance()
        {
            return _instance;
        }

        #endregion

        #region 获得邮件类别数据列表

        /// <summary> 
        /// 获得邮件类别数据列表 
        /// </summary> 
        /// <returns>邮件类别列表DataSet</returns> 
        public DataSet GetMailRuleList()
        {
            SqlParameter[] parameters = { 
            };
            return SQLServerHelper.RunProcedure("uspWip_GetMailRuleList", parameters, "table");
        }

        #endregion

        #region 获得邮件人员数据列表

        /// <summary> 
        /// 获得邮件人员数据列表 
        /// </summary> 
        /// <param name="categoryId">邮件类别ID</param> 
        /// <returns>邮件类别列表DataSet</returns> 
        public DataSet GetMailPersonList(string categoryId)
        {
            SqlParameter[] parameters = { 
                        new SqlParameter("@categoryId", SqlDbType.NVarChar,500)  
            };
            parameters[0].Value = categoryId;
            return SQLServerHelper.RunProcedure("uspWip_GetMailPersonList", parameters, "table");
        }

        #endregion
    }
}


