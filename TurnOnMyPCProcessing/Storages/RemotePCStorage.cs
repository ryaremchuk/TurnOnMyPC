using System;
using System.Collections.Generic;
using System.Linq;
using TurnOnMyPCProcessing.BusinessEntities;
using TurnOnMyPCProcessing.localhost;

namespace TurnOnMyPCProcessing.Storages
{
    public class RemotePCStorage
    {
        public void RefreshPCStatuses(IEnumerable<PCInfo> data)
        {
            using (var webService = new WebService())
            {
                webService.UpdateData(
                        Settings.Default.webServiceUserName, 
                        Settings.Default.webServiceUserPassword,
                        data.Select(TransformToWebEntity).ToArray());
            }
        }

        public string[] GetMacsToTurnOn()
        {
            using (var webService = new WebService())
            {
                var result = webService.GetMacsToTurnOn(
                    Settings.Default.webServiceUserName,
                    Settings.Default.webServiceUserPassword);

                return result;
            }            
        }

        public void RemoveMacFromQueue(string mac)
        {
            using (var webService = new WebService())
            {
                webService.RemoveMacFromQueue(
                    Settings.Default.webServiceUserName,
                    Settings.Default.webServiceUserPassword,
                    mac);
            }            
        }

        private UserPCInfo TransformToWebEntity(PCInfo info)
        {
            return new UserPCInfo
                {
                    PCName = info.Name,
                    State = ToWebEntity(info.State),
                    PCMacAddress = info.MacAddress
                };
        }

        private PCState ToWebEntity(LocalPCState state)
        {
            switch (state)
            {
                case LocalPCState.Unknown:
                    return PCState.Unknown;
                case LocalPCState.On:
                    return PCState.On;
                case LocalPCState.Off:
                    return PCState.Off;
                default:
                    throw new ArgumentOutOfRangeException("state");
            }
        }
    }
}
