using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WIP_BLL
{
    /// <summary>
    /// IntegerToken
    /// </summary>
    public class IntegerToken
    {
        /// <summary>
        ///systemadmin
        /// </summary>
        public static string systemadmin = BLLHelpler.GetConfigValue("systemadmin");

        /// <summary>
        ///wcsintegrated
        /// </summary>
        public static string wcsintegrated = BLLHelpler.GetConfigValue("wcsintegrated");

        /// <summary>
        /// p3ssintegrated
        /// </summary>
        public static string p3ssintegrated = BLLHelpler.GetConfigValue("p3ssintegrated");
        /// <summary>
        /// limsintegrated
        /// </summary>
        public static string limsintegrated = BLLHelpler.GetConfigValue("limsintegrated");
        /// <summary>
        /// ecmintegrated
        /// </summary>
        public static string ecmintegrated = BLLHelpler.GetConfigValue("ecmintegrated");
        /// <summary>
        /// scheduleintegrated
        /// </summary>
        public static string scheduleintegrated = BLLHelpler.GetConfigValue("scheduleintegrated");
        /// <summary>
        ///mesintegrated
        /// </summary>
        public static string mesintegrated = BLLHelpler.GetConfigValue("mesintegrated");
        /// <summary>
        ///qamsintegrated
        /// </summary>
        public static string qamsintegrated = BLLHelpler.GetConfigValue("qamsintegrated");
    }
}
