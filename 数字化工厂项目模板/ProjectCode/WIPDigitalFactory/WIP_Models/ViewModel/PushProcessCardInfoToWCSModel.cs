using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIP_Models
{
    /// <summary>
    /// 流转卡信息提交给WCS返回实体
    /// </summary>
    public class PushProcessCardInfoToWCSModel
    {
        /// <summary>
        /// 是否允许入库(Y/N)
        /// </summary>
        public string success { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string msg { get; set; }

    }
}
