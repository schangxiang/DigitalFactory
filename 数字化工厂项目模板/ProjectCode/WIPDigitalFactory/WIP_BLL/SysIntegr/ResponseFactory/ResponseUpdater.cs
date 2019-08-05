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
    /// 请求返回处理类
    /// </summary>
    public class ResponseUpdater
    {
        public ResponseUpdaterRet _ResponseUpdaterRet = null;

        public ResponseUpdater(bool execResult, ExceptionInfoEntity exception)
        {
            _ResponseUpdaterRet = new ResponseUpdaterRet()
            {
                execResult = execResult,
                exception = exception
            };
        }
        public virtual void DoResponse<T>(string host, string url, T param, int execCount)
        {
            ReturnBody<string> resultModel = null;
            resultModel = RequestHelper.CommonHttpRequestForPost<T, string>(host,
              url, param);
            if (resultModel != null && resultModel.resCode == ResCode.SUCCESS)
            {//成功
                _ResponseUpdaterRet.execResult = true;
            }
            else
            {
                _ResponseUpdaterRet.execResult = false;
                _ResponseUpdaterRet.exception.exceptionMsg = "执行次数:" + execCount.ToString()
                    + ",系统返回结果：" + JsonConvert.SerializeObject(resultModel);
            }
        }
    }
}
