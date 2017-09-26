using System.Net;
using System.Net.Sockets;
using Toci.Ptc.Environment.Interfaces;
using Toci.Ptc.Projects.Interfaces.Changes;
using Toci.Ptc.Server.Interfaces.Communication;

namespace Toci.Ptc.Server
{
    public class VisualStudioClient : VisualStudioServer, IClient
    {
        public Socket CreateSocket(string serverIp)
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(serverIp), Port);
            return new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }
    }
}