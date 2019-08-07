using SysManager.DB.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIP_Models;

namespace WIP_IDAL
{
    public interface IAuthorizationDAL
    {


        /// <summary>
        /// 根据用户名称获取用户的描述
        /// </summary>
        /// <param name="s95id"></param>
        /// <returns></returns>
        AuthorizationUserModel GetAuthorization(string s95id);


    }
}
