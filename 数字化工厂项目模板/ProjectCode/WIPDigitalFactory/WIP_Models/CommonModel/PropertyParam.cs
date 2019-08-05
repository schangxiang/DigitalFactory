using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIP_Models
{
    /// <summary>
    /// 更新条件参数类
    /// </summary>
    public class PropertyParam
    {
        /// <summary>
        /// 更新条件参数类无参构造函数
        /// </summary>
        public PropertyParam()
        {
            IsWhereFilter = false;
            IsWhereFilterExtend = false;
        }

        /// <summary>
        /// 是否是Where条件
        /// </summary>
        public bool IsWhereFilter { get; set; }

        /// <summary>
        /// 是否是Where条件的扩展（用于 查询和更新都用同一个字段的情况）
        /// </summary>
        public bool IsWhereFilterExtend { get; set; }

        /// <summary>
        /// 属性值
        /// </summary>
        public Object ObjectValue { get; set; }

        /// <summary>
        /// 属性名字
        /// </summary>
        public string PropertyName { get; set; }


        /// <summary>
        /// System.Data.SqlDbType 值之一。
        /// </summary>
        public SqlDbType dbType { get; set; }

        /// <summary>
        /// 参数的长度。
        /// </summary>
        public int? size { get; set; }

    }
}
