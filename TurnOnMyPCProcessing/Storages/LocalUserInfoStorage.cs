using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TurnOnMyPCProcessing.BusinessEntities;
using TurnOnMyPCProcessing.Services;

namespace TurnOnMyPCProcessing.Logic
{
    public class LocalUserInfoStorage
    {
        private static List<PCInfo> _data = new List<PCInfo>();

        public IEnumerable<PCInfo> GetDatasource()
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
            var serializedData = File.ReadAllText(Settings.Default.PathToDataFile);

            var dataFromFile = XmlSerializationService<List<PCInfo>>.Deserialize(serializedData);
            dataFromFile.ForEach(i => i.State = LocalPCState.Unknown);

            _data.Clear();
            _data.AddRange(dataFromFile);
        }

        private void RefreshAllStatuses()
        {
            var remotePcManager = new RemotePCManager();
            Parallel.ForEach(_data, (info) =>
                {
                    info.State = LocalPCState.Off;
                    if (remotePcManager.IsTurnedOn(info.Name))
                        info.State = LocalPCState.On;
                });
        }
    }
}