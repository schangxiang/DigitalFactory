using System;
using System.Runtime.Serialization;

namespace WIP_Models
{
    /// <summary>
    /// 请求记录表实体类
    /// </summary>
    [DataContract]
    public class RequestRecordEntity
    {
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

        [DataMember]
        public Int64 id { get; set; }

        /// <summary>
        /// 方向(  1  WIP接收   2 WIP 推送)
        /// </summary>
        [DataMember]
        public int direction { get; set; }

        /// <summary>
        /// 方法名
        /// </summary>
        [DataMember]
        public string fullFun { get; set; }

        /// <summary>
        /// 请求host
        /// </summary>
        [DataMember]
        public string host { get; set; }

        /// <summary>
        /// 请求地址
        /// </summary>
        [DataMember]
        public string url { get; set; }

        /// <summary>
        /// 请求参数
        /// </summary>
        [DataMember]
        public string param { get; set; }

        /// <summary>
        /// 请求返回结果
        /// </summary>
        [DataMember]
        public string retResult { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string remark { get; set; }

        /// <summary>
        /// 发生的主机host
        /// </summary>
        [DataMember]
        public string happenHost { get; set; }
    }
}