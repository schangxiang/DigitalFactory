using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIP_BLL
{
    public interface IMail
    {
        /// <summary>
        /// 发送邮件
        /// </summary>
        void MailSending(string MailSubject, string Describe, string File_Path);
    }
}
