using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIP_Models
{
    /// <summary>
    /// 存储过程执行返回类
    /// </summary>
    public class ProcResultModel
    {
        /// <summary>
        /// SqlCommand 相关联的参数的集合
        /// </summary>
        public SqlParameterCollection sqlParameterCollection { get; set; }

        /// <summary>
        /// 执行结果(-1 失败，1成功)
        /// </summary>
        public int execResult { get; set; }


        /// <summary>
        /// 异常信息
        /// </summary>
        public string errMsg { get; set; }

    }
}
