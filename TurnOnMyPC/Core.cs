using TurnOnMyPC.Logic;

namespace TurnOnMyPC
{
    public class Core
    {
        private static PCToTurnOnQueue _pcToTurnOnQueue;
        private static LocalUserInfoStorage _localUserInfoStorage;

        public static PCToTurnOnQueue PCToTurnOnQueue
        {
            get { return _pcToTurnOnQueue; }
        }

        public static LocalUserInfoStorage LocalUserInfoStorage
        {
            get { return _localUserInfoStorage; }
        }

        public static void Initialize()
        {
             _localUserInfoStorage = new LocalUserInfoStorage();
            _pcToTurnOnQueue = new PCToTurnOnQueue();
        }
    }
}