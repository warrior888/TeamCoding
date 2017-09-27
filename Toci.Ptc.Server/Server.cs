namespace Toci.Ptc.Server
{
    public abstract class Server<TChange, TEnvironment> : ServerBase<TChange, TEnvironment>
    {
        protected Server(int port) : base(port)
        {
        }
    }
}