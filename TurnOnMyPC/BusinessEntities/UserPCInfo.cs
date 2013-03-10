namespace TurnOnMyPC.BusinessEntities
{
    public class UserPCInfo
    {
        public string Login { get; set; }
        public string PCName { get; set; }
        public string PCMacAddress { get; set; }
        public PCState State { get; set; }
    }
}