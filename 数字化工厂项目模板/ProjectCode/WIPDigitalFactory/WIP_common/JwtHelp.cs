﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using WIP_Models;
using System.Web;
using Newtonsoft.Json;
using System.Collections.Concurrent;
using SysManager.Common.Utilities;

namespace WIP_common
{
    public class JwtHelp
    {
        //签名密码
        private static readonly SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Properties.Resources.SecretKey));
        private static readonly String WIP = "SAGWWIP";
        private static readonly string AuthType = WipAuthType.MEMORY;// REDIS CACHE

        /// <summary>
        /// WIP鉴权管理（内存）
        /// </summary>
        public static ConcurrentDictionary<string, RedisModel> wipAuthCacheDict = new ConcurrentDictionary<string, RedisModel>();

        /// <summary>
        /// 生成Token
        /// </summary>
        /// <param name="userName">登录用户名</param>
        /// <param name="tokenInfos"></param>
        /// <param name="expDays">有效天数</param>
        /// <returns></returns>
        public static string GenerateToken(String userName, List<TokenInfo> tokenInfos, int expDays = 30)
        {
            var credentials = new SigningCredentials
                             (securityKey, SecurityAlgorithms.HmacSha384);


            var header = new JwtHeader(credentials);


            var payload = new JwtPayload();
            var now = WIPCommon.GetUnixTimeStampWithGLWZForSeconds().ToString();
            // 30天过期
            var exp = long.Parse(now) + (expDays * 24 * 60 * 60);//单位：秒
            //注释下面的代码 [EditBy shaocx,2019-01-07]
            /*
            if (userName.Contains("integrated"))
            {
                exp = long.Parse(now) + 31536000;
            }
            //*/
            payload.AddClaim(new Claim(JwtRegisteredClaimNames.Iat, now));//发布时间
            payload.AddClaim(new Claim(JwtRegisteredClaimNames.Exp, exp.ToString()));//到期时间
            payload.AddClaim(new Claim(JwtRegisteredClaimNames.Iss, WIP));//发行人
            payload.AddClaim(new Claim(JwtRegisteredClaimNames.Sub, userName));//主题
            // 追加自定义字段 数据库字段
            payload.AddClaim(new Claim("username", userName));//自定义对象之用户名称
            // 自动获取payload
            if (tokenInfos != null)
            {
                payload.Add("usergroup", tokenInfos);//自定义对象之用户角色集合
            }
            else
            {
                payload.Add("usergroup", getTokenInfos(userName));//自定义对象之用户角色集合
            }
            var secToken = new JwtSecurityToken(header, payload);
            var handler = new JwtSecurityTokenHandler();

            String tokenString = handler.WriteToken(secToken);

            return tokenString;
        }

        private static List<TokenInfo> getTokenInfos(String userName)
        {
            DatabaseManager dbe = new DatabaseManager();

            SqlCommand cmd = new SqlCommand("uspWip_GetPersonGroupRoles") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@loginUserName", userName);
            var dt = dbe.GetSqlTableWithUsing(cmd);
            List<TokenInfo> tokeninfos = new List<TokenInfo>();
            if (dt != null && dt.Rows.Count > 0)
            {
                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    tokeninfos.Add(new TokenInfo()
                    {
                        loginname = dt.Rows[i]["loginname"].ToString(),
                        groupId = dt.Rows[i]["groupId"].ToString(),
                        groupname = dt.Rows[i]["groupname"].ToString(),
                        roleId = dt.Rows[i]["roleId"].ToString(),
                        rolename = dt.Rows[i]["rolename"].ToString(),
                    });
                }
            }
            return tokeninfos;
        }

        /// <summary>
        /// 是否免除验证Token
        /// </summary>
        /// <param name="absolutePath"></param>
        /// <returns>true:免除验证，false：不免除验证</returns>
        public static bool isExemptValidateToken(string absolutePath, string httpMethod)
        {
            // 登录无需验证
            if (StringHelper.StringCompareWithIgnoreCase("/logon/validateuser",absolutePath))
            {
                return true;
            }
            // 修改密码无需验证
            if (StringHelper.StringCompareWithIgnoreCase("/logon/Userupdatepwd",absolutePath))
            {
                return true;
            }
            // 获取登录用户名无需验证
            if (StringHelper.StringCompareWithIgnoreCase("/basicinfo/GetAuthorizationuser", absolutePath))
            {
                return true;
            }
            // 跨界检查通过
            if ("OPTIONS".Equals(httpMethod))
            {
                return true;
            }
            // 测试接口无需验证 [EditBy shaocx,2019-01-07]
            if (absolutePath.IndexOf("/test/".ToUpper()) > -1)
            {
                return true;
            }
            // 热后库中超过指定时间还是待检状态的库存统计无需验证 [EditBy shaocx,2019-07-12]
            if (StringHelper.StringCompareWithIgnoreCase("/quartz/afterHotExceptionInventoryData", absolutePath))
            {
                return true;
            }
            // 清除数据接口无需验证 [EditBy shaocx,2019-02-14]
            if (StringHelper.StringCompareWithIgnoreCase("/quartz/clearData", absolutePath))
            {
                return true;
            }
            // ECM系统实时状态任务无需验证 [EditBy shaocx,2019-02-14]
            if (StringHelper.StringCompareWithIgnoreCase("/quartz/getECMSystemStatus", absolutePath))
            {
                return true;
            }
            // 数据快照无需验证 [EditBy shaocx,2019-06-12]
            if (StringHelper.StringCompareWithIgnoreCase("/quartz/dataSnapShootJob", absolutePath))
            {
                return true;
            }
            // Eureka心跳 无需验证[EditBy shaocx,2019-02-14]
            if (StringHelper.StringCompareWithIgnoreCase("/eureka/eurekaHeartbeat", absolutePath))
            {
                return true;
            }
            // 更新权限接口无需验证 [EditBy shaocx,2019-03-08]
            if (StringHelper.StringCompareWithIgnoreCase("/logon/UpdateAuth", absolutePath))
            {
                return true;
            }
            // 获取权限接口无需验证 [EditBy shaocx,2019-03-08]
            if (StringHelper.StringCompareWithIgnoreCase("/logon/getAuth", absolutePath))
            {
                return true;
            }
            // 获取用户  [EditBy shaocx,2019-03-08]
            if (StringHelper.StringCompareWithIgnoreCase("/basicinfo/GetAuthorizationuser", absolutePath))
            {
                return true;
            }
            return false;
        }



        /// <summary>
        /// 验证Token
        /// </summary>
        /// <param name="token">token值</param>
        /// <param name="requestURL">请求URL</param>
        /// <param name="msg">验证信息</param>
        /// <param name="userInfos">验证完毕的Token对象集合</param>
        /// <returns></returns>
        public static bool verifyToken(String token, String requestURL, out String msg, out List<TokenInfo> userInfos)
        {

            SecurityToken secToken = new JwtSecurityToken();
            var handler = new JwtSecurityTokenHandler();
            TokenValidationParameters par = new TokenValidationParameters
            {
                RequireExpirationTime = true,
                RequireSignedTokens = true,
                ValidateActor = false,
                ValidateAudience = false,//true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,//false,
                ValidateTokenReplay = false,

                ValidIssuer = WIP,
                IssuerSigningKey = securityKey,
            };
            try
            {
                handler.ValidateToken(token, par, out secToken);

                JwtSecurityToken jwtToken = handler.ReadJwtToken(token);


                // 确认过期
                long now = WIPCommon.GetUnixTimeStampWithGLWZForSeconds();
                // 条件为!(iat < now && now < exp) >>令牌过期
                // 如果是集成用户，则不需要校验令牌是否过期
                if ((jwtToken.Payload.Iat <= now && now <= jwtToken.Payload.Exp) ||
                    jwtToken.Payload.Sub.ToUpper().IndexOf("integrated".ToUpper()) > -1)
                {
                    // 确认roles变更
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    List<ResourceMenuInfo> userRoles = getResourceMenuFormRedisOrMemory(jwtToken.Payload.Sub, 0, "");
                    List<TokenInfo> payloadRoles = new List<TokenInfo>();
                    foreach (Claim c in jwtToken.Payload.Claims)
                    {
                        String claim = c.Value;
                        if (claim.StartsWith("{\"loginname\":"))
                        {
                            payloadRoles.Add(serializer.Deserialize<TokenInfo>(claim));

                        }

                    }

                    var b_1 = payloadRoles.Where(a => !userRoles.Exists(t => a.roleId.Contains(t.roleId))).ToList().Count > 0;
                    var b_2 = userRoles.Where(a => !payloadRoles.Exists(t => a.roleId.Contains(t.roleId))).ToList()
                                  .Count > 0;
                    var b_3 = payloadRoles.Where(a => !userRoles.Exists(t => a.groupId.Contains(t.groupId))).ToList()
                                  .Count > 0;
                    var b_4 = userRoles.Where(a => !payloadRoles.Exists(t => a.groupId.Contains(t.groupId))).ToList()
                                  .Count > 0;
                    if (b_1
                        || b_2
                        || b_3
                        || b_4)
                    {
                        userInfos = null;
                        msg = "令牌变更";
                        return false;
                    }
                    if (!userRoles.Exists(t => t.baseUrl.Trim() != "" && t.baseUrl.Trim().ToUpper().Equals(requestURL.Trim().ToUpper())))
                    {
                        userInfos = null;
                        msg = "权限受限";
                        return false;
                    }
                    userInfos = payloadRoles;
                    msg = "有效";
                    return true;
                }
                else
                // 过期
                {
                    userInfos = null;
                    msg = "令牌过期";
                    return false;
                }
            }
            catch (Exception e)
            {
                userInfos = null;
                msg = "鉴权失败:" + e.Message;
                return false;
            }
        }

        /// <summary>
        /// 获取当前请求用户
        /// </summary>
        /// <returns></returns>
        public static string GetCurUserName()
        {
            var userName = "";
            try
            {
                userName = HttpContext.Current.Session["UserName"].ToString();

            }
            catch
            {

            }
            finally
            {
                if (string.IsNullOrEmpty(userName))
                {
                    userName = "sys";
                }
            }
            return userName;
        }

        /// <summary>
        /// 数据库查询权限(前台菜单)
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="rank"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public static List<ResourceMenuInfo> getResourceMenuForVUE(String userName, int rank, String parentId)
        {
            DatabaseManager dbe = new DatabaseManager();

            //处理rank 【EditBy shaocx,2019-01-07】
            var strRank = "";
            if (rank != 0)
                strRank = rank.ToString();

            SqlCommand cmd = new SqlCommand("uspWip_GetUserResourceMenuForVUE") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@loginUserName", userName);
            cmd.Parameters.AddWithValue("@rank", strRank);
            cmd.Parameters.AddWithValue("@parentId", parentId);
            var dt = dbe.GetSqlTableWithUsing(cmd);
            List<ResourceMenuInfo> menus = new List<ResourceMenuInfo>();
            if (dt != null && dt.Rows.Count > 0)
            {
                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    menus.Add(new ResourceMenuInfo()
                    {
                        loginname = dt.Rows[i]["loginname"].ToString(),
                        roleId = dt.Rows[i]["roleId"].ToString(),
                        rolename = dt.Rows[i]["rolename"].ToString(),
                        menuName = dt.Rows[i]["menuName"].ToString(),
                        dispSequence = dt.Rows[i]["dispSequence"].ToString(),
                        rank = dt.Rows[i]["rank"].ToString(),
                        url = dt.Rows[i]["url"].ToString(),
                        baseUrl = dt.Rows[i]["baseUrl"].ToString(),
                        icon = dt.Rows[i]["icon"].ToString(),
                        color = dt.Rows[i]["color"].ToString(),
                    });
                }
            }
            return menus;
        }

        /// <summary>
        /// 数据库查询权限
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="rank"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public static List<ResourceMenuInfo> getResourceMenu(String userName, int rank, String parentId)
        {
            DatabaseManager dbe = new DatabaseManager();

            //处理rank 【EditBy shaocx,2019-01-07】
            var strRank = "";
            if (rank != 0)
                strRank = rank.ToString();

            SqlCommand cmd = new SqlCommand("uspWip_GetUserResourceMenu") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@loginUserName", userName);
            cmd.Parameters.AddWithValue("@rank", strRank);
            cmd.Parameters.AddWithValue("@parentId", parentId);
            var dt = dbe.GetSqlTableWithUsing(cmd);
            List<ResourceMenuInfo> menus = new List<ResourceMenuInfo>();
            if (dt != null && dt.Rows.Count > 0)
            {
                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    menus.Add(new ResourceMenuInfo()
                    {
                        loginname = dt.Rows[i]["loginname"].ToString(),
                        groupId = dt.Rows[i]["groupId"].ToString(),
                        groupname = dt.Rows[i]["groupname"].ToString(),
                        roleId = dt.Rows[i]["roleId"].ToString(),
                        rolename = dt.Rows[i]["rolename"].ToString(),
                        menuName = dt.Rows[i]["menuName"].ToString(),
                        dispSequence = dt.Rows[i]["dispSequence"].ToString(),
                        rank = dt.Rows[i]["rank"].ToString(),
                        url = dt.Rows[i]["url"].ToString(),
                        baseUrl = dt.Rows[i]["baseUrl"].ToString(),
                        icon = dt.Rows[i]["icon"].ToString(),
                        color = dt.Rows[i]["color"].ToString(),
                    });
                }
            }
            return menus;
        }


        /// <summary>
        /// 优先从Redis或内存中读取
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="rank"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public static List<ResourceMenuInfo> getResourceMenuFormRedisOrMemory(String userName, int rank, String parentId)
        {
            //暂时先全部执行数据库
            //return getResourceMenu(userName, rank, parentId);

            RedisModel redisModel = getResourceMenuOnlyFormRedisOrMemory(userName);
            //Log4netHelper.WriteErrorLogByLog4Net(typeof(JwtHelp), "查询内存数据:" + JsonConvert.SerializeObject(redisModel));
            List<ResourceMenuInfo> menus = new List<ResourceMenuInfo>();

            if (redisModel == null)
            {//说明redis或内存中没有 

                menus = getResourceMenu(userName, rank, parentId);
                setResourceMenuToRedisOrMemory(userName, menus);
                redisModel = new RedisModel()
                {
                    resourceMenuInfoList = menus,
                    updateTime = WIPCommon.ForamtCurDateTime(),
                    userName = userName
                };
                //Log4netHelper.WriteInfoLogByLog4Net(typeof(JwtHelp), "redisModel:" + JsonConvert.SerializeObject(redisModel));
            }

            if (redisModel == null)
                return null;
            return redisModel.resourceMenuInfoList;

            //*/
        }

        /// <summary>
        /// 权限写入Redis或内存
        /// </summary>
        /// <param name="menus"></param>
        private static void setResourceMenuToRedisOrMemory(string userName, List<ResourceMenuInfo> menus)
        {
            RedisModel redisModel = new RedisModel()
            {
                userName = userName,
                resourceMenuInfoList = menus,
                updateTime = WIPCommon.ForamtCurDateTime()
            };

            if (AuthType == WipAuthType.REDIS)
            {
                
            }
            else
            {
                //写入缓存中
                wipAuthCacheDict.TryAdd(userName, redisModel);//尝试新增
                wipAuthCacheDict[userName] = redisModel;//更新
            }
        }


        /// <summary>
        /// 更新权限到Redis
        /// </summary>
        /// <param name="userList"></param>
        public static void UpdateAuthToRedis()
        {
            try
            {
                Task.Run(() =>
                {
                    List<UserInfoLogon> userList = WIP_SQLServerDAL.DALCommon.GetUserAccountView();

                    if (userList != null && userList.Count > 0)
                    {
                        foreach (var user in userList)
                        {
                            List<ResourceMenuInfo> menus = new List<ResourceMenuInfo>();
                            menus = getResourceMenu(user.Name, 0, "");
                            setResourceMenuToRedisOrMemory(user.Name, menus);
                        }

                        //判断如果这次内存字典中有，而userList没有的用户，表示该用户已删除了，要把他从内存中移除掉
                        List<string> removeList = new List<string>();
                        foreach (var item in wipAuthCacheDict)
                        {
                            if (!userList.Exists(t => t.Name == item.Key))
                            {
                                removeList.Add(item.Key);
                            }
                        }
                        foreach (var removeItem in removeList)
                        {
                            RedisModel redisModel = null;
                            wipAuthCacheDict.TryRemove(removeItem, out redisModel);
                        }
                    }
                    else
                    {//表示没有用户了，清空内存
                        wipAuthCacheDict = new ConcurrentDictionary<string, RedisModel>();
                    }
                });
            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// 获取权限
        /// </summary>
        /// <param name="userList"></param>
        public static List<RedisModel> GetAuthFormRedis()
        {
            List<RedisModel> redisModelList = new List<RedisModel>();
            try
            {
                List<UserInfoLogon> userList = WIP_SQLServerDAL.DALCommon.GetUserAccountView();
                RedisModel aa = null;
                if (userList != null && userList.Count > 0)
                {
                    foreach (var user in userList)
                    {
                        aa = getResourceMenuOnlyFormRedisOrMemory(user.Name);
                        redisModelList.Add(aa);
                    }
                }
            }
            catch
            {
                throw;
            }
            return redisModelList;
        }


        /// <summary>
        /// 从Redis或缓存中获取权限
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="rank"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        private static RedisModel getResourceMenuOnlyFormRedisOrMemory(String userName)
        {
            RedisModel redisModel = null;
            if (AuthType == WipAuthType.REDIS)
            {
             
            }
            else
            {
                if (wipAuthCacheDict.ContainsKey(userName))
                {
                    redisModel = wipAuthCacheDict[userName];
                }

            }

            return redisModel;

            //*/
        }
    }
}
