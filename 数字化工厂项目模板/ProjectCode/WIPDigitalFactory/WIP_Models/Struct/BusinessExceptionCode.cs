using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIP_Models
{
    /// <summary>
    /// 业务异常结构类
    /// </summary>
    public struct BusinessExceptionCode
    {
        /// <summary>
        /// WIP通知ECM上料完成异常
        /// </summary>
        public const string WIP_PostECMForFeedCompleted = "WIP-001";

        /// <summary>
        /// ECM接收上料返回异常LoadStatus
        /// </summary>
        public const string WIP_ECMResponseErrLoadStatus = "WIP-002";

        /// <summary>
        /// 找不到配方号
        /// </summary>
        public const string WIP_RecipeNumberNotFound = "WIP-003";


        /// <summary>
        /// 获取agvCode的当前状态失败
        /// </summary>
        public const string WIP_GetAgvCurStatusError = "WIP-004";

        /// <summary>
        /// 发起质检任务失败
        /// </summary>
        public const string WIP_QualityTaskError = "WIP-005";

        /// <summary>
        /// 向立库推送热处理炉号失败
        /// </summary>
        public const string WIP_PushHeatingnumber = "WIP-006";

        /// <summary>
        /// 物料回退
        /// </summary>
        public const string WIP_MaterialFallBack = "WIP-007";

        /// <summary>
        /// 发起质量预测
        /// </summary>
        [Obsolete("废弃，不作为业务异常,只作为异常信息记录")]
        public const string WIP_PredictiveTask = "WIP-008";
        /// <summary>
        /// 流转卡信息交互(热处理完毕后)（给MES）
        /// </summary>
        public const string WIP_PostToMESForProcessCardDataInteractionForHeatAfter = "WIP-009";

        /// <summary>
        /// 试制跟踪通知
        /// </summary>
        public const string WIP_TrialproductNotice = "WIP-010";

        /// <summary>
        /// 进预热或下线通知
        /// </summary>
        public const string WIP_AttachProcNotice = "WIP-011";
        /// <summary>
        /// 报废请求
        /// </summary>
        public const string WIP_ScrapWithRetry = "WIP-012";

        /// <summary>
        /// 质检结果提交
        /// </summary>
        public const string WIP_QualityStatusToWCSWithRetry = "WIP-013";

        /// <summary>
        /// 推送流转卡信息给立库
        /// </summary>
        public const string WIP_PushProcessCardInfoToWCSWithRetry = "WIP-014";

        /// <summary>
        /// 质量预测信息提交
        /// </summary>
        public const string WIP_QAMSResultToLIMS = "WIP-015";


        /// <summary>
        /// 物料状态变更
        /// </summary>
        public const string WIP_MaterialStatusChange = "WIP-016";


        /// <summary>
        /// 物料出入库信息推送给MES
        /// </summary>
        public const string WIP_MaterialOutPutInventoryToMES = "WIP-017";


        /// <summary>
        /// 产线可用状态变化通知
        /// </summary>
        public const string WIP_LineStatusChangeNotice = "WIP-018";

        /// <summary>
        /// 设备可用状态变化通知
        /// </summary>
        public const string WIP_EquipStatusChangeNotice = "WIP-019";


        /// <summary>
        /// 通知ECM下料台的AGV取料状态
        /// </summary>
        public const string WIP_NotifyAgvTaskMaterialStatusToECM = "WIP-020";

        /// <summary>
        /// 没有配置邮箱人员信息
        /// </summary>
        public const string WIP_NoMailAddress = "WIP-021";

    }

    /// <summary>
    /// 业务异常结构类
    /// </summary>
    public struct BusinessExceptionMessage
    {
        /// <summary>
        /// 没有配置邮箱人员信息
        /// </summary>
        public const string WIP_NoMailAddress = "没有配置邮箱人员信息";

        /// <summary>
        /// 通知ECM下料台的AGV取料状态
        /// </summary>
        public const string WIP_NotifyAgvTaskMaterialStatusToECM = "通知ECM下料台的AGV取料状态失败";
        /// <summary>
        /// 设备可用状态变化通知
        /// </summary>
        public const string WIP_EquipStatusChangeNotice = "设备可用状态变化通知失败";
        /// <summary>
        /// 产线可用状态变化通知
        /// </summary>
        public const string WIP_LineStatusChangeNotice = "产线可用状态变化通知失败";

        /// <summary>
        /// 物料出入库信息推送给MES
        /// </summary>
        public const string WIP_MaterialOutPutInventoryToMES = "物料出入库信息推送给MES请求失败";
        /// <summary>
        /// 物料状态变更
        /// </summary>
        public const string WIP_MaterialStatusChange = "物料状态变更请求失败";
        /// <summary>
        /// 质量预测信息提交
        /// </summary>
        public const string WIP_QAMSResultToLIMS = "质量预测信息提交失败";
        /// <summary>
        /// 推送流转卡信息给立库
        /// </summary>
        public const string WIP_PushProcessCardInfoToWCSWithRetry = "推送流转卡信息给立库失败";
        /// <summary>
        /// 质检结果提交
        /// </summary>
        public const string WIP_QualityStatusToWCSWithRetry = "质检结果提交失败";

        /// <summary>
        /// 报废请求
        /// </summary>
        public const string WIP_ScrapWithRetry = "报废请求失败";
        /// <summary>
        /// 进预热或下线通知
        /// </summary>
        public const string WIP_AttachProcNotice = "进预热或下线通知失败";
        /// <summary>
        /// 试制跟踪通知
        /// </summary>
        public const string WIP_TrialproductNotice = "试制跟踪通知失败";

        /// <summary>
        /// 流转卡信息交互(热处理完毕后)（给MES）
        /// </summary>
        public const string WIP_PostToMESForProcessCardDataInteractionForHeatAfter = "发送流转卡信息交互(热处理完毕后)请求给MES失败";
        /// <summary>
        /// 发起质量预测
        /// </summary>
        public const string WIP_PredictiveTask = "发起质量预测失败";
        /// <summary>
        /// 物料回退
        /// </summary>
        public const string WIP_MaterialFallBack = "物料回退请求失败";

        /// <summary>
        /// 向立库推送热处理炉号失败
        /// </summary>
        public const string WIP_PushHeatingnumber = "向立库推送热处理炉号失败";

        /// <summary>
        /// 发起质检任务失败
        /// </summary>
        public const string WIP_QualityTaskError = "发起质检任务失败";

        /// <summary>
        /// WIP通知ECM上料完成异常
        /// </summary>
        public const string WIP_PostECMForFeedCompleted = "WIP通知ECM上料完成异常。";

        /// <summary>
        /// ECM接收上料返回异常LoadStatus
        /// </summary>
        public const string WIP_ECMResponseErrLoadStatus = "ECM接收上料返回异常LoadStatus。";

        /// <summary>
        /// 找不到配方号
        /// </summary>
        public const string WIP_RecipeNumberNotFound = "找不到配方号。";

        /// <summary>
        /// 获取agvCode的当前状态失败
        /// </summary>
        public const string WIP_GetAgvCurStatusError = "获取agvCode的当前状态失败";

    }

}
