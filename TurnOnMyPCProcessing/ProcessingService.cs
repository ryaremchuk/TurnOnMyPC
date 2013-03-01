using System;
using System.ServiceProcess;
using System.Timers;

namespace TurnOnMyPCProcessing
{
    public partial class ProcessingService : ServiceBase
    {
        private readonly Timer  _timer = new Timer();

        public ProcessingService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            _timer.Interval = 30*1000;
            _timer.Elapsed += TimerOnElapsed;
            _timer.Start();
        }

        protected override void OnStop()
        {
            _timer.Elapsed -= TimerOnElapsed;
            _timer.Stop();
        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            throw new NotImplementedException();
        }
    }
}
