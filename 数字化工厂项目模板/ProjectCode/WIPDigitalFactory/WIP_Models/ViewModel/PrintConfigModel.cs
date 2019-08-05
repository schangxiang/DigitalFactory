 using System;
using System.Runtime.Serialization; 
                   
namespace WIP_Models 
{
    /// <summary>
    /// 打印配置展示类
    /// </summary>
    [DataContract]
    public class PrintConfigModel
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
        /// 删除标记
        /// </summary>
        [DataMember]
        public bool? delFlag { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [DataMember]
        public string creator { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember]
        public DateTime? createTime { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        [DataMember]
        public string lastModifier { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        [DataMember]
        public DateTime? lastModifyTime { get; set; }

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
        /// 打印模板编码名称
        /// </summary>
        [DataMember]
        public string printTempleteName { get; set; }

        /// <summary>
        /// 打印区域
        /// </summary>
        [DataMember]
        public string printArea { get; set; }


        /// <summary>
        /// 打印区域名称
        /// </summary>
        [DataMember]
        public string printAreaName { get; set; }

    }
}