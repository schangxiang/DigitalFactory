/*
 * CLR Version：4.0.30319.42000
 * NameSpace：WIP_BLL.ValidateFactory.Factory.Default
 * FileName：ValidateInStoreFactory
 * CurrentYear：2019
 * CurrentTime：2019/5/28 9:49:59
 * Author：shaocx
 *
 * <更新记录>
 * ver 1.0.0.0   2019/5/28 9:49:59 新規作成 (by shaocx)
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIP_BLL
{
    /// <summary>
    /// 入库验证工厂
    /// </summary>
    public class ValidateInStoreFactory : IValidateFactory
    {
        public IValidate CreateValidate()
        {
            return new WIW_InStore();
        }
    }
}
