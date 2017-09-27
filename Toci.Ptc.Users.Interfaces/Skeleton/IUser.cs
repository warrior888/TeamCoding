using System.Net.Sockets;

namespace Toci.Ptc.Users.Interfaces.Skeleton
{
    public interface IUser
    {
        string Name { get; set; }

        string GlobalIp { get; }

        string LocalIp { get; }

        Socket UserSocket { get; }

        void SetConnectionSocket(Socket socket);

        void SetUserConnectionData(IUserDataEntity udEnt);

        IUserDataEntity Convert();
    }
}