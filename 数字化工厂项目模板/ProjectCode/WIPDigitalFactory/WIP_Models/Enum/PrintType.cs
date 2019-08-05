using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIP_Models
{
    /// <summary>
    /// 打印类型
    /// </summary>
    public enum PrintType
    {
        /// <summary>
        /// 热后出库打印流转卡
        /// </summary>
        ProcessCardForPostHeatStorageOut = 100,

        /// <summary>
        /// 人工抽检位送检单
        /// </summary>
        InspectOrder = 101,

        /// <summary>
        /// 后道缓存区打印流转卡
        /// </summary>
        ProcessCardForBuffer = 102,

        /// <summary>
        /// 立库人工出库打印流转卡（热外协料立库出入口)
        /// </summary>
        ProcessCardForWCSByWhGate1 = 103,

        /// <summary>
        /// 不良品或者正常下料缓存区方向物料打印送检单
        /// </summary>
        InspectOrderForReject = 104,

        /// <summary>
        /// 立库人工出库打印流转卡(热前出库和热后出库的出库口)
        /// </summary>
        ProcessCardForWCSByWhGate3 = 105


    }
}
