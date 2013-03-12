using System;
using System.Collections.Generic;
using System.Linq;
using TurnOnMyPCProcessing.BusinessEntities;
using TurnOnMyPCProcessing.localhost;

namespace TurnOnMyPCProcessing.Storages
{
    public class RemotePCStorage
    {
        public void RefreshPCStatuses(IEnumerable<LocalUserPCInfo> data)
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

        private UserPCInfo TransformToWebEntity(LocalUserPCInfo info)
        {
            return new UserPCInfo
                {
                    Login = info.Login,
                    PCName = info.PCName,
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
