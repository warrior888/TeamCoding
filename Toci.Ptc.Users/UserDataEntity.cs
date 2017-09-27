using ProtoBuf;
using Toci.Ptc.Users.Interfaces.Skeleton;

namespace Toci.Ptc.Users
{
    [ProtoContract]
    public class UserDataEntity : IUserDataEntity
    {
        [ProtoMember(1)]
        public int Id { get; set; }

        [ProtoMember(2)]
        public string Name { get; set; }

        [ProtoMember(3)]
        public int UserId { get; set; }

        [ProtoMember(4)]
        public string GlobalIp { get; set; }

        [ProtoMember(5)]
        public string LocalIp { get; set; }
    }
}