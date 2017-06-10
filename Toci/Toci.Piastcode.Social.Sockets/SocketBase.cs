using System.Net;
using System.Net.Sockets;
using Toci.Piastcode.Social.Sockets.Interfaces;

namespace Toci.Piastcode.Social.Sockets
{
    public abstract class SocketBase : ISocketBase
    {
        public SocketBase(string ipAddress, int port)
        {
            IpAddress = ipAddress;
            Port = port;
        }

        protected Socket socket { get; set; }

        protected string IpAddress { get; set; }

        protected int Port { get; set; }

        public abstract void CreateSocket();
    }
}