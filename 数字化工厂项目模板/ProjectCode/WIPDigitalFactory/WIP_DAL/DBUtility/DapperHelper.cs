using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Common;
using System.Collections.Generic;
using WIP_Models;
using System.Threading.Tasks;
using Dapper;
using System.Linq;
using SysManager.Common.Utilities;

namespace WIP_DAL
{
    /// <summary>
    /// Dapper数据访问抽象基础类
    /// </summary>
    public class DapperHelper
    {
        public static string connectionString = DESEncryptHelper.Decrypt(ConfigurationManager.ConnectionStrings["SOACon"].ConnectionString);
        /// <summary>
        /// 连接数据库
        /// </summary>
        /// <returns></returns>
        public static IDbConnection DbConnection()
        {
            var connection = new SqlConnection(connectionString);//连接SQL Server数据库
            connection.Open();
            return connection;
        }

        /// <summary>
        /// 执行查询列表
        /// </summary>
        public static List<T> QueryList<T>(string sqlStr)
        {
            using (IDbConnection conn = DapperHelper.DbConnection())
            {
                return conn.Query<T>(sqlStr) as List<T>;
            }
        }
        /// <summary>
        /// 执行查询列表
        /// 注意：这里泛型只能是一个，入参和出参都是同一个，如果不是同一个，会查询数据为NULL
        /// </summary>
        /// <typeparam name="T">参数</typeparam>
        /// <param name="sqlStr">执行SQL字符串</param>
        /// <param name="param">参数</param>
        /// <returns>查询列表</returns>
        public static List<T> QueryList<T>(string sqlStr, T param)
        {
            using (IDbConnection conn = DapperHelper.DbConnection())
            {
                return conn.Query<T>(sqlStr, param) as List<T>;
            }
        }
        /// <summary>
        /// 执行查询单条数据
        /// </summary>
        public static T QuerySingle<T>(string sqlStr, T param)
        {
            using (IDbConnection conn = DapperHelper.DbConnection())
            {
                return conn.Query<T>(sqlStr, param).SingleOrDefault();
            }
        }

        /// <summary>
        /// 执行是否存在数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sqlStr">查询（例：SELECT COUNT(1)  FROM XXX ）</param>
        /// <param name="param">匿名类型</param>
        /// <returns></returns>
        public static bool Exists(string sqlStr, Object param)
        {
            using (IDbConnection conn = DapperHelper.DbConnection())
            {
                int count = conn.Query<int>(sqlStr, param).FirstOrDefault();
                return count > 0 ? true : false;
            }
        }

        /// <summary>
        /// 存储过程查询列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="procName"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static List<T> QueryListByProc<T>(string procName, T param)
        {
            using (IDbConnection conn = DapperHelper.DbConnection())
            {
                return conn.Query<T>(procName, param, commandType: CommandType.StoredProcedure) as List<T>;
            }
        }
        /// <summary>
        /// 存储过程查询列表
        /// </summary>
        /// <typeparam name="T">存储过程参数（可以是匿名参数）</typeparam>
        /// <typeparam name="T1">返回参数</typeparam>
        /// <param name="procName">存储过程名</param>
        /// <param name="param">存储过程参数</param>
        /// <returns>返回参数列表</returns>
        public static List<T1> QueryListByProc<T, T1>(string procName, T param)
        {
            using (IDbConnection conn = DapperHelper.DbConnection())
            {
                return conn.Query<T1>(procName, param, commandType: CommandType.StoredProcedure) as List<T1>;
            }
        }

        /// <summary>
        /// 执行SQL
        /// </summary>
        /// <typeparam name="T">执行参数</typeparam>
        /// <param name="insertSql">要执行的sql语句</param>
        /// <param name="param">执行参数</param>
        /// <returns>受影响的行数</returns>
        public static int ExecuteSql<T>(string insertSql, T param)
        {
            using (IDbConnection conn = DapperHelper.DbConnection())
            {
                return conn.Execute(insertSql, param);
            }
        }
    }
}
