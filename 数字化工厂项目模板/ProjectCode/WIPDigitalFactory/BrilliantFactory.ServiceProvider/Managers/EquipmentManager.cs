//using BrilliantFactory.Interfaces.Types;
using Proficy.Platform.Core.DOR.Interfaces;
using Proficy.Platform.Core.ProficySystem.Types;
using Proficy.Platform.Services.Equipment.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BrilliantFactory.Managers
{
    public class EquipmentManager
    {
        public ServiceDirectoryManager ServiceDirectoryManager { get; set; }
        public DatabaseManager DatabaseManager { get; set; }
        

        public EquipmentManager(ServiceDirectoryManager serviceDirectoryManager, DatabaseManager databaseManager)
        {
            this.ServiceDirectoryManager = serviceDirectoryManager;
            this.DatabaseManager = databaseManager;           
        }
        //private DirectoryResource departmentEquipmentClass;
        //private DirectoryResource DepartmentEquipmentClass { get { lock (this) return this.departmentEquipmentClass ?? (this.departmentEquipmentClass = this.GetEquipmentClass(EquipmentClasses.Department.Name)); } }

        //private DirectoryResource machineEquipmentClass;
        //public DirectoryResource MachineEquipmentClass { get { lock (this) return this.machineEquipmentClass ?? (this.machineEquipmentClass = this.GetEquipmentClass(EquipmentClasses.Machine.Name)); } }

        //private DirectoryResource subInventoryEquipmentClass;
        //private DirectoryResource SubInventoryEquipmentClass { get { lock (this) return this.subInventoryEquipmentClass ?? (this.subInventoryEquipmentClass = this.GetEquipmentClass(EquipmentClasses.SubInventory.Name)); } }

        //private DirectoryResource pfM_ProductionLineEquipmentClass;
        //private DirectoryResource PfM_ProductionLineEquipmentClass { get { lock (this) return this.pfM_ProductionLineEquipmentClass ?? (this.pfM_ProductionLineEquipmentClass = this.GetEquipmentClass(EquipmentClasses.PfM_ProductionLine.Name)); } }

        //private DirectoryResource pfM_WorkCenterEquipmentClass;
        //private DirectoryResource PfM_WorkCenterEquipmentClass { get { lock (this) return this.pfM_WorkCenterEquipmentClass ?? (this.pfM_WorkCenterEquipmentClass = this.GetEquipmentClass(EquipmentClasses.PfM_WorkCenter.Name)); } }

        //private DirectoryResource pfM_MachineEquipmentClass;
        //private DirectoryResource PfM_MachineEquipmentClass { get { lock (this) return this.pfM_MachineEquipmentClass ?? (this.pfM_MachineEquipmentClass = this.GetEquipmentClass(EquipmentClasses.PfM_Machine.Name)); } }

        //private DirectoryResource operationEquipmentRequirementClass;
        //private DirectoryResource OperationEquipmentRequirementClass { get { lock (this) return this.operationEquipmentRequirementClass ?? (this.operationEquipmentRequirementClass = this.GetEquipmentClass(EquipmentClasses.OperationEquipmentRequirement.Name)); } }

        internal DirectoryResource GetEquipmentClass(string className)
        {
            return this.ServiceDirectoryManager.IDirectorySearch.Search2(
                StandardBranches.GetBranchAddresses(this.ServiceDirectoryManager.ILocalDirectory, StandardBranches.EquipmentClassesHintPath).Select(address => new DirectoryResource(address)).ToArray(),
                new Proficy.Platform.Services.Navigation.Interfaces.ClassificationExpression(),
                new Proficy.Platform.Services.Navigation.Interfaces.ClassificationExpression(),
                false,
                className,
                "",
                true,
                1
                ).Results.First();
        }


        internal DirectoryResource[] GetEquipmentClasses(string _Expression)
        {
            try
            {
               // this.ServiceDirectoryManager.IDirectorySearch _search = (this.ServiceDirectoryManager.IDirectorySearch)UC.GetDefaultProvider("NAVIGATION_IDIRECTORYSEARCH");

                DirectoryResource _root = new DirectoryResource("CN=Equipment,CN=SOAProject,CN=Projects,OU=Publications,O=Proficy");

                Proficy.Platform.Services.Navigation.Interfaces.ClassificationExpression IncludedClassifications = new Proficy.Platform.Services.Navigation.Interfaces.ClassificationExpression(_Expression);
                Proficy.Platform.Services.Navigation.Interfaces.ClassificationExpression ExcludedClassifications = new Proficy.Platform.Services.Navigation.Interfaces.ClassificationExpression(null, "");

                DirectoryResource[] _EquipmentClasses = this.ServiceDirectoryManager.IDirectorySearch.Search(
                                _root, IncludedClassifications, ExcludedClassifications, null, null);

                return _EquipmentClasses;
            }
            catch (System.Exception ex)
            {
                throw;
            }

        }

        public DirectoryResource GetSite(string equipmentName)
        {
            return this.GetEquipmentByClassificationExpression(new Proficy.Platform.Services.Navigation.Interfaces.ClassificationExpression(EquipmentClassifications.Site), equipmentName).FirstOrDefault();
        }

        public DirectoryResource GetProductionLine(string equipmentName)
        {
            return this.GetEquipmentByClassificationExpression(new Proficy.Platform.Services.Navigation.Interfaces.ClassificationExpression(EquipmentClassifications.ProductionLine), equipmentName).FirstOrDefault();
        }

        /// <summary>
        /// 获取WorkCell
        /// </summary>
        /// <param name="workcellName">workcell名</param>
        /// <returns></returns>
        public DirectoryResource GetWorkCell(string workcellName)
        {
            return this.GetEquipmentByClassificationExpression(new Proficy.Platform.Services.Navigation.Interfaces.ClassificationExpression(EquipmentClassifications.WorkCell), workcellName).FirstOrDefault();
        }

        public DirectoryResource GetSiteEquipment(string siteName, string equipmentName)
        {
            DirectoryResource site = this.GetSite(siteName);
            return this.GetEquipmentChild(site, equipmentName, false);
        }

      

      

        //public bool IsMachine(DirectoryResource equipment)
        //{
        //    if (equipment == null)
        //        return false;

        //    return ServiceDirectoryManager.IEquipment.HasClass(equipment, this.MachineEquipmentClass);
        //}

        private string GetDepartmentMachinesResources(IEnumerable<DirectoryResource> machines)
        {
            return string.Join(",", machines.Select(machine => machine.DisplayName));
        }

        private IEnumerable<string> GetDepartmentMachinesNames(string departmentResources)
        {
            if (string.IsNullOrWhiteSpace(departmentResources))
                return Enumerable.Empty<string>();

            return departmentResources.Split(',');
        }


        private DirectoryResource[] GetEquipmentByClass(DirectoryResource parentEquipment, DirectoryResource equipmentClass, string equipmentName)
        {
            return this.GetEquipmentByClassificationExpression(new Proficy.Platform.Services.Navigation.Interfaces.ClassificationExpression(string.Format("EquipmentClass:{0}", equipmentClass.GetId())), equipmentName);
        }

        private DirectoryResource[] GetEquipmentByClassificationExpression(Proficy.Platform.Services.Navigation.Interfaces.ClassificationExpression classificationExpression, string equipmentName)
        {
            return this.ServiceDirectoryManager.IDirectorySearch.Search2(
                StandardBranches.GetBranchAddresses(this.ServiceDirectoryManager.ILocalDirectory, StandardBranches.EquipmentHintPath).Select(address => new DirectoryResource(address)).ToArray(),
                classificationExpression,
                new Proficy.Platform.Services.Navigation.Interfaces.ClassificationExpression(),
                false,
                equipmentName,
                "",
                true,
                1
                ).Results;
        }

        public DirectoryResource GetEquipmentChild(DirectoryResource parentEquipment, string equipmentName, bool immediateOnly)
        {
            return this.ServiceDirectoryManager.IDirectorySearch.Search2(
                new DirectoryResource[] { parentEquipment },
                new Proficy.Platform.Services.Navigation.Interfaces.ClassificationExpression(),
                new Proficy.Platform.Services.Navigation.Interfaces.ClassificationExpression(),
                immediateOnly,
                equipmentName,
                "",
                true,
                1
                ).Results.FirstOrDefault();
        }

        public List<DirectoryResource> GetEquipmentChildren(DirectoryResource parentEquipment, bool immediateOnly)
        {
            return this.ServiceDirectoryManager.IDirectorySearch.Search2(
                new DirectoryResource[] { parentEquipment },
                new Proficy.Platform.Services.Navigation.Interfaces.ClassificationExpression(),
                new Proficy.Platform.Services.Navigation.Interfaces.ClassificationExpression(),
                immediateOnly,
                "",
                "",
                true,
                1
                ).Results.ToList();
        }


    }
}
