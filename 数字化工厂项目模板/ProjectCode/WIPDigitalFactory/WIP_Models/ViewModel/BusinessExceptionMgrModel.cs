using System;
using System.Runtime.Serialization;

namespace WIP_Models
{
    /// <summary>
    /// 业务异常管理实体类
    /// </summary>
    [DataContract]
    public class BusinessExceptionMgrModel : BusinessExceptionMgrEntity
    {
        /// <summary>
        /// 任务类型编码名称
        /// </summary>
        [DataMember]
        public string taskTypeName { get; set; }

        /// <summary>
        /// 系统编号名称
        /// </summary>
        [DataMember]
        public string sysCodeName { get; set; }


        /// <summary>
        /// 时间戳字符串
        /// </summary>
        [DataMember]
        public string _timestamp_str { get; set; }

        /// <summary>
        /// 创建时间字符串
        /// </summary>
        [DataMember]
        public string createTime_str { get; set; }

        /// <summary>
        /// 最后修改时间字符串
        /// </summary>
        [DataMember]
        public string lastModifyTime_str { get; set; }

        /// <summary>
        /// 处理状态字符串
        /// </summary>
        [DataMember]
        public string disposeStatus_str { get; set; }

    }
}