using System.ServiceProcess;
using Common.Logging;
using Quartz.Impl;
using Quartz;

namespace WIP_QuartzService
{
    public partial class QuartzService : ServiceBase
    {
        private readonly ILog logger;
        private IScheduler scheduler;

        public QuartzService()
        {
            InitializeComponent();
            logger = LogManager.GetLogger(GetType());

            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            scheduler = schedulerFactory.GetScheduler();
           
        }

        protected override void OnStart(string[] args)
        {
            scheduler.Start();
            logger.Info("Quartz服务成功启动");
        }

        protected override void OnStop()
        {
            scheduler.Shutdown();
            logger.Info("Quartz服务成功终止");
        }

        protected override void OnPause()
        {
            scheduler.PauseAll();
        }

        protected override void OnContinue()
        {
            scheduler.ResumeAll();
        }
      
    }
}
