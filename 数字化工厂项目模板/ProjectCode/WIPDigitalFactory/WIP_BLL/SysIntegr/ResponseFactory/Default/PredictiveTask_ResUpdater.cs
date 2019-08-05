
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
    /// 质量预测发起
    /// </summary>
    public class PredictiveTask_ResUpdater : ResponseUpdater
    {
        public PredictiveTask_ResUpdater(bool execResult, ExceptionInfoEntity exception)
            : base(execResult, exception) //base()的意思是调用基类的构造函数…… 
        {

        }
        public override void DoResponse<T>(string host, string url, T param, int execCount)
        {
            ReturnBody<string> resultModelForPredictiveTask = null;
            resultModelForPredictiveTask = RequestHelper.CommonHttpRequestForGet<T, string>(host,
              url, param, 180);//超时时间设定为3分钟
            if (resultModelForPredictiveTask != null && resultModelForPredictiveTask.resCode == ResCode.SUCCESS)
            {//成功
                _ResponseUpdaterRet.execResult = true;
            }
            else
            {
                _ResponseUpdaterRet.execResult = false;
                _ResponseUpdaterRet.exception.exceptionMsg = "执行次数:" + execCount.ToString() + ",resultModelForPredictiveTask：" + JsonConvert.SerializeObject(resultModelForPredictiveTask);
            }
        }
    }
}
