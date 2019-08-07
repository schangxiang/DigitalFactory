using SysManager.DB.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIP_IDAL;
using WIP_Models;

namespace WIP_SQLServerDAL
{
    public class AuthorizationDAL : IAuthorizationDAL
    {


     /// <summary>
     /// 根据用户名称获取用户的描述
     /// </summary>
     /// <param name="s95id"></param>
     /// <returns></returns>
       public AuthorizationUserModel GetAuthorization(string s95id)
       {
           SqlParameter[] parameters = { 
               new SqlParameter("@s95id", SqlDbType.NVarChar,500)
           };
           parameters[0].Value = s95id;
           DataSet ds = SQLServerHelper.RunProcedure("UspWip_GetAuthorization", parameters, "pagetable");
           AuthorizationUserModel model = new AuthorizationUserModel();

           if (ds.Tables[0].Rows.Count > 0)
           {
               var dataRow = ds.Tables[0].Rows[0];
               model.s95id = dataRow["s95id"].ToString();
               model.Description = dataRow["Description"].ToString();
               return model;
           }
           else
           {
               return null;
           }

       }


    }
}
