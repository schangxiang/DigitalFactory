using BrilliantFactory.Interfaces.Types;
//using BrilliantFactory.Interfaces.Types;
using Proficy.Platform.Core.DOR.Interfaces;
using Proficy.Platform.Core.ProficySystem.MobileObject;
using Proficy.Platform.Core.ProficySystem.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrilliantFactory.Managers
{
    public class MaterialDefinitionManager
    {
        public ServiceDirectoryManager ServiceDirectoryManager { get; set; }
        public DatabaseManager DatabaseManager { get; set; }
        public MaterialDefinitionManager(ServiceDirectoryManager serviceDirectoryManager, DatabaseManager databaseManager)
        {
            this.ServiceDirectoryManager = serviceDirectoryManager;
            this.DatabaseManager = databaseManager;
        }

        private DirectoryResource bOMItemMaterialClass;
        internal DirectoryResource BOMItemMaterialClass { get { lock (this) return this.bOMItemMaterialClass ?? (this.bOMItemMaterialClass = this.GetMaterialClass(MaterialClasses.BOMItem.Name)); } }

        internal DirectoryResource GetMaterialClass(string className)
        {
            return this.ServiceDirectoryManager.IDirectorySearch.Search2(
                StandardBranches.GetBranchAddresses(this.ServiceDirectoryManager.ILocalDirectory, StandardBranches.MaterialClassesHintPath).Select(address => new DirectoryResource(address)).ToArray(),
                new Proficy.Platform.Services.Navigation.Interfaces.ClassificationExpression(),
                new Proficy.Platform.Services.Navigation.Interfaces.ClassificationExpression(),
                false,
                className,
                "",
                true,
                1
                ).Results.First();
        }

        public DirectoryResource GetMaterialDefinition(string definitionName)
        {
            return this.ServiceDirectoryManager.IDirectorySearch.Search2(
                StandardBranches.GetBranchAddresses(this.ServiceDirectoryManager.ILocalDirectory, StandardBranches.MaterialHintPath).Select(address => new DirectoryResource(address)).ToArray(),
                new Proficy.Platform.Services.Navigation.Interfaces.ClassificationExpression(),
                new Proficy.Platform.Services.Navigation.Interfaces.ClassificationExpression(),
                false,
                definitionName,
                "",
                true,
                1
                ).Results.FirstOrDefault();
        }

        /// <summary>
        /// Get Material Defintion from Custom Query
        /// </summary>
        /// <param name="definitionName"></param>
        /// <returns></returns>
        public DirectoryResource GetMaterialDefinitionFromDB(string definitionName)
        {
            if (string.IsNullOrEmpty(definitionName)) return null;

            string storedProcedureName = "uspWip_GetMaterialDefinition";
            DirectoryResource mdresource = null;
            List<Parameter> inputparams = new List<Parameter>();
            inputparams.Add(new Parameter("@PartNumber", new CrudItem(1, definitionName)));
            var spresult = this.DatabaseManager.ExecuteProcedure(storedProcedureName, inputparams);
            if (spresult.FirstTable.Rows != null && spresult.FirstTable.Rows.Any())
            {
                mdresource = new DirectoryResource(spresult.FirstTable.Rows[0]["MD_ADDRESS"].ToString(), spresult.FirstTable.Rows[0]["mName"].ToString(),"");
            }
            return mdresource;
        }



        /// <summary>
        /// Get Material Defintion from Custom Query
        /// </summary>
        /// <param name="definitionName"></param>
        /// <returns></returns>
        public string GetMaterialDefinitionAddressFromDB(string definitionName)
        {
            if (string.IsNullOrEmpty(definitionName)) return null;

            string storedProcedureName = "uspWip_GetMaterialDefinition";
            string madr = null;
            List<Parameter> inputparams = new List<Parameter>();
            inputparams.Add(new Parameter("@PartNumber", new CrudItem(1, definitionName)));
            var spresult = this.DatabaseManager.ExecuteProcedure(storedProcedureName, inputparams);
            if (spresult.FirstTable.Rows != null && spresult.FirstTable.Rows.Any())
            {
                madr = spresult.FirstTable.Rows[0]["MD_ADDRESS"].ToString();
            }
            return madr;
        }


        /// <summary>
        /// Get Material Defintion from Custom Query
        /// </summary>
        /// <param name="definitionAddress"></param>
        /// <returns></returns>
        public string GetDefinitionNameFromDB(string definitionAddress)
        {
            if (string.IsNullOrEmpty(definitionAddress)) return null;

            string storedProcedureName = "uspWip_GetDefinitionName";
            string name = null;
            List<Parameter> inputparams = new List<Parameter>();
            inputparams.Add(new Parameter("@DefinitionAddress", new CrudItem(1, definitionAddress)));
            var spresult = this.DatabaseManager.ExecuteProcedure(storedProcedureName, inputparams);
            if (spresult.FirstTable.Rows != null && spresult.FirstTable.Rows.Any())
            {
                name = spresult.FirstTable.Rows[0]["DefinitionName"].ToString();
            }
            return name;
        }


        /// <summary>
        /// 根据setid查找码表项
        /// </summary>
        /// <param name="setId"></param>
        /// <returns></returns>
        public List<string> GetCodeItemsBySetIdFromDB(string setId)
        {
            if (string.IsNullOrEmpty(setId)) return null;

            string storedProcedureName = "uspWip_GetCodeItems";
            List<Parameter> inputparams = new List<Parameter>();
            inputparams.Add(new Parameter("@setId", new CrudItem(1, setId)));
            var spresult = this.DatabaseManager.ExecuteProcedure(storedProcedureName, inputparams);
            List<string> strList = new List<string>();
            if (spresult.FirstTable.Rows != null && spresult.FirstTable.Rows.Any())
            {
                foreach (var item in spresult.FirstTable.Rows)
                {
                    strList.Add(item["code"].ToString());
                }
            }
            return strList;
        }


        /// <summary>
        /// 根据零件号查找物料编码
        /// </summary>
        /// <param name="partNumber"></param>
        /// <returns></returns>
        public DirectoryResource GetMaterialDefinitionIdWithPartNumber(String partNumber)
        {
            string storedProcedureName = "uspMa_GetMaterialDefinitionIdWithPartNumber";
            List<Parameter> inputparams = new List<Parameter>();

            DirectoryResource mdresource = null;
            inputparams.Add(new Parameter("@PartNumber", new CrudItem(1, partNumber)));
            var spresult = this.DatabaseManager.ExecuteProcedure(storedProcedureName, inputparams);
            if (spresult.FirstTable.Rows != null && spresult.FirstTable.Rows.Any())
            {
                mdresource = new DirectoryResource(spresult.FirstTable.Rows[0]["MD_ADDRESS"].ToString());
            }
            return mdresource;
        }
    }
}
