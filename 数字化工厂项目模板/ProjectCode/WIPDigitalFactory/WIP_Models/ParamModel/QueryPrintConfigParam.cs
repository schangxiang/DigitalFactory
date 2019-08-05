using System;
using System.Runtime.Serialization;

namespace WIP_Models
{
    /// <summary> 
    /// 查询打印配置表类 
    /// </summary> 
    [DataContract]
    public class QueryPrintConfigParam : PageModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        [DataMember]
        public int id { get; set; }

        /// <summary>
        /// 打印类型
        /// </summary>
        [DataMember]
        public string printType { get; set; }

        /// <summary>
        /// 打印机名称
        /// </summary>
        [DataMember]
        public string printerName { get; set; }

        /// <summary>
        /// 打印类型描述
        /// </summary>
        [DataMember]
        public string printTypeName { get; set; }

        /// <summary>
        /// 打印模板编码
        /// </summary>
        [DataMember]
        public string printTemplete { get; set; }


        /// <summary>
        /// 打印区域
        /// </summary>
        [DataMember]
        public string printArea { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        [DataMember]
        public string delFlag { get; set; }
    }
}
