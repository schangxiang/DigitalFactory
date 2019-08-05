using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIP_Models
{

    /// <summary>
    /// 打印流转卡枚举类
    /// </summary>
    public enum PrintStatus
    {
        /// <summary>
        /// 待打印
        /// </summary>
        ToPrint = 0,
        /// <summary>
        /// 打印中
        /// </summary>
        Printing = 1,
        /// <summary>
        /// 已打印
        /// </summary>
        HasPrint = 2,
        /// <summary>
        /// 打印错误
        /// </summary>
        PrintError = 3,
        /// <summary>
        /// 下料中
        /// </summary>
        Blanking = 4,
        /// <summary>
        /// 下料完成
        /// </summary>
        BlankCompleted = 5,
        /// <summary>
        /// 下料错误 [EditBy shaocx,2019-03-02]
        /// </summary>
        BlankFailure = 6
    };


}
