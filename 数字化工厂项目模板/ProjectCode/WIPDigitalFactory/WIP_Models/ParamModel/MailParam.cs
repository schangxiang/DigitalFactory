using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIP_Models
{
    /// <summary>
    /// 邮件参数类
    /// </summary>
    public class MailParam
    {
        /// <summary>
        /// 邮件标题
        /// </summary>
        public string mailSubject { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string describe { get; set; }

        /// <summary>
        /// 附件
        /// </summary>
        public string file_Path { get; set; }



    }
}
