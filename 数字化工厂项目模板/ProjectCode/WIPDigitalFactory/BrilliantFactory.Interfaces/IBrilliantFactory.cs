using System;
using System.Collections.Generic;
using System.ServiceModel;
using Proficy.Platform.ServiceModel;
using Proficy.Platform.Core.ProficySystem.Types;
using BrilliantFactory.Interfaces.Faults;
using System.Data;
using System.Collections.ObjectModel;
using Proficy.Platform.ServiceModel.Compatibility;

namespace BrilliantFactory.Interfaces
{
    [ServiceContract(Name = "IBrilliantFactory", SessionMode = SessionMode.Allowed)]
    [Description("POC for BrilliantFactory")]
    [DisplayName("IBrilliantFactory")]
    public partial interface IBrilliantFactory
    {

        [OperationContract]
        [DisplayName("LogAction")]
        [Description("LogAction ")]
        [FaultContract(typeof(GeneralFaultException))]
        string LogAction(string cFunction, string cDescription, DateTime dDate);

        [OperationContract]
        [DisplayName("HandShake")]
        [Description("HandShake ")]
        [FaultContract(typeof(GeneralFaultException))]
        bool HandShake();
    }
}
