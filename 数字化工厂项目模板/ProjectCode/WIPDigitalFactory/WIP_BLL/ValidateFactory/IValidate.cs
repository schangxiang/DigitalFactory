using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIP_Models;

namespace WIP_BLL
{
    public interface IValidate
    {
        ReturnBody<T2> Validate<T1, T2>(T1 param, ref ExceptionInfoEntity exception);
    }
}
