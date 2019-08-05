using System;
using System.Collections.Generic;
using System.ServiceModel;
using Proficy.Platform.ServiceModel;
using Proficy.Platform.Core.ProficySystem.Types;
using BrilliantFactory.Interfaces.Faults;
using System.Data;
using System.Collections.ObjectModel;

namespace BrilliantFactory.Interfaces
{
    public partial interface IBrilliantFactory
    {

        [OperationContract]
        [DisplayName("GetAllProperty")]
        [Description("GetAllProperty ")]
        [FaultContract(typeof(GeneralFaultException))]
        Dictionary<String, String> GetAllProperty(String materialName);

        [OperationContract]
        [DisplayName("writeProperty")]
        [Description("writeProperty ")]
        [FaultContract(typeof(GeneralFaultException))]
        void writeProperty(String materialName, String propNmae, String value);

        /// <summary>
        /// 批量修改物料属性值
        /// </summary>
        /// <param name="materialName">物料号</param>
        /// <param name="propDict">物料属性字典集合</param>
        [OperationContract]
        [DisplayName("batchWriteProperty")]
        [Description("batchWriteProperty ")]
        [FaultContract(typeof(GeneralFaultException))]
        bool batchWriteProperty(String materialName, IDictionary<string, string> propDict);
        

        /// <summary>
        /// 创建物料
        /// </summary>
        /// <param name="materialName">物料号</param>
        /// <param name="description">描述</param>
        [OperationContract]
        [DisplayName("createMaterial")]
        [Description("createMaterial ")]
        [FaultContract(typeof(GeneralFaultException))]
        bool createMaterial(String materialName, string description);

        /// <summary>
        /// 获取所有物料号
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [DisplayName("getAllMaterials")]
        [Description("getAllMaterials ")]
        [FaultContract(typeof(GeneralFaultException))]
        List<string> getAllMaterials();


        /// <summary>
        /// 获取物料对应关系
        /// </summary>
        /// <returns>0:partNumber;1:materialCode;2:出熱mes物料編碼</returns>
        [OperationContract]
        [DisplayName("getMaterialMapping")]
        [Description("getMaterialMapping ")]
        [FaultContract(typeof(GeneralFaultException))]
        String[] getMaterialMapping(String materialOrPart);
    }
}
