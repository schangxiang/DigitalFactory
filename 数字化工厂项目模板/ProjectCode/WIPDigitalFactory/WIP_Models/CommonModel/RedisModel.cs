using System.Collections.Generic;
using System.Runtime.Serialization;
namespace WIP_Models
{
    /// <summary>
    /// Redis实体类
    /// </summary>
    [DataContract]
    public class RedisModel
    {
        /// <summary>
        /// 菜单权限
        /// </summary>
        [DataMember]
        public List<ResourceMenuInfo> resourceMenuInfoList { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [DataMember]
        public string updateTime { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [DataMember]
        public string userName { get; set; }

    }
}
