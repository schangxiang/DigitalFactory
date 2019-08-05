using System;
namespace WIP_Models
{
    /// <summary>
    /// 验证Model
    /// </summary>
    public class ValidateModel
    {
        public ValidateModel()
        {
            IsNullable = false;//默认是必填
        }

        /// <summary>
        /// 中文名
        /// </summary>
        public string ChinaName { get; set; }

        /// <summary>
        /// 数据值
        /// </summary>
        public object DataValue { get; set; }

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
