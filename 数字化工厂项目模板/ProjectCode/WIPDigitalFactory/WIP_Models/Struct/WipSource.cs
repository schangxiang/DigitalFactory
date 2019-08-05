using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIP_Models
{
    /// <summary>
    /// WIP相关来源
    /// </summary>
    public struct WipSource
    {
        /// <summary>
        /// WIPREST服务
        /// </summary>
        public const string WIPREST = "WIPREST";

        /// <summary>
        /// WIP排产任务下发服务
        /// </summary>
        public const string IssueScheduleTaskService = "IssueScheduleTaskService";

        /// <summary>
        /// WIP出库或下料下发服务
        /// </summary>
        public const string IssueOutStoreTaskService = "IssueOutStoreTaskService";

        /// <summary>
        /// WIP打印服务
        /// </summary>
        public const string PrintService = "PrintService";

    }
}
