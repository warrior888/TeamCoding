using ProtoBuf;

namespace Toci.Piastcode.Social.Sockets.Interfaces
{
    [ProtoContract]
    public interface IEditChanges
    {
        [ProtoMember(1)]
        int Position { get; set; }

        [ProtoMember(2)]
        string Text { get; set; }
    }
}