using System;
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

        public UserPCInfo GetData(string pcName)
        {
            //if (userName == "1")
            //{
            //    return new UserPCInfo
            //        {
            //            Login = "1",
            //            PCMacAddress = "asd",
            //            PCName = "pc name",
            //            State = PCState.Unknown
            //        };
            //}
            //else if (userName == "2")
            //{
            //    return new UserPCInfo
            //        {
            //            Login = "2",
            //            PCMacAddress = "asd",
            //            PCName = "pc name2",
            //            State = PCState.Unknown
            //        };
            //}

            return _data.FirstOrDefault(d => d.PCName.ToLower() == pcName.ToLower());
        }

        public IEnumerable<UserPCInfo> GetAllData()
        {
            //return new[]
            //    {
            //        new UserPCInfo
            //            {
            //                Login = "1",
            //                PCMacAddress = "asd",
            //                PCName = "pc name",
            //                State = PCState.Unknown
            //            },
            //        new UserPCInfo
            //            {
            //                Login = "2",
            //                PCMacAddress = "asd",
            //                PCName = "pc name2",
            //                State = PCState.On
            //            }
            //    };
            return _data;
        }
    }
}