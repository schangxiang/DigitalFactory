using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WIP_BLL;
using KAOP;
using WIP_Models;

namespace WIP_WIPMgmt
{
    // 在制品跟踪
    [WipLogAop("WIP_WIPMgmt.WipMgmt", WipSource.WIPREST)]
    public partial class WipMgmt : KAopContextBoundObject,IWipMgmt
    {

    }
}
