
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIP_Models;

namespace WIP_BLL
{
    /// <summary>
    /// 推送流转卡信息给WCS
    /// </summary>
    public class PushProcessCardInfoToWCS_ResUpdater : ResponseUpdater
    {
        public PushProcessCardInfoToWCS_ResUpdater(bool execResult, ExceptionInfoEntity exception)
            : base(execResult, exception) //base()的意思是调用基类的构造函数…… 
        {

        }
        public override void DoResponse<T>(string host, string url, T param, int execCount)
        {
            ReturnBody<PushProcessCardInfoToWCSModel> resultByPushProcessCardInfoToWCSView = null;
            resultByPushProcessCardInfoToWCSView = RequestHelper.CommonHttpRequestForPost<T, PushProcessCardInfoToWCSModel>(host,
              url, param);
            if (resultByPushProcessCardInfoToWCSView != null && resultByPushProcessCardInfoToWCSView.resCode == ResCode.SUCCESS
                && resultByPushProcessCardInfoToWCSView.resData != null
         && !string.IsNullOrEmpty(resultByPushProcessCardInfoToWCSView.resData.success) && resultByPushProcessCardInfoToWCSView.resData.success.ToUpper() == "Y")
            {//成功
                _ResponseUpdaterRet.execResult = true;
            }
            else
            {
                _ResponseUpdaterRet.execResult = false;
                _ResponseUpdaterRet.exception.exceptionMsg = "执行次数:" + execCount.ToString() + ",resultByPushProcessCardInfoToWCSView：" + JsonConvert.SerializeObject(resultByPushProcessCardInfoToWCSView);
            }
        }
    }
}
