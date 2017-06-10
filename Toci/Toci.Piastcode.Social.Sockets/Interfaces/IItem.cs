using ProtoBuf;

namespace Toci.Piastcode.Social.Client.Interfaces
{
    [ProtoContract]
    public interface IItem
    {
        [ProtoMember(1)]
        ModificationType ItemModificationType { get; set; }
    }
}