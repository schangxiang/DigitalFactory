using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIP_Models
{
    /// <summary>
    /// 表
    /// </summary>
    public struct Table
    {
        /// <summary>
        /// 推送流转卡失败表
        /// </summary>
        public const string ProcessCardInfoHeavyPush = "udtWip_ProcessCardInfoHeavyPush";
        /// <summary>
        /// 下发出库任务(包括ECM下料下发)
        /// </summary>
        public const string IssueOutStoreTask = "udtWip_IssueOutStoreTask";

        /// <summary>
        /// 打印信息表
        /// </summary>
        public const string PrintInfo = "udtWip_PrintInfo";


        /// <summary>
        /// 工艺参数卡主表
        /// </summary>
        public const string Recipe_Head = "udtEcm_Recipe_Head";

        /// <summary>
        /// 热前入库管理表
        /// </summary>
        public const string PreHeatStorageMgr = "udtWip_PreHeatStorageMgr";

        /// <summary>
        /// 试制品跟踪信息表
        /// </summary>
        public const string TrialproductInfo = "udtWip_TrialproductInfo";

        /// <summary>
        /// 不良品管理表
        /// </summary>
        public const string RejectsMgr = "udtWip_RejectsMgr";


        /// <summary>
        /// 不良品出库管理表
        /// </summary>
        public const string RejectsOutStorage = "udtWip_RejectsOutStorage";
        /// <summary>
        /// 线下抽样表
        /// </summary>
        public const string OfflineSampling = "udtWip_OfflineSampling";
        /// <summary>
        /// 下发任务记录表
        /// </summary>
        public const string IssueTask = "UdtWip_IssueTask";


        /// <summary>
        /// 下发任务表
        /// </summary>
        public const string ScheduleTask = "UdtWip_ScheduleTask";

        /// <summary>
        /// 实时排产任务下发表
        /// </summary>
        public const string IssueScheduleTask = "udtWip_IssueScheduleTask";

        /// <summary>
        /// 热处理工艺过程表
        /// </summary>
        public const string HeatTreamentTimeData = "udtEcm_HeatTreamentTimeData";

        /// <summary>
        /// 热后出库管理表
        /// </summary>
        public const string PostHeatStorageOutMgr = "udtWip_PostHeatStorageOutMgr";

        /// <summary>
        /// 流转卡号表
        /// </summary>
        public const string ProcessCardInfo = "udtWip_ProcessCardInfo";

        /// <summary>
        /// 物料锁定解锁管理表
        /// </summary>
        public const string MaterialLockUnLock = "udtWip_MaterialLockUnLock";

        /// <summary>
        /// 流转卡打印队列表
        /// </summary>
        public const string ProcessCardPrintQueue = "udtWip_ProcessCardPrintQueue";
        /// <summary>
        /// 任务表
        /// </summary>
        public const string Task = "udtWip_Task";

        /// <summary>
        /// ECM交互表
        /// </summary>
        public const string EcmInteraction = "udtWip_EcmInteraction";

        /// <summary>
        /// 库存信息表
        /// </summary>
        public const string Inventory = "udtWip_Inventory";

        /// <summary>
        /// 质量检测结果概要表
        /// </summary>
        public const string InspectionSummary = "[PR_Quality].[qa_InspectionSummary]";

        /// <summary>
        /// 质检明细表
        /// </summary>
        public const string InspectionDetail = "[PR_Quality].[qa_InspectionDetail]";

        /// <summary>
        /// 小车实时状态表
        /// </summary>
        public const string AgvRealTimeStatus = "udtWip_AGVRealTimeStatus";

        /// <summary>
        /// 小车绑定记录表
        /// </summary>
        public const string AgvBindingRecord = "udtWip_AgvBindingRecord";


    }
}
