using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;

namespace WIP_Models
{
    /// <summary>
    /// 需要的打印实体类
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Serializable]
    public class PrintInfoModel
    {
        /// <summary>
        /// 删除标记(注意：这个标记用于标记是否只打印，不管业务；true：只打印不管业务；false：不仅打印，还管业务,比如下料完成要给立库推送通知)
        /// </summary>
        public bool? delFlag { get; set; }

        /// <summary>
        /// 打印信息ID
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// 流转卡号
        /// </summary>
        public string processCardNumber { get; set; }

        /// <summary>
        /// 打印机名称
        /// </summary>
        public string printerName { get; set; }

        /// <summary>
        /// 模板名称
        /// </summary>
        public string tempName { get; set; }

        /// <summary>
        /// 打印区域
        /// </summary>
        public string printArea { get; set; }

        /// <summary>
        /// 打印字符串
        /// </summary>
        public string printJson { get; set; }

        /// <summary>
        /// 打印类型
        /// </summary>
        public string printType { get; set; }

    }
}