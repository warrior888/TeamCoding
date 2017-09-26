using System.Net.Sockets;

namespace Toci.Ptc.Users.Interfaces.Skeleton
{
    public interface IUser
    {
        string Name { get; }

        string GlobalIp { get; }

        Socket UserSocket { get; }

        void SetConnectionSocket(Socket socket);
    }
}