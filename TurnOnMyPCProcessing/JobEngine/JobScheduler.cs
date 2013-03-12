using System;
using System.Timers;
using TurnOnMyPCProcessing.Services;

namespace TurnOnMyPCProcessing.JobEngine
{
    public class JobScheduler
    {
        private readonly IJob _job;
        private readonly Timer _timer = new Timer();
        private readonly LoggerService _loggerService;

        public JobScheduler(IJob job, LoggerService loggerService)
        {
            _job = job;
            _loggerService = loggerService;

            _timer.Interval = job.RunningInterval;
            _timer.AutoReset = false;
        }

        public void Start()
        {
            _timer.Elapsed += TimerOnElapsed;
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Elapsed -= TimerOnElapsed;
            _timer.Stop();
        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            try
            {
                _job.Run();
            }
            catch (Exception ex)
            {
                _loggerService.LogException(ex);
            }

            _timer.Start();
        }
    }
}
