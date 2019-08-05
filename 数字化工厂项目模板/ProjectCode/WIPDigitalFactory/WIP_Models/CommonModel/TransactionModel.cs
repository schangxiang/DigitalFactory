/*
 * CLR Version：4.0.30319.42000
 * NameSpace：WIP_Models.CommonModel
 * FileName：TransactionModel
 * CurrentYear：2018
 * CurrentTime：2018/9/1 7:28:46
 * Author：shaocx
 *
 * <更新记录>
 * ver 1.0.0.0   2018/9/1 7:28:46 新規作成 (by shaocx)
 */


using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIP_Models
{
    /// <summary>
    /// 事务类
    /// </summary>
    public class TransactionModel
    {
        /// <summary>
        /// 数据库连接类
        /// </summary>
        public SqlConnection conn { get; set; }

        /// <summary>
        /// 事务类
        /// </summary>
        public SqlTransaction trans { get; set; }
    }
}
