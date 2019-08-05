using log4net;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using WIP_DAL;
using WIP_Models;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace WIP_common
{
    /// <summary>
    /// 日志帮助
    /// </summary>
    public class LogHelper
    {
        [Obsolete("方法不用啦")]
        public static void AddTextLog(string log)
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("c:\\Logs\\wip_log.txt", true))
            {
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "  " + log);
            }
        }

        /// <summary>
        /// 输出异常日志到Log4Net
        /// </summary>
        /// <param name="t"></param>
        /// <param name="msg"></param>
        public static void WriteErrorLogByLog4Net(Type t, string msg, Exception ex = null)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(t);
            log.Error(msg, ex);
        }
        /// <summary>
        /// 输出info日志到Log4Net
        /// </summary>
        /// <param name="t"></param>
        /// <param name="msg"></param>
        public static void WriteInfoLogByLog4Net(Type t, string msg)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(t);
            log.Info(msg);
        }

    }
}
