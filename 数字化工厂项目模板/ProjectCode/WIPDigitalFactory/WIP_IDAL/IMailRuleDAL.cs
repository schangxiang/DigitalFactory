using System;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using WIP_Models;
using SysManager.DB.Utilities;

namespace WIP_IDAL
{
    /// <summary> 
    /// 邮件类别数据访问类 
    /// </summary> 
    public interface IMailRuleDAL
    {

        #region 获得邮件类别数据列表

        /// <summary> 
        /// 获得邮件类别数据列表 
        /// </summary> 
        /// <returns>邮件类别列表DataSet</returns> 
        DataSet GetMailRuleList();


        #endregion

        #region 获得邮件人员数据列表

        /// <summary> 
        /// 获得邮件人员数据列表 
        /// </summary> 
        /// <param name="categoryId">邮件类别ID</param> 
        /// <returns>邮件类别列表DataSet</returns> 
        DataSet GetMailPersonList(string categoryId);


        #endregion
    }
}


