using System;
using System.Runtime.Serialization; 
                   
namespace WIP_Models 
{
    /// <summary>
    /// 邮件类别实体类
    /// </summary>
    [DataContract]
    public class MailRuleEntity
    {

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string categoryId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string categoryName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string remark { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public bool? delFlag { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string creator { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public DateTime? createTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string lastModifier { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public DateTime? lastModifyTime { get; set; }

    }
}