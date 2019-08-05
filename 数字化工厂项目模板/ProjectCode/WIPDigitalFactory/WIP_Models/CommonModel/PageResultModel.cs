using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WIP_Models
{
    /// <summary>
    /// 分页返回实体
    /// </summary>
    [DataContract]
    public class PageResultModel<T>
    {
        /// <summary>
        /// 总条数
        /// </summary>
         [DataMember]
        public int total { get; set; }

        /// <summary>
        /// 数据列表
        /// </summary>
         [DataMember]
        public List<T> rows { get; set; }

    }
}
