using TurnOnMyPCProcessing.Logic;
using TurnOnMyPCProcessing.Storages;

namespace TurnOnMyPCProcessing.JobEngine.Jobs
{
    public class UpdatePCInfoJob : IJob
    {
        private readonly RemotePCStorage _remotePCStorage;
        private readonly LocalUserInfoStorage _localUserInfoStorage;

        public int RunningInterval { get { return 30*1000; } }

        public UpdatePCInfoJob(RemotePCStorage remotePCStorage, LocalUserInfoStorage localUserInfoStorage)
        {
            _localUserInfoStorage = localUserInfoStorage;
            _remotePCStorage = remotePCStorage;
        }

        public void Run()
        {
            _localUserInfoStorage.RefreshDatasource();
            _remotePCStorage.RefreshPCStatuses(_localUserInfoStorage.GetDatasource());
        }
    }
}
