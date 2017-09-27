using ProtoBuf;

namespace Toci.Ptc.Users.Interfaces.Skeleton
{
    [ProtoContract]
    public interface IUserDataEntity 
    {
        [ProtoMember(1)]
        string Name { get; set; }

        [ProtoMember(2)]
        string GlobalIp { get; set; }

    }
}