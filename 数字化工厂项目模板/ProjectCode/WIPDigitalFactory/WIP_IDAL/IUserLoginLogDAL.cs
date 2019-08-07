/*
 * CLR Version：4.0.30319.42000
 * NameSpace：WIP_SQLServerDAL
 * FileName：UserLoginLogDAL
 * CurrentYear：2019
 * CurrentTime：2019/7/24 11:30:56
 * Author：shaocx
 *
 * <更新记录>
 * ver 1.0.0.0   2019/7/24 11:30:56 新規作成 (by shaocx)
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIP_Models;

namespace WIP_IDAL
{
    /// <summary>
    /// 用户登录记录数据访问类
    /// </summary>
    public interface IUserLoginLogDAL
    {
        /// <summary>
        /// 查询用户登录记录列表
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>用户登录记录列表</returns>
        List<UserLoginLogEntity> GetUserLoginLogList(string userName);

    }
}
