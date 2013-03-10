using System;
using System.IO;
using System.ServiceProcess;
using System.Timers;
using TurnOnMyPCProcessing.Logic;

namespace TurnOnMyPCProcessing
{
    public partial class ProcessingService : ServiceBase
    {
        private readonly Timer _updateInfoTimer = new Timer();
        private readonly Timer _startPCTimer = new Timer();

        private readonly RemotePCManager _remotePcManager = new RemotePCManager();
        private readonly UserInfoStorage _userInfoStorage = new UserInfoStorage();
        private readonly WebServiceWrapper _webServiceWrapper = new WebServiceWrapper();

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
            try
            {
                DoStartPC();
            }
            catch
            {
                //
            }

            _startPCTimer.Start();

        }

        private void UpdateInfoTimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            try
            {
                DoUpdatePCStatuses();
            }
            catch
            {
                //
            }
            _updateInfoTimer.Start();
        }

        private void DoUpdatePCStatuses()
        {
            _userInfoStorage.RefreshDatasource();
            _webServiceWrapper.RefreshPCStatuses(_userInfoStorage.GetDatasource());
        }

        private void DoStartPC()
        {
            var pcAddresses = _webServiceWrapper.GetMacsToTurnOn();
            foreach (var address in pcAddresses)
            {
                _remotePcManager.WakeOnLan(address);
            }
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
            _startPCTimer.Start();
        }

        private void CreateUpdateInfoJob()
        {
            _updateInfoTimer.Interval = 60 * 1000;
            _updateInfoTimer.AutoReset = false;
            _updateInfoTimer.Elapsed += UpdateInfoTimerOnElapsed;
            _updateInfoTimer.Start();
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
