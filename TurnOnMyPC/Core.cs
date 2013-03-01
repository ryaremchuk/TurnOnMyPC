using TurnOnMyPC.Logic;

namespace TurnOnMyPC
{
    //todo: refactor this. this is not good solution. But I need to do it quick. RY
    public class Core
    {
        private static RemotePCManager _remotePCManager;
        private static UserInfoStorage _userInfoStorage;

        public static RemotePCManager RemotePCManager
        {
            get { return _remotePCManager ?? (_remotePCManager = new RemotePCManager()); }
        }

        public static UserInfoStorage UserInfoStorage
        {
            get { return _userInfoStorage ?? (_userInfoStorage = new UserInfoStorage()); }
        }
    }
}