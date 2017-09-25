using System.Collections.Generic;
using ProtoBuf;
using Toci.Piastcode.Social.Entities.Interfaces;
using Toci.Piastcode.Social.Sockets.Implementations;

namespace Toci.Piastcode.Social.Sockets.Interfaces
{
    public interface IEditedProjectItem : IProjectItem
    {
        List<TcEditChanges> EditChanges { get; set; }
    }
}