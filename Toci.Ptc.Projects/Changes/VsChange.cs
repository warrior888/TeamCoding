using ProtoBuf;
using Toci.Ptc.Projects.Interfaces.Changes;

namespace Toci.Ptc.Projects.Changes
{
    [ProtoContract]
    public class VsChange : IVsChange
    {
        [ProtoMember(1)]
        public int PositionStart { get; set; }

        [ProtoMember(2)]
        public int OldPositionEnd { get; set; }

        [ProtoMember(3)]
        public string Text { get; set; }

        [ProtoMember(4)]
        public string ProjectPath { get; set; }

        [ProtoMember(5)]
        public string FilePath { get; set; }

        [ProtoMember(6)]
        public string Content { get; set; }
    }
}