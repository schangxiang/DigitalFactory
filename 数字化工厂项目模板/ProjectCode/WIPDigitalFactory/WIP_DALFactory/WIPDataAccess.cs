using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysManager.Common.Utilities;
using WIP_IDAL;
using System.Reflection;
using System.Web;

namespace WIP_DALFactory
{
    public class WIPDataAccess
    {
        private static readonly string path = ConfigHelper.GetValue("DBDAL");
        private WIPDataAccess() { }

        /// <summary>
        /// 生成DAL对象
        /// </summary>
        /// <typeparam name="T">DAL接口对象</typeparam>
        /// <param name="dalName">DAL类名</param>
        /// <returns>DAL接口对象</returns>
        public static T CreateDAL<T>(string dalName)
        {
            string className = path + "." + dalName;
            return (T)Assembly.Load(path).CreateInstance(className);
        }


        private object CreateObject(string assemblyPath, string classNamespace)
        {
            return null;
        }

        //*/
    }
}
