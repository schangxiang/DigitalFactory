using System; 
using System.Runtime.Serialization; 
 
namespace WIP_Models 
{ 
    /// <summary> 
    /// 查询代码项表类 
    /// </summary> 
	[DataContract] 
    public class QueryCodeItemsModel : PageModel 
    { 
                /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int id { get; set; }

        /// <summary>
        /// 代码项编码
        /// </summary>
        [DataMember]
        public string code { get; set; }

        /// <summary>
        /// 代码项名称
        /// </summary>
        [DataMember]
        public string name { get; set; }

        /// <summary>
        /// 代码编码
        /// </summary>
        [DataMember]
        public string setCode { get; set; }

        /// <summary>
        /// 删除标记
        /// </summary>
        [DataMember]
        public string delFlag { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        [DataMember]
        public string note { get; set; }


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

 
    } 
} 
