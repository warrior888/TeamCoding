using System.Collections.Generic;
using ProtoBuf;
using Toci.Piastcode.Social.Sockets.Implementations;

namespace Toci.Piastcode.Social.Sockets.Interfaces
{
    [ProtoContract]
    public interface IEditedProjectItem : IProjectItem
    {
        [ProtoMember(1)]
        List<TcEditChanges> EditChanges { get; set; }
    }
}