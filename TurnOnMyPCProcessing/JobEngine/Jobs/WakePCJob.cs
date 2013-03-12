using TurnOnMyPCProcessing.Logic;
using TurnOnMyPCProcessing.Services;
using TurnOnMyPCProcessing.Storages;

namespace TurnOnMyPCProcessing.JobEngine.Jobs
{
    public class WakePCJob : IJob
    {
        private readonly RemotePCStorage _remotePCStorage;
        private readonly RemotePCManager _remotePCManager;

        public int RunningInterval { get { return 60*1000; } }

        public WakePCJob(RemotePCStorage remotePCStorage, RemotePCManager remotePCManager)
        {
            _remotePCStorage = remotePCStorage;
            _remotePCManager = remotePCManager;
        }

        public void Run()
        {
            var pcAddresses = _remotePCStorage.GetMacsToTurnOn();
            foreach (var address in pcAddresses)
            {
                _remotePCManager.WakeOnLan(address);
            }
        }
    }
}
