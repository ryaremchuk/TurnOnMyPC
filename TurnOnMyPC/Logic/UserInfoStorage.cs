using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using TurnOnMyPC.Logic.BusinessEntities;

namespace TurnOnMyPC.Logic
{
    public class UserInfoStorage
    {
        private static DateTime _lastDataUpdateTime;
        private static List<UserPCInfo> _data = new List<UserPCInfo>();


        public bool IsUserPCRegistered(string userName)
        {
            return GetUserPCInfo(userName) != null;
        }

        public string GetUserPCName(string userName)
        {
            return GetUserPCInfo(userName).PCName;
        }

        public string GetUserMacAddress(string userName)
        {
            return GetUserPCInfo(userName).PCMacAddress;
        }

        private UserPCInfo GetUserPCInfo(string userName)
        {
            var filePath = ConfigurationManager.AppSettings["PathToDataFile"];
            var lastWriteTime = new FileInfo(filePath).LastWriteTime;
            
            var needReloadData = _data.Count == 0 || _lastDataUpdateTime != lastWriteTime;
            if (needReloadData)
            {
                ReloadAllData(filePath);
                _lastDataUpdateTime = lastWriteTime;
            }

            return _data.FirstOrDefault(d => d.UserDomainLogin.ToUpper() == userName.ToUpper());
        }

        private void ReloadAllData(string filePath)
        {
            var serializedData = File.ReadAllText(filePath);
            var dataFromFile = XmlSerializationService<List<UserPCInfo>>.Deserialize(serializedData);

            _data.Clear();
            _data.AddRange(dataFromFile);
        }
    }
}