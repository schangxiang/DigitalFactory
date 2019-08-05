using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WIP_Models
{
    /// <summary> 
    /// 更新邮箱人员参数类 
    /// </summary> 
    [DataContract]
    public class UpdateMailPersonParam
    {
        /// <summary>
        /// 邮件类别ID
        /// </summary>
        [DataMember]
        public string categoryId { get; set; }


        /// <summary>
        /// 人员列表
        /// </summary>
        [DataMember]
        public List<MailPersonParamList> mailPersonParamList { get; set; }

    }

    [DataContract]
    public class MailPersonParamList
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string mailAddress { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string mailName { get; set; }

    }
}
