using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIP_Models
{
    /// <summary>
    /// 质检状态枚举类
    /// </summary>
    public enum QAStatus
    {
        /// <summary>
        /// 待检
        /// </summary>
        [Description("待检")]
        PreQA = 3,

        /// <summary>
        /// 合格
        /// </summary>
        [Description("合格")]
        Qualified = 1,

        /// <summary>
        /// 不合格
        /// </summary>
        [Description("不合格")]
        Disqualification = 2
    }
}
