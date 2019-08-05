using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WIP_common;
using WIP_Models;

namespace WIP_BLL
{
    /// <summary>
    /// 验证数据通用类
    /// </summary>
    public static class ValidateDataHelper
    {
        /// <summary>
        /// 公共校验是否为NULL
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="param"></param>
        /// <param name="exception"></param>
        /// <param name="columnsList"></param>
        /// <returns></returns>
        public static WIP_Models.ReturnBody<T2> CommonValidateIsNULL<T1,T2>(T1 param, ref ExceptionInfoEntity exception)
        {
            ReturnBody<T2> retBody = null;
            if (param == null)
            {
                exception.exceptionMsg = ResMsg.PARAMETERNOEMPTY;
                retBody = BLLHelpler.GetReturnBody<T2>(ResCode.PARAMETERNOEMPTY, ResMsg.PARAMETERNOEMPTY, exception);
                return retBody;
            }
            return retBody;
        }

        /// <summary>
        /// 公共校验
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="param"></param>
        /// <param name="exception"></param>
        /// <param name="columnsList"></param>
        /// <returns></returns>
        public static WIP_Models.ReturnBody<T2> CommonValidate<T1, T2>(T1 param, ref ExceptionInfoEntity exception, List<ValidateModel> columnsList)
        {
            ReturnBody<T2> retBody = null;
            if (param == null)
            {
                exception.exceptionMsg = ResMsg.PARAMETERNOEMPTY;
                retBody = BLLHelpler.GetReturnBody<T2>(ResCode.PARAMETERNOEMPTY, ResMsg.PARAMETERNOEMPTY, exception);
                return retBody;
            }
            ValidateResModel res = ValidateDataHelper.ValidateNullOrEmpty(columnsList);
            if (res != null && !res.IsValidate)
            {
                exception.exceptionMsg = res.ValidateMsg;
                return BLLHelpler.GetReturnBody<T2>(ResCode.PARAMETERNOEMPTY, exception.exceptionMsg, exception);
            }
            return retBody;
        }

        /// <summary>
        /// 验证是否为空
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="columnsList"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static ValidateResModel ValidateNullOrEmpty<T>(List<ColumnsModel> columnsList, T model)
        {
            ValidateResModel res = new ValidateResModel() { IsValidate = true };//默认验证通过
            ColumnsModel columnsModel = null;
            PropertyInfo property = null;//属性对象
            Object property_value = null;//属性值
            string str = "";
            for (int j = 0; j < columnsList.Count; j++)
            {
                columnsModel = columnsList[j];
                property = typeof(T).GetProperty(columnsModel.PropertyName.Trim());
                if (property == null)
                    throw new Exception("列名'" + columnsModel.PropertyName + "'不存在类中");

                property_value = property.GetValue(model, null);
                if (property.PropertyType == typeof(DateTime) || property.PropertyType == typeof(DateTime?))
                {
                    try
                    {
                        Convert.ToDateTime(property_value);
                    }
                    catch
                    {
                        res.IsValidate = false;
                        res.ValidateMsg = columnsModel.ChinaName + "时间格式不正确";
                        break;
                    }
                }
                else if (property.PropertyType == typeof(string))
                {
                    str = property_value == null ? "" : Convert.ToString(property_value);
                    if (!columnsModel.IsNullable)
                    {//必输 
                        if (string.IsNullOrEmpty(str.Trim()))
                        {
                            res.IsValidate = false;
                            res.ValidateMsg = columnsModel.ChinaName + "不能为空";
                            break;
                        }
                    }

                    #region 验证日期类型的字符串格式(因为json这边接收的日期类型都是字符串)

                    if (columnsModel.DataType == typeof(DateTime) && !string.IsNullOrEmpty(str))
                    {//如果是日期类型，并且传入的值不为空，则需要验证日期格式是否正确
                        try
                        {
                            Convert.ToDateTime(property_value);
                        }
                        catch
                        {
                            res.IsValidate = false;
                            res.ValidateMsg = columnsModel.ChinaName + "时间格式不正确";
                            break;
                        }
                    }

                    #endregion

                    #region 验证格林威治日期类型的字符串格式(因为json这边接收的日期类型都是字符串)

                    if (columnsModel.DataType == typeof(GreenwichTimeStamp) && !string.IsNullOrEmpty(str))
                    {//如果是日期类型，并且传入的值不为空，则需要验证日期格式是否正确
                        try
                        {
                            DateTime? dt = WIPCommon.ForamtGreenwichTimeStampToDateTime(str);
                            if (dt == null)
                            {
                                res.IsValidate = false;
                                res.ValidateMsg = columnsModel.ChinaName + "格林威治时间格式不正确";
                            }
                        }
                        catch
                        {
                            res.IsValidate = false;
                            res.ValidateMsg = columnsModel.ChinaName + "格林威治时间格式不正确";
                            break;
                        }
                    }

                    #endregion

                }
                else if (property.PropertyType == typeof(int))
                {
                    try
                    {
                        int timestamp = Convert.ToInt32(property_value);
                        if (timestamp == 0)
                        {
                            res.IsValidate = false;
                            res.ValidateMsg = columnsModel.ChinaName + "不能为0";
                            break;
                        }
                    }
                    catch
                    {
                        res.IsValidate = false;
                        res.ValidateMsg = columnsModel.ChinaName + "int格式不正确";
                        break;
                    }
                }
                else if (property.PropertyType == typeof(long))
                {
                    if (columnsModel.DataType == typeof(UnixTimeStamp))
                    {//验证long类型的unix时间戳
                        try
                        {
                            long timestamp = Convert.ToInt64(property_value);
                            if (timestamp == 0)
                            {
                                res.IsValidate = false;
                                res.ValidateMsg = columnsModel.ChinaName + "unix时间戳不能为0";
                                break;
                            }
                        }
                        catch
                        {
                            res.IsValidate = false;
                            res.ValidateMsg = columnsModel.ChinaName + "unix时间戳格式不正确";
                            break;
                        }
                    }
                }
                else if (property.PropertyType == typeof(decimal) || property.PropertyType == typeof(decimal?))
                {

                }
            }
            return res;
        }

        /// <summary>
        /// 验证是否为空
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="columnsList"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static ValidateResModel ValidateNullOrEmpty(List<ValidateModel> columnsList)
        {
            ValidateResModel res = new ValidateResModel() { IsValidate = true };//默认验证通过
            ValidateModel columnsModel = null;
            Object property_value = null;//属性值
            string str = "";
            for (int j = 0; j < columnsList.Count; j++)
            {
                columnsModel = columnsList[j];
                property_value = columnsModel.DataValue;

                #region 验证日期类型的字符串格式(因为json这边接收的日期类型都是字符串)

                if (columnsModel.DataType == typeof(DateTime))
                {//如果是日期类型，并且传入的值不为空，则需要验证日期格式是否正确
                    str = property_value == null ? "" : Convert.ToString(property_value);
                    try
                    {
                        if (!columnsModel.IsNullable)
                        {//必输 
                            if (string.IsNullOrEmpty(str.Trim()))
                            {
                                res.IsValidate = false;
                                res.ValidateMsg = columnsModel.ChinaName + "不能为空";
                                break;
                            }
                        }
                        if (!string.IsNullOrEmpty(str.Trim()))
                        {
                            Convert.ToDateTime(property_value);
                        }
                    }
                    catch
                    {
                        res.IsValidate = false;
                        res.ValidateMsg = columnsModel.ChinaName + "时间格式不正确";
                        break;
                    }
                }

                #endregion
                #region 验证格林威治日期类型的字符串格式(因为json这边接收的日期类型都是字符串)

                else if (columnsModel.DataType == typeof(GreenwichTimeStamp))
                {//如果是日期类型，并且传入的值不为空，则需要验证日期格式是否正确
                    str = property_value == null ? "" : Convert.ToString(property_value);
                    try
                    {
                        if (!columnsModel.IsNullable)
                        {//必输 
                            if (string.IsNullOrEmpty(str.Trim()))
                            {
                                res.IsValidate = false;
                                res.ValidateMsg = columnsModel.ChinaName + "不能为空";
                                break;
                            }
                        }
                        if (!string.IsNullOrEmpty(str.Trim()))
                        {
                            DateTime? dt = WIPCommon.ForamtGreenwichTimeStampToDateTime(str);
                            if (dt == null)
                            {
                                res.IsValidate = false;
                                res.ValidateMsg = columnsModel.ChinaName + "格林威治时间格式不正确";
                            }
                        }
                    }
                    catch
                    {
                        res.IsValidate = false;
                        res.ValidateMsg = columnsModel.ChinaName + "格林威治时间格式不正确";
                        break;
                    }
                }

                #endregion

                else if (columnsModel.DataType == typeof(string))
                {
                    str = property_value == null ? "" : Convert.ToString(property_value);
                    if (!columnsModel.IsNullable)
                    {//必输 
                        if (string.IsNullOrEmpty(str.Trim()))
                        {
                            res.IsValidate = false;
                            res.ValidateMsg = columnsModel.ChinaName + "不能为空";
                            break;
                        }
                    }
                }
                else if (columnsModel.DataType == typeof(int))
                {
                    try
                    {
                        int timestamp = Convert.ToInt32(property_value);
                        if (timestamp == 0)
                        {
                            res.IsValidate = false;
                            res.ValidateMsg = columnsModel.ChinaName + "不能为0";
                            break;
                        }
                    }
                    catch
                    {
                        res.IsValidate = false;
                        res.ValidateMsg = columnsModel.ChinaName + "int格式不正确";
                        break;
                    }
                }
                else if (columnsModel.DataType == typeof(UnixTimeStamp))
                {//验证long类型的unix时间戳
                    try
                    {
                        long timestamp = Convert.ToInt64(property_value);
                        if (timestamp == 0)
                        {
                            res.IsValidate = false;
                            res.ValidateMsg = columnsModel.ChinaName + "unix时间戳不能为0";
                            break;
                        }
                    }
                    catch
                    {
                        res.IsValidate = false;
                        res.ValidateMsg = columnsModel.ChinaName + "unix时间戳格式不正确";
                        break;
                    }
                }
                else if (columnsModel.DataType == typeof(decimal) || columnsModel.DataType == typeof(decimal?))
                {

                }
            }
            return res;
        }

    }
}
