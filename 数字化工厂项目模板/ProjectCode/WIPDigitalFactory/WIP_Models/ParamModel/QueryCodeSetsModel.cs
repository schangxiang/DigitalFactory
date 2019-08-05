using System;
using System.Runtime.Serialization;

namespace WIP_Models
{
    /// <summary> 
    /// 查询代码项类 
    /// </summary> 
    [DataContract]
    public class QueryCodeSetsModel : PageModel
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int id { get; set; }

        /// <summary>
        /// 代码编码
        /// </summary>
        [DataMember]
        public string code { get; set; }

        /// <summary>
        /// 代码名称
        /// </summary>
        [DataMember]
        public string name { get; set; }

        /// <summary>
        /// 删除标记
        /// </summary>
        [DataMember]
        public string delFlag { get; set; }

    }
}
