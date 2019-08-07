/*
 * CLR Version：4.0.30319.42000
 * NameSpace：WIP_BLL.ValidateFactory.WCSIntegrValidate
 * FileName：WIW_ValidateInStore
 * CurrentYear：2019
 * CurrentTime：2019/5/27 15:06:37
 * Author：shaocx
 *
 * <更新记录>
 * ver 1.0.0.0   2019/5/27 15:06:37 新規作成 (by shaocx)
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIP_common;
using WIP_Models;

namespace WIP_BLL
{
    /// <summary>
    /// 验证查看日志记录参数
    /// </summary>
    public class WIW_UserLoginLog : IValidate
    {
        public WIP_Models.ReturnBody<T2> Validate<T1, T2>(T1 param, ref ExceptionInfoEntity exception)
        {
            ReturnBody<T2> retBody = null;

            #region 验证

            retBody = ValidateDataHelper.CommonValidateIsNULL<T1, T2>(param, ref exception);
            if (retBody != null)
            {
                return retBody;
            }


            string _userName = param as string;

            if (string.IsNullOrEmpty(_userName))
            {
                retBody = new ReturnBody<T2>()
                {
                    resCode = ResCode.PARAMETERNOEMPTY,
                    resMsg = "查询登录名不能为空"
                };
            }

            #endregion

            return retBody;
        }
    }

}
