
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIP_Models
{
    /// <summary>
    /// 邮箱人员视图类
    /// </summary>
    public class MailPersonModel : MailPersonEntity
    {
        /// <summary>
        /// 邮件类别名称
        /// </summary>
        public string categoryName { get; set; }
    }
}
