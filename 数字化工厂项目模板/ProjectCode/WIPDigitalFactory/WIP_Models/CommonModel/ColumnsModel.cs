using System;
namespace WIP_Models
{
    /// <summary>
    /// 实体类Model
    /// </summary>
    public class ColumnsModel
    {
        public ColumnsModel()
        {
            IsNullable = false;//默认是必填
        }

        /// <summary>
        /// 中文名
        /// </summary>
        public string ChinaName { get; set; }

        /// <summary>
        /// 属性名
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// 数据类型 
        /// </summary>
        public Type DataType { get; set; }


        /// <summary>
        /// 是否可为null
        /// </summary>
        public bool IsNullable { get; set; }

    }
}
