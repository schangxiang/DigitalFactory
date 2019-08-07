/*
 * CLR Version：4.0.30319.42000
 * NameSpace：WIP_BLL.ValidateFactory.Factory.Default
 * FileName：UserLoginLogValiFactory
 * CurrentYear：2019
 * CurrentTime：2019/8/7 14:50:33
 * Author：shaocx
 *
 * <更新记录>
 * ver 1.0.0.0   2019/8/7 14:50:33 新規作成 (by shaocx)
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIP_BLL
{
    public class UserLoginLogValiFactory : IValidateFactory
    {

        public IValidate CreateValidate()
        {
            return new WIW_UserLoginLog();
        }
    }
}
