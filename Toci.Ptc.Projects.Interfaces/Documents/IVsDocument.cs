using System.Collections.Generic;
using ProtoBuf;
using Toci.Piastcode.Social.Entities.Interfaces;
using Toci.Piastcode.Social.Sockets.Implementations;
using Toci.Ptc.Environment.Interfaces;
using Toci.Ptc.Projects.Interfaces.Changes;
using Toci.Ptc.Users.Interfaces.Skeleton;

namespace Toci.Ptc.Projects.Interfaces.Documents
{
    [ProtoContract]
    public interface IVsDocument : IDocument<IVisualStudioEnvironment, IVsChange, IVsUser>, IProjectItem
    {
        [ProtoMember(1)]
        List<IVsChange> Changes { get; set; }
    }
}