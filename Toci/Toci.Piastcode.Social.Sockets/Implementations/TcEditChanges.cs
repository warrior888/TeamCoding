using ProtoBuf;
using Toci.Piastcode.Social.Sockets.Interfaces;

namespace Toci.Piastcode.Social.Sockets.Implementations
{
    [ProtoContract]
    public class TcEditChanges : IEditChanges
    {
        [ProtoMember(1)]
        public int PositionStart { get; set; }
        [ProtoMember(2)]
        public int OldPositionEnd { get; set; }
        [ProtoMember(3)]
        public string Text { get; set; }
    }
}