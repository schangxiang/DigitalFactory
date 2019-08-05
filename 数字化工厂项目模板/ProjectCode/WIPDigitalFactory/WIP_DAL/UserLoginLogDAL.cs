/*
 * CLR Version：4.0.30319.42000
 * NameSpace：WIP_DAL
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

namespace WIP_DAL
{
    /// <summary>
    /// 用户登录记录数据访问类
    /// </summary>
    public class UserLoginLogDAL
    {
        #region 单例模式（饿汉模式）

        private static UserLoginLogDAL _instance = null;
        private UserLoginLogDAL() { }
        static UserLoginLogDAL()
        {
            _instance = new UserLoginLogDAL();
        }
        public static UserLoginLogDAL GetInstance()
        {
            return _instance;
        }

        #endregion

        /// <summary>
        /// 查询用户登录记录列表
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>用户登录记录列表</returns>
        public List<UserLoginLogEntity> GetUserLoginLogList(string userName)
        {
            //使用ORM框架的Dapper实现
            var param = new
            {
                userName = userName
            };
            return DapperHelper.QueryListByProc<object, UserLoginLogEntity>("uspWip_GetUserLoginLogList", param);
        }
    }
}
