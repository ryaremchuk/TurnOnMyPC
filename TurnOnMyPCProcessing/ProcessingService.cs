using System;
using System.Diagnostics;
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

            CreateUpdateInfoJob();
            CreateStartPCJobTimer();
        }
        
        private void StartPcTimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            try
            {
                DoStartPC();
            }
            catch (Exception ex)
            {
                _loggerService.LogException(ex);
            }

            _startPCTimer.Start();
        }

        private void UpdateInfoTimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            try
            {
                var sw = new Stopwatch();
                sw.Start();
                DoUpdatePCStatuses();
                sw.Stop();
            }
            catch (Exception ex)
            {
                _loggerService.LogException(ex);
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
