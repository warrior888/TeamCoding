using System.Net.Sockets;
using Toci.Piastcode.Social.Sockets.Interfaces.Connection;

namespace Toci.Piastcode.Social.Sockets.Connection
{
    public abstract class SocketConnection<TInput, TOutput> : ISocketConnection<TInput, TOutput>
    {
        protected SocketConnection(Socket socket)
        {
            this.socket = socket;
        }

        protected Socket socket;

        public abstract void SendData(TInput data);

        public abstract TOutput ReceiveData();
    }
}