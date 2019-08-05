using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIP_Models
{
   public class UserPassWordParam
    {
        /// <summary>
        /// 账户
        /// </summary>
        public string uName { get; set; }
        /// <summary>
        /// 原密码
        /// </summary>
        public string uPwd { get; set; }
        /// <summary>
        /// 新密码
        /// </summary>
        public string uNewPwd { get; set; }
    }
}
