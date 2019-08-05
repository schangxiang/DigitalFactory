using System; 
using System.Runtime.Serialization; 
 
namespace WIP_Models 
{ 
    /// <summary> 
    /// 查询业务异常管理类 
    /// </summary> 
	[DataContract] 
    public class QueryBusinessExceptionMgrModel : PageModel 
    {

        /// <summary>
        /// 发生时间范围
        /// </summary>
        [DataMember]
        public string[] _timestamp { get; set; }

        /// <summary>
        /// 任务ID
        /// </summary>
        [DataMember]
        public string taskNo { get; set; }

        /// <summary>
        /// 任务类型编码
        /// </summary>
        [DataMember]
        public string taskType { get; set; }

        /// <summary>
        /// 流转卡号
        /// </summary>
        [DataMember]
        public string processCardNumber { get; set; }

        /// <summary>
        /// 系统编码
        /// </summary>
        [DataMember]
        public string sysCode { get; set; }

        /// <summary>
        /// 异常代码
        /// </summary>
        [DataMember]
        public string exceptionCode { get; set; }

        /// <summary>
        /// 异常信息
        /// </summary>
        [DataMember]
        public string exceptionMsg { get; set; }

        /// <summary>
        /// 质检状态
        /// </summary>
        [DataMember]
        public string qaStatus { get; set; }

        /// <summary>
        /// 物料状态
        /// </summary>
        [DataMember]
        public string materialStatus { get; set; }

        /// <summary>
        /// 物料编码
        /// </summary>
        [DataMember]
        public string materialCode { get; set; }

        /// <summary>
        /// 零件名称
        /// </summary>
        [DataMember]
        public string partName { get; set; }

        /// <summary>
        /// 零件号
        /// </summary>
        [DataMember]
        public string partNumber { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [DataMember]
        public int quantity { get; set; }

        /// <summary>
        /// 处理结果
        /// </summary>
        [DataMember]
        public string disposeResult { get; set; }

        /// <summary>
        /// 处理状态
        /// </summary>
        [DataMember]
        public string disposeStatus { get; set; }

        /// <summary>
        /// 处理说明
        /// </summary>
        [DataMember]
        public string disposeNote { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        [DataMember]
        public string timestamp { get; set; }

        /// <summary>
        /// 主机名
        /// </summary>
        [DataMember]
        public string host { get; set; }

 
    } 
} 
