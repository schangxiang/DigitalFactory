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
    /// 验证是否允许入库
    /// </summary>
    public class WIW_InStore : WCSIntegrValidate
    {
        public override WIP_Models.ReturnBody<T2> Validate<T1, T2>(T1 param, ref ExceptionInfoEntity exception)
        {
            ReturnBody<T2> retBody = null;

            #region 验证

            retBody = ValidateDataHelper.CommonValidateIsNULL<T1, T2>(param, ref exception);
            if (retBody != null)
            {
                return retBody;
            }

            /*
            ValidateInStoreParam _param = param as ValidateInStoreParam;

            List<ValidateModel> columnsList = new List<ValidateModel>() {
                new ValidateModel(){ ChinaName="流转卡号", DataType=typeof(string), DataValue=_param.processCardNumber },
                new ValidateModel(){ ChinaName="设备号", DataType=typeof(string), DataValue=_param.equipId },
                new ValidateModel(){ ChinaName="时间戳", DataType=typeof(DateTime), DataValue=_param.timestamp }
            };
            retBody = ValidateDataHelper.CommonValidate<T1, T2>(param, ref exception, columnsList);
            if (retBody != null)
            {
                return retBody;
            }
            //*/

            #endregion

            return retBody;
        }
    }

}
