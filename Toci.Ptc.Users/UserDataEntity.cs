using ProtoBuf;
using Toci.Ptc.Users.Interfaces.Skeleton;

namespace Toci.Ptc.Users
{
    [ProtoContract]
    public class UserDataEntity : IUserDataEntity
    {
        [ProtoMember(1)]
        public string Name { get; set; }

        [ProtoMember(2)]
        public string GlobalIp { get; set; }
    }
}