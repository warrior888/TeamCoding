using System.Collections.Generic;
using ProtoBuf;
using Toci.Piastcode.Social.Client.Interfaces;
using Toci.Piastcode.Social.Entities.Interfaces;
using Toci.Piastcode.Social.Sockets.Interfaces;

namespace Toci.Piastcode.Social.Sockets.Implementations
{
    [ProtoContract]
    public class TcProjectItemsCollection : List<IProjectItem>, IProjectItemsCollection
    {
        
    }
}