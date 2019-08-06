<%@ Application Language="C#" %>
<%@ Import Namespace="WIP_common" %>
<%@ Import Namespace="WIP_Models" %>
<%@ Import Namespace="WIP_Personnel" %>
<%@ Import Namespace="WIP_MES" %>
<%@ Import Namespace="System.Web.Routing" %>
<%@ Import Namespace="System.ServiceModel.Activation" %>
<%@ Import Namespace="WIP_BasicInfo" %>
<%@ Import Namespace="WIP_WIPMgmt" %>
<%@ Import Namespace="WIP_common" %>
<%@ Import Namespace="WIP_Test" %>

<script RunAt="server">
    string sessionName = "";
    void Application_Start(object sender, EventArgs e)
    {
        RegisterRoutes(RouteTable.Routes);
        //注册MEF
        IOCContainer.RegisterContainer();
    }

    private void RegisterRoutes(RouteCollection routes)
    {
        WebServiceHostFactory webFactory = new WebServiceHostFactory();
        routes.Add(new ServiceRoute("test", webFactory, typeof(TestService)));
        routes.Add(new ServiceRoute("logon", webFactory, typeof(ValidateUser)));
        routes.Add(new ServiceRoute("mesintegr", webFactory, typeof(MesSysInteg)));
        routes.Add(new ServiceRoute("basicinfo", webFactory, typeof(BasicInfo)));//基本信息
        routes.Add(new ServiceRoute("wipmgmt", webFactory, typeof(WipMgmt)));//在制品跟踪
    }

    void Application_AcquireRequestState(object sender, EventArgs e)
    {
        HttpContext.Current.Session["UserName"] = sessionName;
    }
    void Application_BeginRequest(object sender, EventArgs e)
    {
#warning 注意：这里暂时写死了验证 【shaocx】，以后去掉

        /*
        Dictionary<string, string> dict = new Dictionary<string, string>();
        dict.Add("Url", absolutePath);
        int i = 0;
        foreach (var item in HttpContext.Current.Request.Headers.AllKeys)
        {
            dict.Add(item.ToString(), HttpContext.Current.Request.Headers[i].ToString());
            i++;
        }
        //遍历Post参数
        Dictionary<string, string> postParamDict = new Dictionary<string, string>();
        foreach (string key in HttpContext.Current.Request.Form.AllKeys)
        {
            if (key == "__VIEWSTATE" || key == "__VIEWSTATEGENERATOR" || key == "__EVENTVALIDATION")
            {
                continue;
            }
            postParamDict.Add(key, Request.Form[key].ToString());
        }
        dict.Add("PostParam", Newtonsoft.Json.JsonConvert.SerializeObject(postParamDict));

        //遍历Get参数。 
        Dictionary<string, string> getParamDict = new Dictionary<string, string>();
        foreach (string key in this.Request.QueryString.AllKeys)
        {
            getParamDict.Add(key, Request.QueryString[key].ToString());
        }
        dict.Add("GetParam", Newtonsoft.Json.JsonConvert.SerializeObject(getParamDict));
        Log4netHelper.WriteInfoLogByLog4Net(typeof(string), Newtonsoft.Json.JsonConvert.SerializeObject(dict));
        
        //*/
        return;

        string absolutePath = HttpContext.Current.Request.Url.AbsolutePath.ToUpper();
        string httpMethod = HttpContext.Current.Request.HttpMethod;
        if (JwtHelp.isExemptValidateToken(absolutePath, httpMethod))
            return;

        String msg;
        List<TokenInfo> userinfo;
        if (JwtHelp.verifyToken(HttpContext.Current.Request.Headers["Authorization"], absolutePath, out msg, out userinfo))
        {
            if (userinfo != null && userinfo.Count > 0)
            {
                sessionName = userinfo[0].loginname;
            }
            //Response.Write("ok");
            return;
        }
        else
        {
            Response.StatusCode = 401;
            //Response.Write("{\"resCode\":\"01003\",\"resData\":null ,\"resMsg\":\"权限不足\"}");

            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("Url", absolutePath);
            int i = 0;
            foreach (var item in HttpContext.Current.Request.Headers.AllKeys)
            {
                dict.Add(item.ToString(), HttpContext.Current.Request.Headers[i].ToString());
                i++;
            }
            //遍历Post参数
            Dictionary<string, string> postParamDict = new Dictionary<string, string>();
            foreach (string key in HttpContext.Current.Request.Form.AllKeys)
            {
                if (key == "__VIEWSTATE" || key == "__VIEWSTATEGENERATOR" || key == "__EVENTVALIDATION")
                {
                    continue;
                }
                postParamDict.Add(key, Request.Form[key].ToString());
            }
            dict.Add("PostParam", Newtonsoft.Json.JsonConvert.SerializeObject(postParamDict));

            //遍历Get参数。 
            Dictionary<string, string> getParamDict = new Dictionary<string, string>();
            foreach (string key in this.Request.QueryString.AllKeys)
            {
                getParamDict.Add(key, Request.QueryString[key].ToString());
            }
            dict.Add("GetParam", Newtonsoft.Json.JsonConvert.SerializeObject(getParamDict));
            SysManager.Common.Utilities.Log4netHelper.WriteErrorLogByLog4Net(typeof(string), "权限不足->" + Newtonsoft.Json.JsonConvert.SerializeObject(dict));

            return;
        }

    }

</script>
