/*
 * CLR Version：4.0.30319.42000
 * NameSpace：WIP_BLL.ValidateFactory.Factory
 * FileName：IValidateFactory
 * CurrentYear：2019
 * CurrentTime：2019/5/28 9:48:17
 * Author：shaocx
 *
 * <更新记录>
 * ver 1.0.0.0   2019/5/28 9:48:17 新規作成 (by shaocx)
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIP_BLL
{
    public interface IValidateFactory
    {
        IValidate CreateValidate();
    }
}
