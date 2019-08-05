using System;
using System.ComponentModel;

namespace WIP_Models
{
    /// <summary>
    /// 更新质量预测结果类
    /// </summary>
    public class UpdateInspectionSummaryParam
    {
        public string taskNo { get; set; }
        /// <summary>
        /// 质量预测结果
        /// </summary>
        public int qamsResult { get; set; }

        /// <summary>
        /// loadNumber
        /// </summary>
        public string loadNumber { get; set; }


        public string line { get; set; }

        /// <summary>
        /// 质量预测结果描述
        /// </summary>
        public string predictionRemarks { get; set; }

    }
}