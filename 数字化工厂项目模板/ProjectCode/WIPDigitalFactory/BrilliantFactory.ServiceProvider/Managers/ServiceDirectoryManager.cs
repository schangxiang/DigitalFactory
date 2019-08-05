using Proficy.PFM.Solutions.Common.Interfaces;
using Proficy.PFM.Solutions.DocMgmt.Interfaces;
using Proficy.PFM.Solutions.QM.Interfaces;
using Proficy.PFM.Solutions.QualityForms.Interfaces;
using Proficy.PFM.Solutions.Route.Interfaces;
using Proficy.Platform.Core.ClientTools.ServiceDirectory.Interfaces;
using Proficy.Platform.Core.Diagnostics.Log;
using Proficy.Platform.Core.DOR.Interfaces;
using Proficy.Platform.Services.Equipment.Interfaces;
using Proficy.Platform.Services.Material.Interfaces;
using Proficy.Platform.Services.Navigation.Interfaces;
using Proficy.Platform.Services.Personnel.Interfaces;
using Proficy.Platform.Services.Production.Interfaces;

namespace BrilliantFactory.Managers
{
    public class ServiceDirectoryManager
    {
        public IServiceDirectory IServiceDirectory { get; set; }
        //public ISessionFactory ISessionFactory { get; set; }

        public ServiceDirectoryManager(IServiceDirectory IServiceDirectory)
        {
            this.IServiceDirectory = IServiceDirectory;
           //// this.ISessionFactory = ISessionFactory;
        }
       

        //private IApproval iApproval;
        //public IApproval IApproval
        //{
        //    get
        //    {
        //        lock (this)
        //        {
        //            if (this.iApproval == null)
        //                this.iApproval = (IApproval)this.IServiceDirectory.CreateLogicalServiceProxy("Approval_IApproval");

        //            return this.iApproval;
        //        }
        //    }
        //}

        //private IClientElement iClientElement;
        //public IClientElement IClientElement
        //{
        //    get
        //    {
        //        if (iClientElement == null)
        //            iClientElement = (IClientElement)this.IServiceDirectory.CreateLogicalServiceProxy("CLIENTELEMENT_ICLIENTELEMENT"); //NLS_IGNORE

        //        return iClientElement;
        //    }
        //}

        private IDirectorySearch iDirectorySearch;
        public IDirectorySearch IDirectorySearch
        {
            get
            {
                lock (this)
                {
                    if (this.iDirectorySearch == null)
                        this.iDirectorySearch = (IDirectorySearch)this.IServiceDirectory.CreateLogicalServiceProxy("NAVIGATION_IDIRECTORYSEARCH");

                    return this.iDirectorySearch;
                }
            }
        }

        private IDocumentManagement iDocumentManagement;
        public IDocumentManagement IDocumentManagement
        {
            get
            {
                lock (this)
                {
                    if (this.iDocumentManagement == null)
                        this.iDocumentManagement = (IDocumentManagement)this.IServiceDirectory.CreateLogicalServiceProxy("DocumentManagement_IDocumentManagement");//NLS_IGNORE

                    return this.iDocumentManagement;
                }
            }
        }

        //private INonConformanceManagement iNonConformanceManagement;

        //public INonConformanceManagement INonConformanceManagement
        //{
        //    get
        //    {
        //        if (iNonConformanceManagement == null)
        //        {
        //            this.iNonConformanceManagement = (INonConformanceManagement)this.IServiceDirectory.CreateLogicalServiceProxy(typeof(INonConformanceManagement).FullName);   
        //        } return iNonConformanceManagement;
        //    }
        //}

        private IEquipment iEquipment;
        public IEquipment IEquipment
        {
            get
            {
                lock (this)
                {
                    if (this.iEquipment == null)
                        this.iEquipment = (IEquipment)this.IServiceDirectory.CreateLogicalServiceProxy(EquipmentInterfaceNames.EQUIPMENT_IEQUIPMENT);

                    return this.iEquipment;
                }
            }
        }

        //private IErpMessage iErpMessage;
        //public IErpMessage IErpMessage
        //{
        //    get
        //    {
        //        lock (this)
        //        {
        //            if (this.iErpMessage == null)
        //                this.iErpMessage = (IErpMessage)this.IServiceDirectory.CreateDefaultServiceProxy(typeof(IErpMessage).FullName);

        //            return this.iErpMessage;
        //        }
        //    }
        //}

        //private IErpData iErpData;
        //public IErpData IErpData
        //{
        //    get
        //    {
        //        lock (this)
        //        {
        //            if (this.iErpData == null)
        //                this.iErpData = (IErpData)this.IServiceDirectory.CreateDefaultServiceProxy(typeof(IErpData).FullName);

        //            return this.iErpData;
        //        }
        //    }
        //}

        private IExecutionManagement iExecutionManagement;
        public IExecutionManagement IExecutionManagement
        {
            get
            {
                lock (this)
                {
                    if (this.iExecutionManagement == null)
                        this.iExecutionManagement = (IExecutionManagement)this.IServiceDirectory.CreateDefaultServiceProxy(typeof(IExecutionManagement).FullName);

                    return this.iExecutionManagement;
                }
            }
        }

        private ILocalDirectory ilocalDirectory;
        public ILocalDirectory ILocalDirectory
        {
            get
            {
                lock (this)
                {
                    if (ilocalDirectory == null)
                        ilocalDirectory = this.IServiceDirectory.CreateDefaultServiceProxy("ILocalDirectory") as ILocalDirectory;

                    return ilocalDirectory;
                }
            }
        }

        public ILog ILog
        {
            get { return LogManager.GetLogger("IBrilliantFactoryPOC"); } //NLS_IGNORE
        }

        private IMaterial iMaterial;
        public IMaterial IMaterial
        {
            get
            {
                lock (this)
                {
                    if (this.iMaterial == null)
                        this.iMaterial = (IMaterial)this.IServiceDirectory.CreateLogicalServiceProxy(MaterialLogicalProviderNames.MATERIAL_IMATERIAL);

                    return this.iMaterial;
                }
            }
        }

        private IPersonnel iPersonnel;
        public IPersonnel IPersonnel
        {
            get
            {
                lock (this)
                {
                    if (this.iPersonnel == null)
                        this.iPersonnel = (IPersonnel)this.IServiceDirectory.CreateLogicalServiceProxy("Personnel_IPersonnel");

                    return this.iPersonnel;
                }
            }
        }

        private IPFMCommon iPFMCommon;
        public IPFMCommon IPFMCommon
        {
            get
            {
                lock (this)
                {
                    if (this.iPFMCommon == null)
                        this.iPFMCommon = (IPFMCommon)this.IServiceDirectory.CreateLogicalServiceProxy(PFMCommonLogicalProviderNames.IPFMCommon);
                    return this.iPFMCommon;
                }
            }
        }

        private IProductionRuntime iProductionRuntime;
        public IProductionRuntime IProductionRuntime
        {
            get
            {
                lock (this)
                {
                    if (this.iProductionRuntime == null)
                        this.iProductionRuntime = (IProductionRuntime)this.IServiceDirectory.CreateDefaultServiceProxy(typeof(IProductionRuntime).FullName);

                    return this.iProductionRuntime;
                }
            }
        }

        private IProductionModel iProductionModel;
        public IProductionModel IProductionModel
        {
            get
            {
                lock (this)
                {
                    if (this.iProductionModel == null)
                        this.iProductionModel = (IProductionModel)this.IServiceDirectory.CreateDefaultServiceProxy(typeof(IProductionModel).FullName);

                    return this.iProductionModel;
                }
            }
        }

        private IProductionReport iProductionReport;
        public IProductionReport IProductionReport
        {
            get
            {
                lock (this)
                {
                    if (this.iProductionReport == null)
                        this.iProductionReport = (IProductionReport)this.IServiceDirectory.CreateDefaultServiceProxy(typeof(IProductionReport).FullName);

                    return this.iProductionReport;
                }
            }
        }


        
        private IQualificationManagement iQualificationManagement;
        public IQualificationManagement IQualificationManagement
        {
            get
            {
                lock (this)
                {
                    if (this.iQualificationManagement == null)
                        this.iQualificationManagement = (IQualificationManagement)this.IServiceDirectory.CreateLogicalServiceProxy(Proficy.PFM.Solutions.QM.Interfaces.LogicalProviderNames.IQualificationManagement);

                    return this.iQualificationManagement;
                }
            }
        }

       

        private IQualityForms iQualityForms;
        public IQualityForms IQualityForms
        {
            get
            {
                lock (this)
                {
                    if (this.iQualityForms == null)
                        this.iQualityForms = (IQualityForms)this.IServiceDirectory.CreateLogicalServiceProxy(QualityFormsLogicalProviderNames.IQUALITYFORMS);

                    return this.iQualityForms;
                }
            }
        }

        private IRouteConfiguration iRouteConfiguration;
        public IRouteConfiguration IRouteConfiguration
        {
            get
            {
                lock (this)
                {
                    if (this.iRouteConfiguration == null)
                        this.iRouteConfiguration = (IRouteConfiguration)this.IServiceDirectory.CreateDefaultServiceProxy(typeof(IRouteConfiguration).FullName);

                    return this.iRouteConfiguration;

                    
                }
            }
        }
    }
}
