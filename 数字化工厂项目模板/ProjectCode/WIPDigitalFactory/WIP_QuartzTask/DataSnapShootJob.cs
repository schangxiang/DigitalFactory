using Newtonsoft.Json;
using Quartz;
using SysManager.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using WIP_BLL;
using WIP_common;
using WIP_Models;

namespace WIP_QuartzTask
{
    /// <summary>
    ///  数据快照
    /// </summary>
    public class DataSnapShootJob : IJob
    {
        //使用Common.Logging.dll日志接口实现日志记录
        private static readonly Common.Logging.ILog logger = Common.Logging.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static readonly string wipHost = BLLHelpler.GetConfigValue("WIPHost");
        private static readonly string URL_DataSnapShoot = "/quartz/dataSnapShootJob";

        #region IJob 成员

        public void Execute(IJobExecutionContext context)
        {
            string guid = Guid.NewGuid().ToString();
            try
            {
                logger.Info("[" + guid + "]DataSnapShootJob 任务开始运行,wipHost:" + wipHost + ",url:" + URL_DataSnapShoot);

                string content = new HTTPHelper(wipHost).postContentForString(URL_DataSnapShoot,
                    "", new Guid());

                logger.Info("[" + guid + "]DataSnapShootJob 任务返回结果,运行结束content:" + content);
            }
            catch (Exception ex)
            {
                logger.Error("[" + guid + "]DataSnapShootJob 运行异常", ex);
            }
        }

        #endregion
    }
}
