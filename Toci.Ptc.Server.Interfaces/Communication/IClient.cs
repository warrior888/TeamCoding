using System.Net.Sockets;

namespace Toci.Ptc.Server.Interfaces.Communication
{
    public interface IClient
    {
        Socket CreateSocket(string serverIp);
    }
}