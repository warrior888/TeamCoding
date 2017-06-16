using System.Collections.Generic;
using ProtoBuf;
using Toci.Piastcode.Social.Sockets.Interfaces;

namespace Toci.Piastcode.Social.Sockets.Implementations
{
    [ProtoContract]
    public class TcEditedProjectItem : TcProjectItem, IEditedProjectItem
    {
        [ProtoMember(5)]
        public List<TcEditChanges> EditChanges { get; set; }
    }
}