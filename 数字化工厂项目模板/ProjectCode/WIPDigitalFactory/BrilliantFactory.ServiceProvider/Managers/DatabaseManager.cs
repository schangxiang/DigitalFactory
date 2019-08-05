using Proficy.Platform.Core.ClientTools.ServiceDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proficy.Platform.Core.ProficySystem.Types;
using Proficy.Platform.Services.Database.Interfaces;
using Proficy.Platform.Services.Navigation.Interfaces;
using Proficy.Platform.Core.ProficySystem.MobileObject;
using Proficy.Platform.Core.DOR.Interfaces;
using Proficy.Platform.Core.ClientTools.ServiceDirectory.Interfaces;

namespace BrilliantFactory.Managers
{
    public class DatabaseManager
    {
        public DatabaseManager()
        {
            var connections = IDatabaseService.GetConnections();
            if (connections == null)
                return;
            SOAConnection = connections.First(a => a.Name == "SOADB");
        }


        public ConnectionInfo SOAConnection { get; set; }
        public string Constring
        {
            get
            {
                return string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}",
                SOAConnection.Server,
                SOAConnection.Database,
                SOAConnection.Username,
                SOAConnection.Password);
            }
        }

        private IServiceDirectory iServiceDirectory;
        public IServiceDirectory IServiceDirectory
        {
            get
            {
                lock (this)
                {
                    if (this.iServiceDirectory == null)
                        this.iServiceDirectory = UserStartup.Default.ServiceDirectory;

                    return this.iServiceDirectory;
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

        private IDatabaseService iDatabaseService;
        public IDatabaseService IDatabaseService
        {
            get
            {
                lock (this)
                {
                    if (this.iDatabaseService == null)
                        this.iDatabaseService = (IDatabaseService)this.IServiceDirectory.CreateDefaultServiceProxy(typeof(IDatabaseService).FullName);

                    return this.iDatabaseService;
                }
            }
        }

        private DirectoryResource dbConnection;
        public DirectoryResource DBConnection
        {

            get
            {
                if (dbConnection == null)
                {
                    var connection = this.IDirectorySearch.Search2(
                StandardBranches.GetBranchAddresses(this.ILocalDirectory, StandardBranches.ProficyRootAddress).Select(address => new DirectoryResource(address)).ToArray(),
                new Proficy.Platform.Services.Navigation.Interfaces.ClassificationExpression(DatabaseClassifications.Connections.QualifiedName),
                new Proficy.Platform.Services.Navigation.Interfaces.ClassificationExpression(),
                false,
                "SOADB",
                "",
                true,
                1
                ).Results.FirstOrDefault();

                    if (connection == null)
                        throw new Exception(string.Format("Database connection not found (name = {0})", "SOADB"));
                    dbConnection = connection;

                }
                return dbConnection;

            }
        }

        public StoredProcedureExecutionResult ExecuteProcedure(string procedureName, IEnumerable<Parameter> inputParameters)
        {
            StoredProcedureExecutionResult result = null;
            try
            {
                result =  this.IDatabaseService.ExecuteProcedure(this.DBConnection, procedureName, inputParameters);
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;

        }
        



        

        public StatementExecutionResult ExecuteStatement(string statement, IEnumerable<Parameter> inputParameters)
        {
            StatementInfo info = new StatementInfo();
            info.Provider = DataProviders.SQL;
            info.Statement = statement;
            info.StatementType = StatementType.Query;


            return this.iDatabaseService.ExecuteStatement(this.DBConnection, info, inputParameters);
        }
    }
}
