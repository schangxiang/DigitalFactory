using System;
using System.Runtime.Serialization;

namespace WIP_Models
{
    [DataContract]
    public class ReturnBody<T>
    {
        /// <summary>
        /// 通用系统返回码
        /// </summary>
        [DataMember]
        public String resCode { get; set; }

        /// <summary>
        /// 通用系统返回的错误信息
        /// </summary>
        [DataMember]
        public String resMsg { get; set; }

        /// <summary>
        /// QAMS返回的错误信息
        /// </summary>
        [DataMember]
        public String errMsg { get; set; }


        [DataMember]
        public T resData { get; set; }

    }
}
