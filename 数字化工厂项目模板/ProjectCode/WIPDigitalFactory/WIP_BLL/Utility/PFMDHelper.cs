
using SysManager.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIP_PFMD;

namespace WIP_BLL
{
    public class PFMDHelper
    {
        #region 单例模式(饿汉模式)

        private static PFMDHelper _instance = null;
        private PFMDHelper() { }
        static PFMDHelper()
        {
            _instance = new PFMDHelper();
        }

        public static PFMDHelper GetInstance()
        {
            return _instance;
        }
        #endregion


        public PfmdComm GetPfmdCommObject()
        {
            string url = ConfigHelper.GetValue("GEBF_URL");
            return new PfmdComm(url);
        }
    }
}
