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

        public static IPrintInfoDAL CreatePrintInfoDAL()
        {
            string className = path + ".PrintInfoDAL";
            return (IPrintInfoDAL)Assembly.Load(path).CreateInstance(className);
        }

        public static IUserLoginLogDAL CreateUserLoginLogDAL()
        {
            string className = path + ".UserLoginLogDAL";
            return (IUserLoginLogDAL)Assembly.Load(path).CreateInstance(className);
        }

        
        private object CreateObject(string assemblyPath,string classNamespace)
        {
            return null;
        }

        //*/
    }
}
