using System.Collections.Generic;
using TurnOnMyPC.Logic;
using TurnOnMyPCProcessing.BusinessEntities;

namespace TurnOnMyPCProcessing
{
    public class UserInfoStorage
    {
        private static List<LocalUserPCInfo> _data = new List<LocalUserPCInfo>();

        public IEnumerable<LocalUserPCInfo> GetDatasource()
        {
            return _data;
        }

        public void RefreshDatasource()
        {
            TryReloadData();
            RefreshAllStatuses();
        }

        private void TryReloadData()
        {
            //todo: think about another way to store PC settings. because we can have a lot of PCs. RY
            var serializedData = Settings.Default.UserPCList;
            var dataFromFile = XmlSerializationService<List<LocalUserPCInfo>>.Deserialize(serializedData);
            dataFromFile.ForEach(i => i.State = LocalPCState.Unknown);

            _data.Clear();
            _data.AddRange(dataFromFile);
        }

        private void RefreshAllStatuses()
        {
            var remotePcManager = new RemotePCManager();
            foreach (var info in _data)
            {
                try
                {
                    info.State = remotePcManager.IsTurnedOn(info.PCName)
                                     ? LocalPCState.On
                                     : LocalPCState.Off;
                }
                catch
                {
                    continue;
                }
            }
        }
    }
}