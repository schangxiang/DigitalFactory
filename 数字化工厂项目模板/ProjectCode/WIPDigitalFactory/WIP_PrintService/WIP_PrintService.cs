using System.ServiceProcess;
using Common.Logging;
using System.Threading;
using WIP_Print;
using System;
using System.Threading.Tasks;

namespace WIP_PrintService
{
    public partial class WIP_PrintService : ServiceBase
    {
        private readonly ILog logger;
        static CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        public WIP_PrintService()
        {
            InitializeComponent();
            logger = LogManager.GetLogger(GetType());
            Task.Factory.StartNew(PrintThread, cancelTokenSource.Token);
        }

        protected override void OnStart(string[] args)
        {
            logger.Info("打印服务成功启动");
        }

        protected override void OnStop()
        {
            cancelTokenSource.Cancel();
            logger.Info("打印服务成功终止");
        }

        protected override void OnPause()
        {
        }

        protected override void OnContinue()
        {
        }


        private void PrintThread()
        {
            //判断是否取消任务
            while (!cancelTokenSource.IsCancellationRequested)
            {
                try
                {
                    logger.Info("一次打印开始");
                    PrintService.GetInstance().Print();
                    logger.Info("一次打印结束");
                }
                catch (Exception e)
                {
                    logger.Error("一次打印错误:" + e.Message, e);
                }
                Thread.Sleep(5000);//休眠5秒
            }
        }
    }
}
