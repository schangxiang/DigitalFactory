using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;

namespace WIP_Models
{
    /// <summary>
    /// 打印实体类
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Serializable]
    public class PrintInfoEntity
    {

        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }


        /// <summary>
        /// 流转卡号
        /// </summary>
        public string processCardNumber { get; set; }

        /// <summary>
        /// 打印字符串
        /// </summary>
        public string printJson { get; set; }

        /// <summary>
        /// 打印时间
        /// </summary>
        public DateTime? printTime { get; set; }

        /// <summary>
        /// 打印标记
        /// </summary>
        public string printFlag { get; set; }

        /// <summary>
        /// 打印类型
        /// </summary>
        public string printType { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string note { get; set; }

        /// <summary>
        /// 删除标记(注意：这个标记用于标记是否只打印，不管业务,true：只打印不管业务，false：不仅打印，还管业务,比如下料完成要给立库推送通知)
        /// </summary>
        public bool? delFlag { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string creator { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? createTime { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        public string lastModifier { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? lastModifyTime { get; set; }

    }
}