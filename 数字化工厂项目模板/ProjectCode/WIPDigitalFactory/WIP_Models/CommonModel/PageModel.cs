using System.Runtime.Serialization;
namespace WIP_Models
{
    /// <summary>
    /// 分页实体
    /// </summary>
    [DataContract]
    public class PageModel
    {
        /// <summary>
        /// 第几页
        /// </summary>
        [DataMember]
        public int pageIndex { get; set; }

        /// <summary>
        /// 显示的条数
        /// </summary>
        [DataMember]
        public int pageSize { get; set; }

    }
}
