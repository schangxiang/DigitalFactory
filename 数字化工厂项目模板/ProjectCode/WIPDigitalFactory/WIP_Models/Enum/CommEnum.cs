using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIP_Models
{
    /// <summary>
    /// 设备警告信息事件代码枚举
    /// </summary>
    public enum EqWarnEventCodeEnum
    {
        /// <summary>
        /// 警告触发
        /// </summary>
        Warning = 0,
        /// <summary>
        /// 警告已修复
        /// </summary>
        WarnRepaired = 1
    }
    /// <summary>
    /// 异常级别枚举
    /// </summary>
    public enum ExceptionLevel
    {
        /// <summary>
        /// 警告
        /// </summary>
        Warning = 0,
        /// <summary>
        /// 异常错误
        /// </summary>
        Error = 1,
        /// <summary>
        /// 业务错误
        /// </summary>
        BusinessError = 2
    }
    /// <summary>
    /// 异常来源方向枚举
    /// </summary>
    public enum ExceptionSource
    {
        /// <summary>
        /// WIP接收
        /// </summary>
        WIPReceive = 0,
        /// <summary>
        /// WIP推送
        /// </summary>
        WIPPost = 1

    }
}
