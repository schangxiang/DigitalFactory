//using BrilliantFactory.Interfaces.Types;

using Proficy.Platform.Core.DOR.Interfaces;
using Proficy.Platform.Core.ProficySystem.MobileObject;
using Proficy.Platform.Core.ProficySystem.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrilliantFactory.Managers;

namespace BrilliantFactory.Managers
{
    public class MaterialLotManager
    {
        public ServiceDirectoryManager ServiceDirectoryManager { get; set; }



        public MaterialLotManager(ServiceDirectoryManager serviceDirectoryManager)
         {
             this.ServiceDirectoryManager = serviceDirectoryManager;
         }

        public Guid CreateMaterialLot(DirectoryResource materialDefinition, string serialNumber, double qty, DirectoryResource Location, string status)
         {
             return this.ServiceDirectoryManager.IMaterial.CreateMaterialLot(materialDefinition, serialNumber, serialNumber, Location, status, qty, "UOM");
         }

        public int UpdateMaterialLotS95Id(Guid materialLotId, string lotS95Id)
         {
            try
            {
                this.ServiceDirectoryManager.IMaterial.UpdateMaterialLotS95Id(materialLotId, lotS95Id);
            }
            catch (Exception ex)
            {
                ServiceDirectoryManager.ILog.Error(ex.Message);
                ServiceDirectoryManager.ILog.Error(ex.StackTrace);
                return -3;
            }
            return 1;
         }

        public void UpdateMaterialLotStatus(Guid materialLotId, string status)
        {
            
            this.ServiceDirectoryManager.IMaterial.SetMaterialLotOrSublotStatus(Proficy.Platform.Services.Material.Interfaces.LotType.MaterialLot, materialLotId, status);
           
            return;
        }

        public void WriteMaterialLotProperty(Guid materialLotId, string propertyName, object propertyValue)
        {
            Parameter[] lotparams = new Parameter[] { new Parameter() { Name = propertyName, Value = new CrudItem(0, propertyValue) } };
            this.ServiceDirectoryManager.IMaterial.WriteMaterialLotProperties(materialLotId, lotparams);
            return;
        }

        public void SetMaterialLotQuantity(Guid materialLotId, double qty)
        {
            this.ServiceDirectoryManager.IMaterial.SetMaterialLotOrSublotQuantity(Proficy.Platform.Services.Material.Interfaces.LotType.MaterialLot, materialLotId, qty);
            return;
        }
    }
}
