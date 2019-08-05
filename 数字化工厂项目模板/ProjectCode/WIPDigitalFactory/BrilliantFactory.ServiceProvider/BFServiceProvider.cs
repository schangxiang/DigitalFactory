using System;
using System.Collections.Generic;
using BrilliantFactory.Interfaces;
using Proficy.Platform.Core.ProficySystem.Types;
using Proficy.Platform.Core.ClientTools.ServiceDirectory.Interfaces;
using Proficy.Platform.ServiceModel;
using BrilliantFactory.Managers;
using Proficy.Platform.Core.ProficySystem.MobileObject;
using Proficy.PFM.Solutions.QualityForms.Interfaces;
using Proficy.PFM.Solutions.DocMgmt.Interfaces;

//using Proficy.PFM.Solutions.NCM.Interfaces;
//using Proficy.PFM.Solutions.NCM.Model;
using Proficy.Platform.Core.Dms.Dmfc;
using Proficy.Platform.ServiceModel.Compatibility;
using Proficy.Platform.Services.Personnel.Interfaces;
using BrilliantFactory.DataModel;
using Proficy.PFM.Solutions.Route.Interfaces;

namespace BrilliantFactory.ServiceProvider
{
    [Name("IBrilliantFactory")]
    [DisplayName("IBrilliantFactory Service")]
    [Description("IBrilliantFactory Service provided by GE IP")]
    [LogicalProviderName(typeof(IBrilliantFactory), "BrillaintFactory_IBrilliantFactory")]
    public partial class BFServiceProvider : ProficyService, IBrilliantFactory
    {
        public BFServiceProvider()
        {

        }

        private ISessionFactory _sessionFactory;
        public ISessionFactory SSessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    _sessionFactory = new SessionFactory();
                }
                return _sessionFactory;
            }
        }


        protected override void Initialize(ServiceCapabilities capabilities)
        {
            base.Initialize(capabilities);
            this._sessionFactory = new SessionFactory();
            IDataModel bfDataModel = new BrilliantFactoryDataModel();
            ModelContainer.LoadDataModel(bfDataModel);
        }



        private IServiceDirectory serviceDirectory { get; set; }



        private IDocumentManagement _documentManagement;

        public IDocumentManagement DocumentManagement
        {
            get
            {
                if (_documentManagement == null)
                {
                    _documentManagement = this.ServiceDirManager.IDocumentManagement;
                }
                return _documentManagement;
            }
            set { _documentManagement = value; }
        }

        //private INonConformanceManagement _nonConformanceManagement;

        //public INonConformanceManagement NonConformanceManagement
        //{
        //    get
        //    {
        //        if (_nonConformanceManagement == null)
        //        {
        //            _nonConformanceManagement = this.ServiceDirManager.INonConformanceManagement;
        //        } return _nonConformanceManagement;
        //    }
        //    set { _nonConformanceManagement = value; }
        //}

        private IQualityForms _qualityForms;

        public IQualityForms QualityForms
        {
            get
            {
                if (_qualityForms == null)
                {
                    _qualityForms = this.ServiceDirManager.IQualityForms;
                }
                return _qualityForms;
            }
            set { _qualityForms = value; }
        }


        private IExecutionManagement _executionManagement;

        public IExecutionManagement ExecutionManagement
        {
            get
            {
                if (_executionManagement == null)
                {
                    _executionManagement = this.ServiceDirManager.IExecutionManagement;
                }
                return _executionManagement;
            }
            set { _executionManagement = value; }
        }


        private IExecutionManagement iExecutionManagement;
        public IExecutionManagement IExecutionManagement
        {
            get
            {
                lock (this)
                {
                    if (this.iExecutionManagement == null)
                        this.iExecutionManagement = (IExecutionManagement)this.serviceDirectory.CreateDefaultServiceProxy(typeof(IExecutionManagement).FullName);

                    return this.iExecutionManagement;
                }
            }
        }










        private DatabaseManager _dBmanager;
        public DatabaseManager DBmanager
        {
            get
            {
                if (_dBmanager == null)
                {
                    _dBmanager = new DatabaseManager();

                }
                return _dBmanager;
            }
        }

        private ServiceDirectoryManager _serviceDirManager;
        public ServiceDirectoryManager ServiceDirManager
        {
            get
            {
                if (_serviceDirManager == null)
                {
                    _serviceDirManager = new ServiceDirectoryManager(this.ServiceDirectory);
                }
                return _serviceDirManager;
            }
        }


        private MaterialDefinitionManager _mDManager;
        public MaterialDefinitionManager MDManager
        {
            get
            {
                if (_mDManager == null)
                    _mDManager = new MaterialDefinitionManager(ServiceDirManager, DBmanager);
                return _mDManager;
            }
        }

        private PersonnelManager _perManager;
        public PersonnelManager PerManager
        {
            get
            {
                if (_perManager == null)
                    _perManager = new PersonnelManager(ServiceDirManager, DBmanager);
                return _perManager;
            }
        }


        private IPersonnel _personManagementSP;
        public IPersonnel PersonManagementSP
        {
            get
            {
                if (_personManagementSP == null)
                    _personManagementSP = ServiceDirManager.IPersonnel;

                return _personManagementSP;
            }
        }    

        private EquipmentManager _eQManager;
        public EquipmentManager EQManager
        {
            get
            {
                if (_eQManager == null)
                    _eQManager = new EquipmentManager(ServiceDirManager, DBmanager);
                return _eQManager;
            }
        }

        private WorkRequestManager _wRManager;
        public WorkRequestManager WRManager
        {
            get
            {
                if (_wRManager == null)
                {
                    _wRManager = new WorkRequestManager(ServiceDirManager, DBmanager, MDManager, PerManager, EQManager);
                }
                return _wRManager;
            }
        }

        private WorkResponseManager _workRespManager;
        public WorkResponseManager WorkRespManager
        {
            get
            {
                if (_workRespManager == null)
                {

                    _workRespManager = new WorkResponseManager(ServiceDirManager, PerManager, EQManager, MDManager);
                }
                return _workRespManager;
            }
        }


        private MaterialLotManager _mLManager;
        internal MaterialLotManager MLManager
        {
            get
            {
                if (_mLManager == null)
                    _mLManager = new MaterialLotManager(ServiceDirManager);
                return _mLManager;
            }
        }




        /// <summary>
        /// ExecuteProcedure spLocal_CJLR_LogAction
        /// </summary>
        /// <param name="statement"></param>
        /// <param name="inputParameters"></param>
        /// <returns></returns>
        public string LogAction(string cFunction, string cDescription, DateTime dDate)
        {
            var result = "";
            List<Parameter> parInputs = new List<Parameter>() 
            { 
                new Parameter() 
                { 
                    Name = "@cFunction", Value = new CrudItem(0, cFunction)  
                },
                new Parameter() 
                { 
                    Name = "@cDescription", Value = new CrudItem(0, cDescription)  
                },
                new Parameter()
                {
                    Name = "@dDate", Value = new CrudItem(0, dDate)  
                }
            };

            try
            {
                DBmanager.ExecuteProcedure("spLocal_CJLR_LogAction", parInputs);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return result;

        }


        public bool HandShake()
        {
            return true;
        }


        private bool CheckIfDocumentExist(string fileName)
        {
            try
            {
                bool documentFound = false;
                string storedProcedureName = "spLocal_CheckIfDocumentExists";
                List<Parameter> inputParams = new List<Parameter>();
                inputParams.Add(new Parameter("@DocumentName", new CrudItem(1, fileName)));

                var result = DBmanager.ExecuteProcedure(storedProcedureName, inputParams);
                int dbRows = result.FirstTable.Rows.Count;


                documentFound = dbRows > 0 ? true : false;

                return documentFound;
            }
            catch (Exception exception)
            {

                this.ServiceDirManager.ILog.Error(exception.Message);
                this.ServiceDirManager.ILog.Error(exception.StackTrace);
                throw exception;
            }
        }

    }
}
