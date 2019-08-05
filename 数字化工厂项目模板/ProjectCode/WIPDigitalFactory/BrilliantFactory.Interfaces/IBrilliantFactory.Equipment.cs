using BrilliantFactory.Interfaces.Faults;
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
        [DisplayName("GetProductionLines")]
        [Description("GetProductionLines ")]
        [FaultContract(typeof(GeneralFaultException))]
        IEnumerable<string> GetProductionLines(string plantName);

        /// <summary>
        /// 根据生产线查找自动化出口
        /// </summary>
        /// <param name="prodlineName">生产线名称</param>
        /// <returns>自动化出口名称</returns>
        [OperationContract]
        [DisplayName("GetAutoExitByProdLine")]
        [Description("GetAutoExitByProdLine ")]
        [FaultContract(typeof(GeneralFaultException))]
        string GetAutoExitByProdLineForWCS(string prodlineName);


        /// <summary>
        /// 根据生产线查找生产线的上/下料口
        /// </summary>
        /// <param name="line">生产线号</param>
        /// <param name="orificeFlag">料口类型(1上料口 2下料口)</param>
        /// <returns>生产线的上/下料口</returns>
        [OperationContract]
        [DisplayName("GetLoadOrificeByProdLine")]
        [Description("GetLoadOrificeByProdLine ")]
        [FaultContract(typeof(GeneralFaultException))]
        string GetEcmOrificeByLine(string line, string orificeFlag);


        /// <summary>
        /// 根据产线名称获取产线下的所有WorkCell
        /// </summary>
        /// <param name="prodlineName">产线名称</param>
        /// <returns></returns>
        [OperationContract]
        [DisplayName("GetLineListByProdLine")]
        [Description("GetLineListByProdLine ")]
        [FaultContract(typeof(GeneralFaultException))]
        IEnumerable<string> GetLineListByProdLine(string prodlineName);

        // from zsy test
        [OperationContract]
        [DisplayName("testEquipment")]
        [Description("testEquipment ")]
        [FaultContract(typeof(GeneralFaultException))]
        String[] testEquipment(string plantName);


        [OperationContract]
        [DisplayName("writeEquipmentPropertyValue")]
        [Description("writeEquipmentPropertyValue ")]
        [FaultContract(typeof(GeneralFaultException))]
        void WriteEquipmentPropertyValue(string equipName, string propertyName, object value);
    }
}
