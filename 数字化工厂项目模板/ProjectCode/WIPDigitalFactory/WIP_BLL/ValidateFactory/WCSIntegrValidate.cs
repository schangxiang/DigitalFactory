/*
 * CLR Version：4.0.30319.42000
 * NameSpace：WIP_BLL.ValidateFactory
 * FileName：WCSIntegrValidate
 * CurrentYear：2019
 * CurrentTime：2019/5/27 15:03:23
 * Author：shaocx
 *
 * <更新记录>
 * ver 1.0.0.0   2019/5/27 15:03:23 新規作成 (by shaocx)
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIP_Models;

namespace WIP_BLL
{
    public abstract class WCSIntegrValidate : IValidate
    {
        public abstract ReturnBody<T2> Validate<T1, T2>(T1 param, ref ExceptionInfoEntity exception);

    }
}
