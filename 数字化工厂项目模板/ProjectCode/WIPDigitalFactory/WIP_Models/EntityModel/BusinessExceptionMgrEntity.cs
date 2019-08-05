using System;
using System.Runtime.Serialization;

namespace WIP_Models
{
    /// <summary>
    /// 业务异常管理实体类
    /// </summary>
    [DataContract]
    public class BusinessExceptionMgrEntity : BusinessExceptionMgrParam
    {
        public BusinessExceptionMgrEntity()
        {
            this.materialCode = "";
            this.partName = "";
            this.partNumber = "";
        }

        /// <summary>
        /// 时间戳
        /// </summary>
        [DataMember]
        public DateTime? _timestamp { get; set; }


        /// <summary>
        /// 主机名
        /// </summary>
        [DataMember]
        public string host { get; set; }

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

    }
}