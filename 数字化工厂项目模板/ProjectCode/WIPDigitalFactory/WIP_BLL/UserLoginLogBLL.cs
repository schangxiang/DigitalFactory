/*
 * CLR Version：4.0.30319.42000
 * NameSpace：WIP_BLL
 * FileName：UserLoginLogBLL
 * CurrentYear：2019
 * CurrentTime：2019/7/24 11:44:19
 * Author：shaocx
 *
 * <更新记录>
 * ver 1.0.0.0   2019/7/24 11:44:19 新規作成 (by shaocx)
 */


using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIP_SQLServerDAL;
using WIP_IBLL;
using WIP_Models;
using WIP_DALFactory;

namespace WIP_BLL
{
    [Export("UserLoginLog", typeof(IUserLoginLogBLL))]
    public sealed class UserLoginLogBLL : IUserLoginLogBLL
    {
        /// <summary>
        /// 查询用户登录记录列表
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>用户登录记录列表</returns>
        public List<UserLoginLogEntity> GetUserLoginLogList(string userName)
        {
            return WIPDataAccess.CreateUserLoginLogDAL().GetUserLoginLogList(userName);
        }
    }
}
