using ProtoBuf;

namespace Toci.Piastcode.Social.Entities.Interfaces
{
    [ProtoContract]
    public interface IEditChanges : IProjectItem
    {
        [ProtoMember(1)]
        int PositionStart { get; set; }

        [ProtoMember(2)]
        int OldPositionEnd { get; set; }

        [ProtoMember(3)]
        string Text { get; set; }
    }
}