using System.Collections.Generic;
using System.ComponentModel;
using ProtoBuf;
using Toci.Piastcode.Social.Client.Interfaces;
using Toci.Piastcode.Social.Entities.Interfaces;

namespace Toci.Piastcode.Social.Sockets.Interfaces
{
    [ProtoContract]
    public interface IProjectItemsCollection : IList<IProjectItem>
    {
        
    }
}