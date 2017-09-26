namespace Toci.Ptc.Server.Interfaces.Communication
{
    public interface IServer<TChange, TEnvironment>
    {
        bool Send(TChange frame);

        TChange Receive(); // ??
    }
}