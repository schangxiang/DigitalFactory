
using KAOP;
using Newtonsoft.Json;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Configuration;
using System.Data;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Threading;
using System.Threading.Tasks;
using WIP_BLL;
using WIP_common;
using WIP_DAL;
using WIP_IBLL;
using WIP_Models;
using WIP_Print;

namespace WIP_MES
{
    
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [WipLogAop("WIP_MES.MesSysInteg", WipSource.WIPREST)]
    /// <summary>
    /// MES集成
    /// </summary>
    public partial class MesSysInteg : KAopContextBoundObject, IMesSysInteg
    {

        private string namespaceName = "WIP_MES.MesSysInteg";//命名空间

        public MesSysInteg()
        {
        }
    }
}

