using TurnOnMyPC.Logic;

namespace TurnOnMyPC
{
    public class Core
    {
        private static PCToTurnOnQueue _pcToTurnOnQueue;
        private static UserInfoStorage _userInfoStorage;

        public static PCToTurnOnQueue PCToTurnOnQueue
        {
            get { return _pcToTurnOnQueue; }
        }

        public static UserInfoStorage UserInfoStorage
        {
            get { return _userInfoStorage; }
        }

        public static void Initialize()
        {
             _userInfoStorage = new UserInfoStorage();
            _pcToTurnOnQueue = new PCToTurnOnQueue();
        }
    }
}