using System.Collections.Generic;
using ProtoBuf;

namespace Toci.Piastcode.Social.Sockets.Interfaces
{
    [ProtoContract]
    public interface IEditedProjectItem : IProjectItem
    {
        [ProtoMember(1)]
        List<IEditChanges> EditChanges { get; set; }
    }
}