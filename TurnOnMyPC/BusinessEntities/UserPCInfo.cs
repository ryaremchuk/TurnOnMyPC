namespace TurnOnMyPC.BusinessEntities
{
    public class UserPCInfo
    {
        public string PCName { get; set; }
        public string PCMacAddress { get; set; }
        public PCState State { get; set; }
    }
}