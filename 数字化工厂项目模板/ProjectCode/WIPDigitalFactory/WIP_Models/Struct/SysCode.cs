using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIP_Models
{
    /// <summary>
    /// 系统编码结构类
    /// </summary>
    public struct SysCode
    {
        /// <summary>
        /// MES
        /// </summary>
        public const string MES = "MES";

        /// <summary>
        /// 在制品管理系统
        /// </summary>
        public const string WIP="WIP";

        /// <summary>
        /// 立库管理系统
        /// </summary>
        public const string WCS="WCS";

        /// <summary>
        /// AGV调度系统
        /// </summary>
        public const string RCS="RCS";


        /// <summary>
        /// 背负式AGV调度系统
        /// </summary>
        public const string P3SS = "P3SS";


        /// <summary>
        /// 质量管理系统
        /// </summary>
        public const string LIMS="LIMS";

        /// <summary>
        /// 质量预测系统
        /// </summary>
        public const string QAMS="QAMS";

        /// <summary>
        /// 加热管理系统
        /// </summary>
        public const string ECM="ECM";

        /// <summary>
        /// 排产系统
        /// </summary>
        public const string SCHEDULE="SCHEDULE";
   
    }
}
