using System;
using System.ServiceProcess;
using System.Timers;

namespace TurnOnMyPCProcessing
{
    public partial class ProcessingService : ServiceBase
    {
        private readonly Timer _updateInfoTimer = new Timer();
        private readonly Timer _startPCTimer = new Timer();

        private readonly RemotePCManager _remotePcManager = new RemotePCManager();
        private readonly UserInfoStorage _userInfoStorage = new UserInfoStorage();

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
            CreateUpdateInfoJob();
            CreateStartPCJobTimer();
        }
        
        private void StartPcTimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            throw new NotImplementedException();
            _startPCTimer.Start();
        }



        private void UpdateInfoTimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            throw new NotImplementedException();
            _updateInfoTimer.Start();
        }

        protected override void OnStop()
        {
            StopUpdateInfoJob();
            StopStartPCJobTimer();
        }

        private void CreateStartPCJobTimer()
        {
            _startPCTimer.Interval = 60 * 1000;
            _startPCTimer.AutoReset = false;
            _startPCTimer.Elapsed += StartPcTimerOnElapsed;
        }

        private void CreateUpdateInfoJob()
        {
            _updateInfoTimer.Interval = 60 * 1000;
            _updateInfoTimer.AutoReset = false;
            _updateInfoTimer.Elapsed += UpdateInfoTimerOnElapsed;
        }

        private void StopStartPCJobTimer()
        {
            _startPCTimer.Elapsed -= StartPcTimerOnElapsed;
            _startPCTimer.Stop();
        }

        private void StopUpdateInfoJob()
        {
            _updateInfoTimer.Elapsed -= UpdateInfoTimerOnElapsed;
            _updateInfoTimer.Stop();
        }
    }
}
