using System;
using System.Net;
using System.Runtime.Serialization;

namespace WIP_Models
{
    /// <summary>
    /// 异常信息表实体类
    /// </summary>
    [DataContract]
    public class ExceptionInfoEntity
    {
        public ExceptionInfoEntity()
        {
        }


        /// <summary>
        /// 关键词1（一般存taskNo，loadNumber）
        /// </summary>
        [DataMember]
        public string key1 { get; set; }


        /// <summary>
        /// 关键词2（一般存流转卡号，line）
        /// </summary>
        [DataMember]
        public string key2 { get; set; }

        /// <summary>
        /// 异常级别
        /// </summary>
        [DataMember]
        public string exceptionLevel { get; set; }

        /// <summary>
        /// 异常方向
        /// </summary>
        [DataMember]
        public string exceptionSource { get; set; }

        /// <summary>
        /// 异常时方法名
        /// </summary>
        [DataMember]
        public string exceptionFun { get; set; }

        /// <summary>
        /// 源数据的json数据
        /// </summary>
        [DataMember]
        public string sourceData { get; set; }

        /// <summary>
        /// 异常信息
        /// </summary>
        [DataMember]
        public string exceptionMsg { get; set; }

        /// <summary>
        /// 异常的json数据
        /// </summary>
        [DataMember]
        public string exceptionData { get; set; }


        /// <summary>
        /// 错误发生所在的host
        /// </summary>
        [DataMember]
        public string host { get; set; }


        /// <summary>
        /// 创建人
        /// </summary>
        [DataMember]
        public string creator { get; set; }

    }
}