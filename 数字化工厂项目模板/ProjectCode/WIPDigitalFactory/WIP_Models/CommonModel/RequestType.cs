using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIP_Models
{
    /// <summary>
    /// 请求类型
    /// </summary>
    public enum RequestType
    {
        /// <summary>
        /// 报废请求
        /// </summary>
        Scrap = 0,
        /// <summary>
        /// 推送流转卡信息给WCS
        /// </summary>
        PushProcessCardInfoToWCS = 1,
        /// <summary>
        /// 质检结果推送给WCS
        /// </summary>
        QualityStatusToWCS = 2,

        /// <summary>
        /// 质量预测发起(使用GET请求)
        /// </summary>
        PredictiveTask = 3,

        /// <summary>
        /// 其他请求
        /// </summary>
        Other = 4,
        /// <summary>
        /// 通知ECM下料台的AGV取料状态
        /// </summary>
        NotifyAgvTaskMaterialStatusToECM = 5,
        /// <summary>
        /// 通知LIMS质检任务发起
        /// </summary>
        QualityTaskToLIMS = 6
    }
}
