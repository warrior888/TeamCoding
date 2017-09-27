using System.Net.Sockets;

namespace Toci.Ptc.Server.Interfaces.Communication
{
    public interface IServer<TDocument, TEnvironment>
    {
        bool Send(TDocument frame);

        TDocument Receive(); // ??

        Socket CreateSocket();

        void GetSocket(Socket socket);

        int ConnectionPort { get; }

        void Connect(string serverIp);
    }
}