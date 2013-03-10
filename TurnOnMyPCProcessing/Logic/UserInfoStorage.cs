using System.Collections.Generic;
using System.IO;
using TurnOnMyPCProcessing.BusinessEntities;

namespace TurnOnMyPCProcessing.Logic
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
            var d = new List<LocalUserPCInfo>
                {
                    new LocalUserPCInfo
                        {
                            Login = "test",
                            PCName = "sdsd",
                            MacAddress = "ds"
                        }
                };
            var ds = XmlSerializationService<List<LocalUserPCInfo>>.Serialize(d);

            var serializedData = File.ReadAllText(Settings.Default.PathToDataFile);

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