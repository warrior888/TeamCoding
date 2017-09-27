using ProtoBuf;

namespace Toci.Ptc.Users.Interfaces.Skeleton
{
    [ProtoContract]
    public interface IUserDataEntity 
    {
        [ProtoMember(1)]
        int Id { get; set; }

        [ProtoMember(2)]
        string Name { get; set; }

        [ProtoMember(3)]
        int UserId { get; set; }

        [ProtoMember(4)]
        string GlobalIp { get; set; }

        [ProtoMember(5)]
        string LocalIp { get; set; }
    }
}