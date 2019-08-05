using BrilliantFactory.DataModel;
using Proficy.Platform.Core.ProficySystem.MobileObject;
using Proficy.Platform.Core.ProficySystem.Types;
using Proficy.Platform.Services.Material.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Proficy.Platform.Services.Production.Common;

namespace BrilliantFactory.ServiceProvider
{
    public partial class BFServiceProvider
    {
       
        public Dictionary<String, String> GetAllProperty(String materialName)
        {
            try
            {
                DirectoryResource material = MDManager.GetMaterialDefinition(materialName);
                if (material == null)
                {
                    return null;
                }
                NameDataValueCollection allValues = this.ServiceDirManager.IMaterial.ReadAllMaterialValues(material);
                Dictionary<String, String> res = new Dictionary<String, String>();
                foreach (var iV in allValues)
                {
                    res.Add(iV.Key, iV.Value.StringValue(CultureInfo.CurrentCulture));
                }
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void writeProperty(String materialName, String propNmae, String value)
        {
            DirectoryResource material = MDManager.GetMaterialDefinition(materialName);
            this.ServiceDirManager.IMaterial.WriteMaterialValue(material, propNmae, value);
        }

        /// <summary>
        /// 批量修改物料属性值
        /// </summary>
        /// <param name="materialName">物料号</param>
        /// <param name="propDict">物料属性字典集合</param>
        public bool batchWriteProperty(String materialName, IDictionary<string, string> propDict)
        {
            bool result = false;
            try
            {
                DirectoryResource material = MDManager.GetMaterialDefinition(materialName);
                if (material != null && propDict != null)
                {
                    IMaterial iMaterial = this.ServiceDirManager.IMaterial;
                    foreach (var item in propDict.Keys)
                    {
                        iMaterial.WriteMaterialValue(material, item, propDict[item]);
                    }
                    result = true;
                }
            }
            catch
            {
                throw;
            }
            return result;
        }

        /// <summary>
        /// 创建物料
        /// </summary>
        /// <param name="materialName">物料号</param>
        /// <param name="description">描述</param>
        public bool createMaterial(String materialName, string description)
        {
            bool result = false;
            try
            {
                MaterialDefinitionAttributes attr = new MaterialDefinitionAttributes()
                {
                    S95Id = materialName,
                    Description = description
                };
                AspectChangeRequest request = new AspectChangeRequest();

                this.ServiceDirManager.IMaterial.CreateMaterialDefinition(attr, request);

                DirectoryResource material = MDManager.GetMaterialDefinition(materialName);
                if (material == null)
                    return false;
                //根据setid去查找码表项
                List<string> itemList = MDManager.GetCodeItemsBySetIdFromDB("MA01");
                if (itemList != null && itemList.Count > 0)
                {
                    DirectoryResource dir_class = null;
                    foreach (var item in itemList)
                    {
                        dir_class = MDManager.GetMaterialClass(item);
                        if(dir_class!=null)
                            this.ServiceDirManager.IMaterial.AddClass(material, dir_class);
                    }
                }
                result = true;
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }

        /// <summary>
        /// 获取所有物料号
        /// </summary>
        /// <returns></returns>
        public List<string> getAllMaterials()
        {
            try
            {
                List<string> strList = new List<string>();
                string[] arr = this.ServiceDirManager.IMaterial.GetMaterialDefinitions();
                if (arr != null && arr.Length > 0)
                {
                    var address = "";
                    var name = "";
                    foreach (var item in arr)
                    {
                        address = item.Substring(3, 36);
                        name = MDManager.GetDefinitionNameFromDB(address);
                        if (!string.IsNullOrEmpty(name))
                        {
                            strList.Add(name);
                        }
                    }
                }
                return strList;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 获取物料对应关系
        /// </summary>
        /// <returns>0:partNumber;1:materialCode;2:出熱mes物料編碼</returns>
        public String[] getMaterialMapping(String materialOrPart)
        {
            // 0:partNumber;1:materialCode;2:出熱mes物料編碼
            String[] materialMapping = new String[3];
            DirectoryResource material = MDManager.GetMaterialDefinition(materialOrPart);
            // 物料编码
            if (material.Exists)
            {
                materialMapping[0] = this.ServiceDirManager.IMaterial.ReadMaterialValue(material, "partNumber").StringValue(CultureInfo.CurrentCulture);
                materialMapping[1] = material.DisplayName;
                materialMapping[2] = this.ServiceDirManager.IMaterial.ReadMaterialValue(material, "heatingOutCode").StringValue(CultureInfo.CurrentCulture);

            }
            else
            {
                // 零件号
                DirectoryResource code = MDManager.GetMaterialDefinitionIdWithPartNumber(materialOrPart);
                if (code != null)
                {
                    materialMapping[0] = materialOrPart;
                    materialMapping[1] = code.DisplayName;
                    materialMapping[2] = this.ServiceDirManager.IMaterial.ReadMaterialValue(code, "heatingOutCode").StringValue(CultureInfo.CurrentCulture);
                }
                else
                {
                    // 出热物料编码,目前不做考虑
                    
                }
            }
            return materialMapping;
        }

    }
}

