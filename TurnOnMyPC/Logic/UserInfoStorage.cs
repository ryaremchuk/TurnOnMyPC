using System;
using System.Collections.Generic;
using System.Linq;
using TurnOnMyPC.BusinessEntities;

namespace TurnOnMyPC.Logic
{
    public class UserInfoStorage
    {
        private static List<UserPCInfo> _data = new List<UserPCInfo>();

        public void ReloadData(IEnumerable<UserPCInfo> data)
        {
            _data.Clear();
            _data.AddRange(data);
        }

        public UserPCInfo GetData(string userName)
        {
            return _data.FirstOrDefault(d => d.Login.ToLower() == userName.ToLower());
        }
    }
}