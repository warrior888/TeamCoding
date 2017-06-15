using System.Collections.Generic;
using ProtoBuf;
using Toci.Piastcode.Social.Sockets.Interfaces;

namespace Toci.Piastcode.Social.Sockets.Implementations
{
    [ProtoContract]
    public class TcEditedProjectItem : IEditedProjectItem
    {
        [ProtoMember(1)]
        public ModificationType ItemModificationType { get; set; }
        [ProtoMember(2)]
        public string ProjectPath { get; set; }
        [ProtoMember(3)]
        public string FilePath { get; set; }
        [ProtoMember(4)]
        public string Content { get; set; }
        [ProtoMember(5)]
        public List<TcEditChanges> EditChanges { get; set; }
    }
}