using System;
using System.Runtime.Serialization;

namespace WIP_Models
{
    /// <summary>
    /// 请求返回的结果类
    /// </summary>
    [DataContract]
    public class ResponseUpdaterRet
    {
        /// <summary>
        /// 是否执行成功
        /// </summary>
        [DataMember]
        public bool execResult { get; set; }


        /// <summary>
        /// 异常信息对象
        /// </summary>
        [DataMember]
        public ExceptionInfoEntity exception { get; set; }


    }
}