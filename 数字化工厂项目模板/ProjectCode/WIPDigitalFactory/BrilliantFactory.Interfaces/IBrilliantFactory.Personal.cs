using BrilliantFactory.Interfaces.Faults;
using BrilliantFactory.Interfaces.Model;
using Proficy.Platform.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BrilliantFactory.Interfaces
{
    public partial interface IBrilliantFactory
    {
        [OperationContract]
        [DisplayName("CanLogin")]
        [Description("CanLogin ")]
        [FaultContract(typeof(GeneralFaultException))]
        bool CanLogin(string uName, string uPwd, out string Msg);

        [OperationContract]
        [DisplayName("CanLoginViaDomain")]
        [Description("CanLoginViaDomain ")]
        [FaultContract(typeof(GeneralFaultException))]
        bool CanLoginViaDomain(string uName, string uPwd, string Domain, out string Msg);

        [OperationContract]
        [DisplayName("UpdatePwd")]
        [Description("UpdatePwd ")]
        [FaultContract(typeof(GeneralFaultException))]
        bool UpdatePwd(string uName, string uPwd, string uNewPwd, out string Msg);

        [OperationContract]
        [DisplayName("GetPersonalProperties")]
        [Description("GetPersonalProperties ")]
        [FaultContract(typeof(GeneralFaultException))]
        IEnumerable<PersonalProperties> GetPersonalProperties(string uName, out string Msg, List<string> proNames);
    }
}
