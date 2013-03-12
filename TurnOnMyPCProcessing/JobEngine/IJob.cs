namespace TurnOnMyPCProcessing.JobEngine
{
    public interface IJob
    {
        int RunningInterval { get; }
        void Run();
    }
}
