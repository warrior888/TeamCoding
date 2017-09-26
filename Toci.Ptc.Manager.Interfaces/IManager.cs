namespace Toci.Ptc.Manager.Interfaces
{
    public interface IManager<out TBroadcast, out TProject>
    {
        TProject GetProject(string projectName);

        TBroadcast GetBroadcast();
    }
}