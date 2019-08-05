using System;
using System.Runtime.Serialization;

namespace WIP_Models
{
    /// <summary> 
    /// 查询邮箱人员类 
    /// </summary> 
    [DataContract]
    public class QueryMailPersonParam
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string categoryId { get; set; }




    }
}
