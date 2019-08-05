using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIP_Models
{
    /// <summary>
    /// 更新类
    /// </summary>
    public class PropertyUpdateParam
    {
        /// <summary>
        /// 更新条件参数类集合
        /// </summary>
        public List<PropertyParam> UpdateProperParamList { get; set; }

        /// <summary>
        /// 要更新的表名
        /// </summary>
        public string TableName { get; set; }

    }
}
