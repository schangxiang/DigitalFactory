using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIP_Models
{
    /// <summary>
    /// 顺序号类型
    /// </summary>
    public enum SerialNoType
    {
        /// <summary>
        /// WIP线下返修质检单号+免检放行虚拟质检单号
        /// </summary>
        QaSerialNo = 10,
        /// <summary>
        /// WIP返修出库任务号
        /// </summary>
        RepairSerialNo = 11,
        /// <summary>
        /// WIP报废出库任务号
        /// </summary>
        ScrapSerialNo = 12,
        /// <summary>
        /// WIP手工入热前库任务号
        /// </summary>
        HandInStoreNo = 13,
        /// <summary>
        /// WIP手工入热后库任务号
        /// </summary>
        HandInHeatAfterStoreNo = 14,
        /// <summary>
        /// WIP锁定物料任务号
        /// </summary>
        LockMatericalNo = 15,
        /// <summary>
        /// WIP 流转卡号测试
        /// </summary>
        WIPProcessCardNoTest = 90,

        /// <summary>
        /// WIP taskNo测试
        /// </summary>
        WIPTaskNoTest = 91,

        /// <summary>
        /// WIP loadNumber测试
        /// </summary>
        WIPLoadNumberTest = 92,
        /// <summary>
        /// WIP 我自己本地的TaskNo生成
        /// </summary>
        WIPMyTaskNoTest = 93,
        /// <summary>
        /// MES的任务号测试
        /// </summary>
        MESTaskNoTest = 94,
        /// <summary>
        /// WIP P3SS任务号测试
        /// </summary>
        WIP_P3SSTaskNoTest = 95
    }
}
