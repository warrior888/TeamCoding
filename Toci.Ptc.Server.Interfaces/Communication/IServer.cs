namespace Toci.Ptc.Server.Interfaces.Communication
{
    public interface IServer<TFrame, TEnvironment>
    {
        bool Send(TFrame frame);

        TFrame Receive(); // ??
    }
}