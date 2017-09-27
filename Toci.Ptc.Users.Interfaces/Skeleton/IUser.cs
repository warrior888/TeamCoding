using System.Net.Sockets;
using ProtoBuf;

namespace Toci.Ptc.Users.Interfaces.Skeleton
{
    [ProtoContract]
    public interface IUser
    {
        [ProtoMember(1)]
        int Id { get; set; }

        [ProtoMember(2)]
        string Name { get; set; }

        [ProtoMember(3)]
        int UserId { get; set; }

        [ProtoMember(4)]
        string GlobalIp { get; }

        [ProtoMember(5)]
        string LocalIp { get; }
        
        Socket UserSocket { get; }

        void SetConnectionSocket(Socket socket);

        void SetUserConnectionData(IUserDataEntity udEnt);

        IUserDataEntity Convert();
    }
}