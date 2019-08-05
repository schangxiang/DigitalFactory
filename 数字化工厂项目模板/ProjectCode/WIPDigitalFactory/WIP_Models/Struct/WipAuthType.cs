using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIP_Models
{
    /// <summary>
    /// WIP权限缓存类型
    /// </summary>
    public struct WipAuthType
    {
        /// <summary>
        /// Redis
        /// </summary>
        public const string REDIS = "REDIS";


        /// <summary>
        /// 内存
        /// </summary>
        public const string MEMORY = "MEMORY";

    }
}
