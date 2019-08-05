using Microsoft.IdentityModel.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using WIP_DAL;
using WIP_Models;

namespace WIP_common
{
    public class WIPCommon
    {
       
        /// <summary>
        /// 生成当前时间的批次号
        /// </summary>
        /// <returns></returns>
        public static string GenerateBatchNo()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }


        /// <summary>
        /// 获取工艺号（分割组合的工艺号）
        /// </summary>
        /// <param name="recipeGroup">组合的工艺指令号( 格式：物料编码  试制品工艺指令号 )</param>
        /// <param name="recipeNumber">工艺号</param>
        /// <returns>物料编码</returns>
        public static string GetTrialRroMaterialcode(string recipeGroup, out string recipeNumber)
        {
            if (string.IsNullOrEmpty(recipeGroup))
            {
                throw new Exception("工艺号不能为空");
            }
            //分割 两个空格
            string[] arr = Regex.Split(recipeGroup, "  ", RegexOptions.IgnoreCase);
            if (arr.Length != 2)
            {
                throw new Exception("工艺号格式不正确");
            }
            recipeNumber = arr[1];
            return arr[0];
        }

        /// <summary>
        /// 转换ECM时间戳（所有ECM传递过来的时间戳都要减去8个小时）
        /// </summary>
        /// <param name="timestamp"></param>
        /// <returns>0时区的时间戳</returns>
        public static long ConvertUnixtimeStampFormECM(long timestamp)
        {
            if (timestamp == 0)
                return timestamp;

            return timestamp - 28800;
        }

        /// <summary>
        /// 转换ECM时间戳（所有ECM传递过来的时间戳都要减去8个小时）
        /// </summary>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        public static long? ConvertUnixtimeStampFormECM(long? timestamp)
        {
            if (timestamp == null)
                return timestamp;

            long new_timestamp = Convert.ToInt64(timestamp);
            if (new_timestamp == 0)
                return new_timestamp;

            return new_timestamp - 28800;
        }

        /// <summary>
        /// 根据任务ID验证是否是正常的生产ID
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool ValidateIsNoramlProd(string taskNo)
        {
            //判断
            var f_taskNo = taskNo.Substring(0, 1);
            if (f_taskNo.ToUpper() == "R" || f_taskNo.ToUpper() == "S")
            {//说明是 热后 不良品出库或报废出库
                return false;
            }
            return true;
        }





        /// <summary>
        /// 对象互转
        /// </summary>
        /// <typeparam name="T1">原对象</typeparam>
        /// <typeparam name="T2">新对象</typeparam>
        /// <param name="param">原对象</param>
        /// <returns></returns>
        public static T2 T1ToT2<T1, T2>(T1 param)
        {
            string json = JsonConvert.SerializeObject(param);
            return JsonConvert.DeserializeObject<T2>(json);
        }


        /*
        /// <summary>
        /// 当前时间生成Unix时间戳（东八区） 
        /// </summary>
        /// <returns>当前时间减去 1970-01-01 00.00.00 得到的秒数</returns>
        public static long GetUnixTimeStampWithlocals()
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
            DateTime nowTime = DateTime.Now;
            long unixTime = (long)System.Math.Round((nowTime - startTime).TotalSeconds, MidpointRounding.AwayFromZero);
            return unixTime;
        }

        //*/

        /// <summary>
        /// 当前时间生成Unix时间戳(格林威治时间,毫秒) 
        /// </summary>
        /// <returns>当前时间减去 1970-01-01 00.00.00 得到的毫秒数</returns>
        public static long GetUnixTimeStampWithGLWZForMilliSeconds()
        {
            DateTime startTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            DateTime nowTime = DateTime.Now;
            long unixTime = (long)System.Math.Round((nowTime - startTime).TotalMilliseconds, MidpointRounding.AwayFromZero);
            return unixTime;
        }

        /// <summary>
        /// 当前时间生成Unix时间戳(格林威治时间,秒) 
        /// </summary>
        /// <returns>当前时间减去 1970-01-01 00.00.00 得到的秒数</returns>
        public static long GetUnixTimeStampWithGLWZForSeconds()
        {
            DateTime startTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            DateTime nowTime = DateTime.Now;
            long unixTime = (long)System.Math.Round((nowTime - startTime).TotalSeconds, MidpointRounding.AwayFromZero);
            return unixTime;
        }


        /// <summary>
        /// 当前时间生成Unix时间戳(北京时区,秒) 
        /// </summary>
        /// <returns>当前时间减去 1970-01-01 00.00.00 得到的秒数</returns>
        public static long GetUnixTimeStampWithBJForSeconds()
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
            DateTime nowTime = DateTime.Now;
            long unixTime = (long)System.Math.Round((nowTime - startTime).TotalSeconds, MidpointRounding.AwayFromZero);
            return unixTime;
        }


        /// <summary>
        /// 格林威治时间戳转换成DateTime，为NUll表示转换失败 
        /// 格式:  日/月/年 时:分:秒
        /// </summary>
        /// <param name="greenwichTimeStampStr"></param>
        /// <returns></returns>
        public static DateTime? ForamtGreenwichTimeStampToDateTime(string greenwichTimeStampStr)
        {
            var yyyy = "";
            var MM = "";
            var dd = "";
            var hh = "";
            var mm = "";
            var ss = "";
            var newDate = "";
            var nowDate = DateTime.Now;
            try
            {

                if (!string.IsNullOrEmpty(greenwichTimeStampStr))
                {
                    var dates = greenwichTimeStampStr.Split(' ');
                    if (dates.Length != 2)
                    {
                        return null;
                    }
                    var yyMMdd = dates[0];
                    var yyMMdds = yyMMdd.Split('/');
                    if (yyMMdds.Length != 3)
                        return null;

                    yyyy = yyMMdds[2];
                    MM = yyMMdds[1];
                    dd = yyMMdds[0];

                    var hhmmss = dates[1];
                    var hhmmss_s = hhmmss.Split(':');
                    if (hhmmss_s.Length != 3)
                        return null;

                    hh = hhmmss_s[0];
                    mm = hhmmss_s[1];
                    ss = hhmmss_s[2];


                    newDate = yyyy + "-" + MM.PadLeft(2, '0') + "-" + dd.PadLeft(2, '0')
                        + " " +
                        hh.PadLeft(2, '0') + ":" + mm.PadLeft(2, '0') + ":" + ss.PadLeft(2, '0');
                    return Convert.ToDateTime(newDate);
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 当地时间转换为格林威治时间戳
        /// </summary>
        /// <returns></returns>
        public static string ForamtCurDateTimeToGreenwichTimeStamp()
        {
            return DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        /// <summary>  
        /// ECM Unix时间戳转为C#格式时间  
        /// </summary>  
        /// <param name="timeStamp">Unix时间戳格式</param>  
        /// <returns>C#格式时间</returns>  
        public static DateTime UnixTimeStampToDateTimeByECM(long timeStamp)
        {
            //注意：ECM传递过来的unix时间戳都是东8区时间，WIP在接收的时候已经将其减去8小时了（即格林威治时间）
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            var c_date = dtStart.Add(toNow);
            return c_date;
        }

        /// <summary>
        /// ECM Unix时间戳转为格式化日期成字符串(yyyy-MM-dd HH:mm:ss)
        /// </summary>
        /// <param name="timeStamp">Unix时间戳格式</param>
        /// <returns>格式化日期成字符串(yyyy-MM-dd HH:mm:ss)</returns>
        public static string UnixTimeStampToDateTimeStringByECM(long timeStamp)
        {
            DateTime dt = UnixTimeStampToDateTimeByECM(timeStamp);
            return FormatDateTime(dt);
        }




        /// <summary>
        /// 格式化当前日期成字符串(yyyy-MM-dd HH:mm:ss)
        /// </summary>
        /// <returns></returns>
        public static string ForamtCurDateTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 格式化当前日期成字符串(到毫秒的小数精度为七位。其余数字被截断。)
        /// </summary>
        /// <returns></returns>
        public static string ForamtCurDateTimeWithF()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fffffff");
        }

        /// <summary>
        /// 格式化日期成字符串(yyyy-MM-dd HH:mm:ss)
        /// </summary>
        /// <returns></returns>
        public static string FormatDateTime(DateTime? datetime)
        {
            if (datetime == null)
                return "";
            var myDateTime = Convert.ToDateTime(datetime);
            return myDateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 格式化日期成字符串(yyyy-MM-dd HH:mm:ss:fff)
        /// </summary>
        /// <returns></returns>
        public static string FormatDateTimePreciseToFFF(DateTime? datetime)
        {
            if (datetime == null)
                return "";
            var myDateTime = Convert.ToDateTime(datetime);
            return myDateTime.ToString("yyyy-MM-dd HH:mm:ss:fff");
        }

        /// <summary>
        /// 格式化日期成字符串(yyyyMMdd hh:mm:ss)
        /// </summary>
        /// <returns></returns>
        public static string FormatDateTimeToyyyyMMdd(DateTime? datetime)
        {
            if (datetime == null)
                return "";
            var myDateTime = Convert.ToDateTime(datetime);
            return myDateTime.ToString("yyyyMMdd hh:mm:ss");
        }



        /// <summary>
        /// 更新条件添加最后修改人和最后修改时间
        /// </summary>
        /// <param name="lastModifier"></param>
        /// <param name="proParamList"></param>
        public static void AddLastModifyTimeFilter(string lastModifier, ref List<PropertyParam> proParamList)
        {
            proParamList.Add(new PropertyParam() { PropertyName = "lastModifier", ObjectValue = lastModifier, dbType = SqlDbType.NVarChar, size = 50 });
            proParamList.Add(new PropertyParam() { PropertyName = "lastModifyTime", ObjectValue = DateTime.Now, dbType = SqlDbType.DateTime });
        }

        /// <summary>
        /// 更新条件添加最后修改人和最后修改时间(更新任务表专用)
        /// </summary>
        /// <param name="lastModifier"></param>
        /// <param name="proParamList"></param>
        public static void AddLastModifyTimeFilterForTask(string lastModifier, string timestamp, ref List<PropertyParam> proParamList)
        {
            AddLastModifyTimeFilter(lastModifier, ref proParamList);
            proParamList.Add(new PropertyParam() { PropertyName = "timestamp", ObjectValue = Convert.ToDateTime(timestamp), dbType = SqlDbType.DateTime });
        }

        /// <summary>
        /// List<T>转换DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataTable ListToDataTable<T>(IList<T> list)
        {
            Type type = typeof(T);
            PropertyInfo[] proInfo = type.GetProperties();
            DataTable dt = new DataTable();
            foreach (PropertyInfo p in proInfo)
            {
                //类型存在Nullable<Type>时，需要进行以下处理，否则异常
                Type t = p.PropertyType;
                if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>))
                    t = t.GetGenericArguments()[0];
                dt.Columns.Add(p.Name, t);
            }
            foreach (T t in list)
            {
                DataRow dr = dt.NewRow();
                foreach (PropertyInfo p in proInfo)
                {
                    object obj = p.GetValue(t);
                    if (obj == null) continue;
                    if (p.PropertyType == typeof(DateTime) && Convert.ToDateTime(obj) < Convert.ToDateTime("1753-01-01"))
                        continue;
                    dr[p.Name] = obj;
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }


        /// <summary>
        /// 根据系统编码获取响应的邮件类型ID
        /// </summary>
        /// <param name="sysCode"></param>
        /// <returns></returns>
        public static string GetMailCategoryBySysIntegr(string sysCode)
        {
            string ret = "";
            switch (sysCode)
            {
                case SysCode.ECM:
                    ret = MailCategory.ECM系统集成;
                    break;
                case SysCode.MES:
                    ret = MailCategory.MES系统集成;
                    break;
                case SysCode.LIMS:
                    ret = MailCategory.LIMS系统集成;
                    break;
                case SysCode.WCS:
                    ret = MailCategory.WCS系统集成;
                    break;
                case SysCode.RCS:
                    ret = MailCategory.RCS系统集成;
                    break;
                case SysCode.P3SS:
                    ret = MailCategory.P3SS系统集成;
                    break;
                case SysCode.QAMS:
                    ret = MailCategory.QAMS系统集成;
                    break;
                case SysCode.SCHEDULE:
                    ret = MailCategory.排产系统集成;
                    break;
                default:
                    ret = MailCategory.缺省;
                    break;
            }
            return ret;
        }




        /// <summary>
        /// 分钟转换为秒
        /// </summary>
        /// <param name="minutes"></param>
        /// <returns></returns>
        public static long? MinutesToSeconds(long? minutes)
        {
            if (minutes != null)
            {
                return Convert.ToInt64(minutes) * 60;
            }
            return minutes;
        }

        /// <summary>
        /// 获取当前Host
        /// </summary>
        /// <param name="msgSource">消息来源</param>
        /// <returns></returns>
        public static string GetHostName(string msgSource = WipSource.WIPREST)
        {
            return Dns.GetHostName() + "_" + msgSource;
        }



    }
}
