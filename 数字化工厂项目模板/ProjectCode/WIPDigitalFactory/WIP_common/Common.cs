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
using WIP_SQLServerDAL;
using WIP_Models;

namespace WIP_common
{
    public class WIPCommon
    {
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
        /// 格式化当前日期成字符串(yyyy-MM-dd HH:mm:ss)
        /// </summary>
        /// <returns></returns>
        public static string ForamtCurDateTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
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
