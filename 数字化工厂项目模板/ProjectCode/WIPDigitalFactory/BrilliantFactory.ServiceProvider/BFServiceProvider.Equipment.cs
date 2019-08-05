using Proficy.Platform.Core.DOR.Interfaces;
using Proficy.Platform.Core.ProficySystem.MobileObject;
using Proficy.Platform.Core.ProficySystem.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Proficy.Platform.Services.Equipment.Interfaces;
using Proficy.Platform.Core.Dms.Dmfc.SystemDataModel.DynamicObjectModel;

namespace BrilliantFactory.ServiceProvider
{
    public partial class BFServiceProvider
    {


        public IEnumerable<string> GetProductionLines(string plantName)
        {
            List<string> productionLines = new List<string>();

            try
            {
                string storedProcedureName = "uspWip_GetProductionLines";
                List<Parameter> inputParams = new List<Parameter>();
                inputParams.Add(new Parameter("@plantName", new CrudItem(1, plantName)));
                var spResult = DBmanager.ExecuteProcedure(storedProcedureName, inputParams);
                if (spResult != null)
                {
                    for (var i = 0; i < spResult.FirstTable.Rows.Count; i++)
                    {
                        productionLines.Add(spResult.FirstTable.Rows[i]["S95Id"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                this.ServiceDirManager.ILog.Error("Error at GetProductionLines: \n" + ex.Message);
            }

            return productionLines;
        }


        /// <summary>
        /// 根据生产线查找立库出库的自动化出口
        /// </summary>
        /// <param name="prodlineName">生产线名称</param>
        /// <returns>自动化出口名称</returns>
        public string GetAutoExitByProdLineForWCS(string prodlineName)
        {
            List<string> workCellList = new List<string>();
            try
            {
                string storedProcedureName = "uspWip_GetLineListByProdLine";
                List<Parameter> inputParams = new List<Parameter>();
                inputParams.Add(new Parameter("@prodlineName", new CrudItem(1, prodlineName)));
                var spResult = DBmanager.ExecuteProcedure(storedProcedureName, inputParams);
                if (spResult != null)
                {
                    for (var i = 0; i < spResult.FirstTable.Rows.Count; i++)
                    {
                        workCellList.Add(spResult.FirstTable.Rows[i]["S95Id"].ToString());
                    }
                }
                if (workCellList.Count > 0)
                {
                    DirectoryResource dir;
                    IDictionary<string, PropertyDetails> dict;
                    foreach (var item in workCellList)
                    {
                        //查找是否是自动出口
                        dir = EQManager.GetWorkCell(item);
                        dict = this.ServiceDirManager.IEquipment.GetPropertyDetails(dir, true);
                        if (dict != null && dict.Count > 0 && dict.ContainsKey("AutoType"))
                        {
                            if (dict["AutoType"] != null && dict["AutoType"].Value != null && dict["AutoType"].Value.ToString() == "1")
                            {
                                return item;
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                this.ServiceDirManager.ILog.Error("Error at GetAutoExitByProdLineForWCS: \n" + ex.Message);
                throw;
            }
            return string.Empty;
        }

        /// <summary>
        /// 根据生产线查找生产线的上/下料口
        /// </summary>
        /// <param name="line">生产线号</param>
        /// <param name="orificeFlag">料口类型(1上料口 2下料口)</param>
        /// <returns>生产线的上/下料口</returns>
        public string GetEcmOrificeByLine(string line, string orificeFlag)
        {
            List<string> workCellList = new List<string>();
            try
            {
                string storedProcedureName = "uspWip_GetLineListByProdLine";
                List<Parameter> inputParams = new List<Parameter>();
                inputParams.Add(new Parameter("@prodlineName", new CrudItem(1, line)));
                var spResult = DBmanager.ExecuteProcedure(storedProcedureName, inputParams);
                if (spResult != null)
                {
                    for (var i = 0; i < spResult.FirstTable.Rows.Count; i++)
                    {
                        workCellList.Add(spResult.FirstTable.Rows[i]["S95Id"].ToString());
                    }
                }
                if (workCellList.Count > 0)
                {
                    DirectoryResource dir;
                    IDictionary<string, PropertyDetails> dict;
                    foreach (var item in workCellList)
                    {
                        //查找是否是 生产线的料口
                        dir = EQManager.GetWorkCell(item);
                        dict = this.ServiceDirManager.IEquipment.GetPropertyDetails(dir, true);
                        if (dict != null && dict.Count > 0 && dict.ContainsKey("EquipmentType"))
                        {//EquipmentType(设备类型 1上料口 2下料口)
                            if (dict["EquipmentType"] != null && dict["EquipmentType"].Value != null
                                && dict["EquipmentType"].Value.ToString() == orificeFlag)
                            {
                                return item;
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                this.ServiceDirManager.ILog.Error("Error at GetLoadOrificeByProdLineForECM: \n" + ex.Message);
                throw;
            }
            return string.Empty;
        }

        /// <summary>
        /// 根据产线名称获取产线下的所有WorkCell
        /// </summary>
        /// <param name="prodlineName">产线名称</param>
        /// <returns></returns>
        public IEnumerable<string> GetLineListByProdLine(string prodlineName)
        {
            List<string> workCellList = new List<string>();
            try
            {
                string storedProcedureName = "uspWip_GetLineListByProdLine";
                List<Parameter> inputParams = new List<Parameter>();
                inputParams.Add(new Parameter("@prodlineName", new CrudItem(1, prodlineName)));
                var spResult = DBmanager.ExecuteProcedure(storedProcedureName, inputParams);
                if (spResult != null)
                {
                    for (var i = 0; i < spResult.FirstTable.Rows.Count; i++)
                    {
                        workCellList.Add(spResult.FirstTable.Rows[i]["S95Id"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                this.ServiceDirManager.ILog.Error("Error at GetLineListByProdLine: \n" + ex.Message);
                throw;
            }
            return workCellList;
        }

        public String[] testEquipment(string line)
        {
            List<String> ttt = new List<String>();
            var allValues = this.ServiceDirManager.IEquipment.ReadAllEquipmentValues(EQManager.GetProductionLine(line));
            foreach (var iV in allValues)
            {
                ttt.Add(iV.Key + ":" + iV.Value.StringValue(CultureInfo.CurrentCulture));
            }

            ttt.Add("↑↑↑↑↑↑ReadAllEquipmentValues");
            //var values = this.ServiceDirManager.IEquipment.ReadEquipmentValues(EQManager.GetProductionLine(line));
            //;

            //ttt.Add("↑↑↑↑↑↑ReadEquipmentValues");



            return ttt.ToArray();
        }

        /// <summary>
        /// 更新设备的属性值
        /// </summary>
        /// <param name="equipName">设备名称</param>
        /// <param name="propertyName">设备属性名称</param>
        /// <param name="value">设备属性值</param>
        public void WriteEquipmentPropertyValue(string equipName, string propertyName, object value)
        {
            try
            {
                DirectoryResource ownerAddress = EQManager.GetWorkCell(equipName);
                this.ServiceDirManager.IEquipment.WriteEquipmentValue(ownerAddress, propertyName, value);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
