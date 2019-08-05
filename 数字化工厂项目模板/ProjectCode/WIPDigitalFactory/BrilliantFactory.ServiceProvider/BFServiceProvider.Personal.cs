using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BrilliantFactory.Interfaces.Model;
using System.Globalization;
namespace BrilliantFactory.ServiceProvider
{
    public partial class BFServiceProvider
    {
        public bool CanLogin(string uName,string uPwd,out string Msg)
        {
            var personAddress = PerManager.GetPerson(uName);
            if (personAddress==null)
            {
                Msg = "User Name is Incorrect";
                return false;
            }

            var bLogin=PersonManagementSP.VerifyUserCredentials(uName, uPwd, "", false);
            if(bLogin)
            {
                Msg = "Login Success";
            }
            else
            {
                Msg = "Password is incorrect";
            }

            return bLogin;
        }


        public bool CanLoginViaDomain(string uName, string uPwd,string Domain, out string Msg)
        {
            var personAddress = PerManager.GetPerson(Domain+@"\"+uName);
            if (personAddress == null)
            {
                Msg = "User Name is Incorrect";
                return false;
            }

            var bLogin = PersonManagementSP.VerifyUserCredentials(uName, uPwd, Domain, false);
            if (bLogin)
            {
                Msg = "Login Success";
            }
            else
            {
                Msg = "Password is incorrect";
            }

            return bLogin;
        }


        public bool UpdatePwd(string uName, string uPwd,string uNewPwd,out string Msg)
        {
            var personAddress = PerManager.GetPerson(uName);
            if (personAddress == null)
            {
                Msg = "User Name is Incorrect";
                return false;
            }

            var bLogin = PersonManagementSP.VerifyUserCredentials(uName, uPwd, "", false);
            if (bLogin)
            {
                PersonManagementSP.ChangePersonPasswordCallMethod(uName, uPwd, uNewPwd);
                Msg = "Password Updated Success";
            }
            else
            {
                Msg = "Password is incorrect";
            }

            return bLogin;
        }


        public IEnumerable<PersonalProperties> GetPersonalProperties(string uName, out string Msg, List<string> proNames)
        {
            var personAddress = PerManager.GetPerson(uName);
            if (personAddress == null)
            {
                Msg = "User Name is Incorrect";
                return null;
            }

            var uProperties = PersonManagementSP.ReadPropertyAttributes(personAddress, proNames.ToArray());

            if (uProperties.Count < 1)
            {
                Msg = "User is not be initialed, Please Contact Pfmd Administrator";
                return null;
            }
            Msg = " ";

            List<PersonalProperties> ppList=new List<PersonalProperties>();
            foreach(var iP in uProperties)
            {
                var pp=new PersonalProperties();
                pp.pName=iP.Name;
                pp.bVisible = iP.Value.BooleanValue(CultureInfo.CurrentCulture) ;
                ppList.Add(pp); 
            }
            
            return ppList;
        }
    }
}
