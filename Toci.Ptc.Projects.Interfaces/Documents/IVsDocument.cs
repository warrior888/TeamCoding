using System.Collections.Generic;
using Toci.Piastcode.Social.Entities.Interfaces;
using Toci.Ptc.Environment.Interfaces;
using Toci.Ptc.Projects.Interfaces.Changes;
using Toci.Ptc.Users.Interfaces.Skeleton;

namespace Toci.Ptc.Projects.Interfaces.Documents
{
    public interface IVsDocument : IDocument<IVisualStudioEnvironment, IVsChange, IVsUser>, IProjectItem
    {
        List<IVsChange> Changes { get; set; }
    }
}