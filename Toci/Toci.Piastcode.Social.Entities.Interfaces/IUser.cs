using System.Net.Sockets;
using ProtoBuf;

namespace Toci.Piastcode.Social.Entities.Interfaces
{
    [ProtoContract]
    public interface IUser
    {
        [ProtoMember(1)]
        int Id { get; set; }

        [ProtoMember(2)]
        string Name { get; set; }

        [ProtoMember(3)]
        int UserID { get; set; }
    }
}