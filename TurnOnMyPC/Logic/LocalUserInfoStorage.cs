﻿using System;
using System.Collections.Generic;
using System.Linq;
using TurnOnMyPC.BusinessEntities;

namespace TurnOnMyPC.Logic
{
    public class LocalUserInfoStorage
    {
        private static List<UserPCInfo> _data = new List<UserPCInfo>();

        public void ReloadData(IEnumerable<UserPCInfo> data)
        {
            _data.Clear();
            _data.AddRange(data);
        }

        public UserPCInfo GetData(string userName)
        {
            if (userName == "1")
            {
                return new UserPCInfo
                    {
                        Login = "1",
                        PCMacAddress = "asd",
                        PCName = "pc name",
                        State = PCState.Unknown
                    };
            }

            return _data.FirstOrDefault(d => d.Login.ToLower() == userName.ToLower());
        }
    }
}