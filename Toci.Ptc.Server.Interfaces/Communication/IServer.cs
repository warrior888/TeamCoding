namespace Toci.Ptc.Server.Interfaces.Communication
{
    public interface IServer<TDocument, TEnvironment>
    {
        bool Send(TDocument frame);

        TDocument Receive(); // ??

        void CreateSocket();

        int ConnectionPort { get; }
    }
}