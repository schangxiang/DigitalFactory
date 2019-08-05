using Proficy.Platform.Core.DOR.Interfaces;
using Proficy.Platform.Core.ProficySystem.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
using Proficy.Platform.ServiceModel;
using Proficy.Platform.Services.Personnel;

using BrilliantFactory.Interfaces.Types;
//using BrilliantFactory.Interfaces.Types;

namespace BrilliantFactory.Managers
{
    public class PersonnelManager
    {
        public ServiceDirectoryManager ServiceDirectoryManager { get; set; }
        public DatabaseManager DatabaseManager { get; set; }
        private const string ResourcePrefix = "Resource_";

        public PersonnelManager(ServiceDirectoryManager serviceDirectoryManager, DatabaseManager databaseManager)
        {
            this.ServiceDirectoryManager = serviceDirectoryManager;
            this.DatabaseManager = databaseManager;
        }

        private DirectoryResource integrationPerson;
        internal DirectoryResource IntegrationPerson
        {
            get
            {
                // lock (this)
                return this.integrationPerson ?? (this.integrationPerson = this.GetPerson(Personnel.Integration.Name));
            }
        }

        
        public string GetResourceName(DirectoryResource person)
        {
            return GetResourceName(person.DisplayName);
        }

        public string GetResourceName(string personName)
        {
            Contract.Requires(personName.StartsWith(ResourcePrefix), "person.DisplayName does not start with the expected prefix");

            return personName.Remove(0, ResourcePrefix.Length);
        }

        private string GetResourceS95Id(string resourceName)
        {
            return ResourcePrefix + resourceName;
        }

        public DirectoryResource GetResource(string personId)
        {
            var s95Id = this.GetResourceS95Id(personId);

            return this.GetPerson(s95Id);
        }

        public DirectoryResource GetPersonBySSO(string sso)
        {
            return this.GetPerson(sso);
        }

        //private DirectoryResource personPersonnelClass;
        //private DirectoryResource PersonPersonnelClass { get { lock (this) return this.personPersonnelClass ?? (this.personPersonnelClass = this.GetPersonnelClass(PersonnelClasses.PersonnelResource.Name)); } }

        //private DirectoryResource operationPersonnelRequirementPersonnelClass;
        //private DirectoryResource OperationPersonnelRequirementPersonnelClass { get { lock (this) return this.operationPersonnelRequirementPersonnelClass ?? (this.operationPersonnelRequirementPersonnelClass = this.GetPersonnelClass(PersonnelClasses.OperationPersonnelRequirement.Name)); } }

        //private DirectoryResource integrationPerson;
        //public DirectoryResource IntegrationPerson { get { lock (this) return this.integrationPerson ?? (this.integrationPerson = this.GetPerson(Personnel.Integration.Name)); } }

        private DirectoryResource GetPersonnelClass(string className)
        {
            return this.ServiceDirectoryManager.IDirectorySearch.Search2(
                StandardBranches.GetBranchAddresses(this.ServiceDirectoryManager.ILocalDirectory, StandardBranches.PersonnelClassesHintPath).Select(address => new DirectoryResource(address)).ToArray(),
                new Proficy.Platform.Services.Navigation.Interfaces.ClassificationExpression(),
                new Proficy.Platform.Services.Navigation.Interfaces.ClassificationExpression(),
                false,
                className,
                "",
                true,
                1
                ).Results.First();
        }

        public DirectoryResource GetPerson(string personName)
        {
            return this.ServiceDirectoryManager.IDirectorySearch.Search2(
                StandardBranches.GetBranchAddresses(this.ServiceDirectoryManager.ILocalDirectory, StandardBranches.PersonnelUsersHintPath).Select(address => new DirectoryResource(address)).ToArray(),
                new Proficy.Platform.Services.Navigation.Interfaces.ClassificationExpression(),
                new Proficy.Platform.Services.Navigation.Interfaces.ClassificationExpression(),
                false,
                personName,
                "",
                true,
                1
                ).Results.FirstOrDefault();
        }
    }
}
