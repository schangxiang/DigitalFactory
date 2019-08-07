using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIP_IDAL;
using WIP_DALFactory;
using WIP_Models;

namespace WIP_BLL
{
    public class PR_AuthorizationBLL
    {
        IAuthorizationDAL dal = WIPDataAccess.CreateDAL<IAuthorizationDAL>("AuthorizationDAL");
         
        #region 根据用户名称获取用户描述

        public AuthorizationUserModel GetAuthorization(string s95id)
        {

            return dal.GetAuthorization(s95id);
        }

        #endregion
     
    }
}
