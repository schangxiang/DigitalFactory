using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIP_SQLServerDAL;
using WIP_Models;

namespace WIP_BLL
{
    public class PR_AuthorizationBLL
    {
        PR_AuthorizationDAL dal = new PR_AuthorizationDAL();
         
        #region 根据用户名称获取用户描述

        public AuthorizationUserModel GetAuthorization(string s95id)
        {

            return dal.GetAuthorization(s95id);
        }

        #endregion
     
    }
}
