using System;
using System.ComponentModel;

namespace WIP_Models
{
    /// <summary>
    /// 推送给WCS的下发处理指令类
    /// </summary>
    public class TestPostIssueTaskModel
    {

        /// <summary>
        /// 任务ID(taskNo不仅是任务ID，还有可能是MES系统的任务ID)
        /// </summary>
        public string taskNo { get; set; }

        /// <summary>
        /// 流转卡号
        /// 流转卡号  与（物料编码）必填一个，如果流转卡号不为空，则优先使用流转卡号
        ///如果是热前出库，那么物料编码吗和数量必填
        ///如果是热后出库，那么流转卡号和物料编码两者选填一个，数量不传
        /// </summary>
        public string processCardNumber { get; set; }


        public string line { get; set; }

    }
}