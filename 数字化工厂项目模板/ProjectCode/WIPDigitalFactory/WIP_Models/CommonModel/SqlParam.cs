using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIP_Models
{
    [Serializable]
    public class SqlParam
    {
        public SqlParam()
        { }

        /// <summary>
        /// sql文本
        /// </summary>
        public string StrSql { get; set; }


        /// <summary>
        /// sql参数
        /// </summary>
        public SqlParameter[] Parameters { get; set; }
    }
}
