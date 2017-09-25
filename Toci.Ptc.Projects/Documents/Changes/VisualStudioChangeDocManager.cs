using Toci.Ptc.Environment.Interfaces;
using Toci.Ptc.Projects.Interfaces.Changes;
using Toci.Ptc.Projects.Interfaces.Documents;
using Toci.Ptc.Users.Interfaces.Skeleton;

namespace Toci.Ptc.Projects.Documents.Changes
{
    public class VisualStudioChangeDocManager : EnvUserChangeDocManagerBase<IVisualStudioEnvironment, IVsUser, IVsChange, IVsDocument>
    {
        
    }
}