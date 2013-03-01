namespace TurnOnMyPCProcessing.BusinessEntities
{
    public class LocalUserPCInfo
    {
        public string Login { get; set; }
        public string PCName { get; set; }
        public string MacAddress { get; set; }
        public LocalPCState State { get; set; }
    }
}