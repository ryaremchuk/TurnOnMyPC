using System.Collections.Generic;
using System.ServiceProcess;
using TurnOnMyPCProcessing.JobEngine;
using TurnOnMyPCProcessing.JobEngine.Jobs;
using TurnOnMyPCProcessing.Logic;
using TurnOnMyPCProcessing.Services;
using TurnOnMyPCProcessing.Storages;

namespace TurnOnMyPCProcessing
{
    public partial class ProcessingService : ServiceBase
    {
        private readonly List<JobScheduler> _schedulers = new List<JobScheduler>();
        private readonly LoggerService _loggerService = new LoggerService();

        public ProcessingService()
        {
            InitializeComponent();
        }

#if DEBUG
        public void Process()
        {
            OnStart(new[] { string.Empty });
        }
#endif

        protected override void OnStart(string[] args)
        {
            _loggerService.CreateSourceIfNotExist();
            _loggerService.LogInformation("Service started");

            CreateJobSchedulers();
            _schedulers.ForEach(s => s.Start());
        }

        private void CreateJobSchedulers()
        {
            var remotePcManager = new RemotePCManager();
            var userInfoStorage = new LocalUserInfoStorage();
            var webServiceWrapper = new RemotePCStorage();

            _schedulers.AddRange(new[]
                {
                    new JobScheduler(new UpdatePCInfoJob(webServiceWrapper, userInfoStorage), _loggerService),
                    new JobScheduler(new WakePCJob(webServiceWrapper, remotePcManager), _loggerService)
                });
        }

        protected override void OnStop()
        {
            _schedulers.ForEach(s => s.Stop());
            _loggerService.LogInformation("Service stopped");
        }
    }
}
