using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.Activation;
using System.Net;
using WIP_common;
using WIP_Models;
using System.Configuration;

using WIP_BLL;
using SysManager.Common.Utilities;

namespace WIP_Personnel
{

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]

    public class ValidateUser : IValidateUser
    {

        private string GEBFUrl = ConfigHelper.GetValue("GEBF_URL");
        private string namespaceName = "WIP_Personnel.ValidateUser";

        #region 登陆方法

        public ReturnBody<LogonResult> canLogon(UserInfoLogon user)
        {
            String strMsg = string.Empty;
            try
            {
                // 暂时注释
                //strMsg = "Login Success";//暂时写死

                GEBF.BrilliantFactoryClient bfclient = new GEBF.BrilliantFactoryClient("BasicHttpBinding_IBrilliantFactory", GEBFUrl);
                bfclient.ClientCredentials.UserName.UserName = "GESystem";
                bfclient.ClientCredentials.UserName.Password = "proficy";

                bfclient.CanLogin(user.Name, user.PassWord, out strMsg);

                //*/
                WebHeaderCollection headers = WebOperationContext.Current.IncomingRequest.Headers;

                ReturnBody<LogonResult> res = new ReturnBody<LogonResult>();
                res.resCode = "00000";
                res.resMsg = "成功";
                res.resData = new LogonResult();
                if ("Login Success".Equals(strMsg))
                {
                    //异步更新内存中的权限
                    JwtHelp.UpdateAuthToRedis();

                    res.resData.isSuccess = true;
                    res.resData.loginMessage = "登录成功";
                    res.resData.sendToken = JwtHelp.GenerateToken(user.Name, null); //headers["Authorization"];
                    // 根据用户至DB获取resource
                    res.resData.resoruceMenu = new List<ResourceMenu>();
                    // 获取一级模块
                    List<ResourceMenu> menu3s = new List<ResourceMenu>();
                    List<ResourceMenu> menu2s = new List<ResourceMenu>();
                    List<WIP_Models.ResourceMenuInfo> rank1 = JwtHelp.getResourceMenuForVUE(user.Name, 1, "");
                    foreach (WIP_Models.ResourceMenuInfo r1 in rank1)
                    {
                        ResourceMenu menu1 = new ResourceMenu();
                        menu1.menuName = r1.menuName;
                        menu1.menuLevel = "1";
                        menu1.menuDispSequence = r1.dispSequence;
                        menu1.menuID = r1.dispSequence;
                        menu1.url = r1.url;
                        menu1.color = r1.color;
                        menu1.icon = r1.icon;
                        // 获取二级权限
                        List<WIP_Models.ResourceMenuInfo> rank2 = JwtHelp.getResourceMenuForVUE(user.Name, 2, r1.roleId);
                        foreach (WIP_Models.ResourceMenuInfo r2 in rank2)
                        {
                            if (r2.menuName == "系统集成")
                            {
                                continue;
                            }
                            ResourceMenu menu2 = new ResourceMenu();
                            menu2.menuName = r2.menuName;
                            menu2.menuLevel = "2";
                            menu2.menuDispSequence = r2.dispSequence;
                            menu2.menuID = r2.dispSequence;
                            menu2.url = r2.url;
                            menu2.color = r2.color;
                            menu2.icon = r2.icon;

                            // 获取三级权限
                            List<WIP_Models.ResourceMenuInfo> rank3 = JwtHelp.getResourceMenuForVUE(user.Name, 3, r2.roleId);
                            foreach (WIP_Models.ResourceMenuInfo r3 in rank3)
                            {
                                ResourceMenu menu3 = new ResourceMenu();
                                menu3.menuName = r3.menuName;
                                menu3.menuLevel = "3";
                                menu3.menuDispSequence = r3.dispSequence;
                                menu3.menuID = r3.dispSequence;
                                menu3.url = r3.url;
                                menu3.color = r3.color;
                                menu3.icon = r3.icon;
                                if (menu2.children == null)
                                {
                                    menu2.children = new List<ResourceMenu>();
                                }
                                menu2.children.Add(menu3);
                            }
                            menu2s.Add(menu2);
                            if (menu1.children == null)
                            {
                                menu1.children = new List<ResourceMenu>();
                            }
                            menu1.children.Add(menu2);
                        }

                        res.resData.resoruceMenu.Add(menu1);

                    }
                    // 返回数据


                }
                else if ("User Name is Incorrect".Equals(strMsg))
                {
                    res.resData.isSuccess = false;
                    res.resData.loginMessage = "用户名不存在或不匹配";
                    res.resData.sendToken = null;
                }
                else if ("Password is incorrect".Equals(strMsg))
                {
                    res.resData.isSuccess = false;
                    res.resData.loginMessage = "请输入正确密码";
                    res.resData.sendToken = null;
                }
                else
                {
                    res.resData.isSuccess = false;
                    res.resData.loginMessage = "登录失败";
                    res.resData.sendToken = null;

                }

                return res;
            }
            catch (Exception ex)
            {
                ReturnBody<LogonResult> res = new ReturnBody<LogonResult>();
                res.resCode = "00001";
                res.resMsg = ex.Message;
                return res;
            }

        }
        public String canLogonO(UserInfoLogon user)
        {
            String msg = "Ok";
            // url
            //WebOperationContext.Current.IncomingRequest.UriTemplateMatch.RequestUri.AbsolutePath
            /*
            List<TokenInfo> userInfos;
            JwtHelp.verifyToken("eyJhbGciOiJIUzM4NCIsInR5cCI6IkpXVCJ9.eyJpYXQiOiIxNTMzNjEzNDI0IiwiZXhwIjoiMTU2NTE0OTQyNCIsImlzcyI6IlNBR1dXSVAiLCJzdWIiOiJFQ01pbnRlZ3JhdGVkIiwidXNlcm5hbWUiOiJFQ01pbnRlZ3JhdGVkIiwidXNlcmdyb3VwIjpbeyJsb2dpbm5hbWUiOiJFQ01pbnRlZ3JhdGVkIiwiZ3JvdXBJZCI6IjRmNTFjOTlkLThhMjMtNDA0YS05ZTIzLWYzYWE2ZjkxYTgwZiIsImdyb3VwbmFtZSI6IkVDTWludGVncmF0ZWQiLCJyb2xlSWQiOiI2ZDJmZmYxMi0xMjlhLTQyMTctYjc0ZC1mZGU5OWUzNjI3NGQiLCJyb2xlbmFtZSI6IkVDTembhuaIkCJ9XX0.rm81jyRF9zs85xkz4ToGCEWMUg-5uU6ZBbADi_5CuTXbvKSSx_9Y6qFQPonr8PCD", "", out msg, out userInfos);
            //*/
            return msg;
        }

        public String canLogonTestGet()
        {
            String strMsg;
            GEBF.BrilliantFactoryClient bfclient = new GEBF.BrilliantFactoryClient("BasicHttpBinding_IBrilliantFactory", GEBFUrl);
            bfclient.ClientCredentials.UserName.UserName = "GESystem";
            bfclient.ClientCredentials.UserName.Password = "proficy";

            bfclient.CanLogin("sagwtestone", "123456", out strMsg);


            return strMsg;
        }

        public Dictionary<String, String> testGet()
        {
            GEBF.BrilliantFactoryClient bfclient = new GEBF.BrilliantFactoryClient("BasicHttpBinding_IBrilliantFactory", GEBFUrl);
            bfclient.ClientCredentials.UserName.UserName = "GESystem";
            bfclient.ClientCredentials.UserName.Password = "proficy";
            Dictionary<String, String> asd = bfclient.GetAllProperty("24230768");

            //WorkOrder

            return asd;//bfclient.GetAllProperty("24240768");
        }
        #endregion

        #region 修改密码方法


        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public ReturnBody<string> Userupdatepwd(UserPassWordParam pwd)
        {

            ReturnBody<string> retBody = null;
            String strMsg = string.Empty;
            var strMsg2 = "";
            GEBF.BrilliantFactoryClient bfclient = new GEBF.BrilliantFactoryClient("BasicHttpBinding_IBrilliantFactory", GEBFUrl);
            bfclient.ClientCredentials.UserName.UserName = "GESystem";
            bfclient.ClientCredentials.UserName.Password = "proficy";

            WebHeaderCollection headers = WebOperationContext.Current.IncomingRequest.Headers;
            bfclient.UpdatePwd(pwd.uName, pwd.uPwd, pwd.uNewPwd, out  strMsg);

            if ("Password Updated Success".Equals(strMsg))
            {
                strMsg2 = "密码修改成功";
                retBody = BLLHelpler.GetReturnBody<string>(ResCode.SUCCESS, ResMsg.SUCCESS, strMsg2);
            }
            else if ("User Name is Incorrect".Equals(strMsg))
            {
                strMsg2 = "用户不存在";
                retBody = BLLHelpler.GetReturnBody<string>(ResCode.FAILURE, ResMsg.FAILURE, strMsg2);
            }
            else if ("Password is incorrect".Equals(strMsg))
            {
                strMsg2 = "原密码不正确";
                retBody = BLLHelpler.GetReturnBody<string>(ResCode.FAILURE, ResMsg.FAILURE, strMsg2);
            }

            //if (result)
            //{

            //}
            //else
            //{
            //    strMsg = "密码修改失败";
            //    retBody = BLLHelpler.GetReturnBody<string>(ResCode.FAILURE,  strMsg);
            //}
            return retBody;
        }

        public string Userupdatepwd0()
        {
            return "ok";
        }

        #endregion






        #region 更新权限到缓存

        /// <summary>
        /// 更新权限到Redis
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ReturnBody<string> UpdateAuth()
        {
            ExceptionInfoEntity exception = WipLog4netHelper.GetNewExceptionInfo<string>(namespaceName, "UpdateAuth", "", "", "");
            try
            {

                JwtHelp.UpdateAuthToRedis();

                ReturnBody<string> ret = new ReturnBody<string>();
                ret.resCode = ResCode.SUCCESS;
                return ret;
            }
            catch (Exception ex)
            {
                WipLog4netHelper.GetExceptionInfoForError(ex, ref exception);
                return BLLHelpler.GetReturnBody<string>(ResCode.FAILURE, ResMsg.FAILURE, exception);
            }
        }

        #endregion


        #region 获取权限

        /// <summary>
        /// 获取权限
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ReturnBody<List<RedisModel>> GetAuth()
        {
            ExceptionInfoEntity exception = WipLog4netHelper.GetNewExceptionInfo<string>(namespaceName, "GetAuth", "", "", "");
            try
            {
                List<RedisModel> redisModelList = new List<RedisModel>();
                redisModelList = JwtHelp.GetAuthFormRedis();

                ReturnBody<List<RedisModel>> ret = new ReturnBody<List<RedisModel>>();
                ret.resCode = ResCode.SUCCESS;
                ret.resData = redisModelList;
                return ret;
            }
            catch (Exception ex)
            {
                WipLog4netHelper.GetExceptionInfoForError(ex, ref exception);
                return BLLHelpler.GetReturnBody<List<RedisModel>>(ResCode.FAILURE, ResMsg.FAILURE, exception);
            }
        }

        #endregion
    }
}
