using Toci.Ptc.Projects.Interfaces.Changes;
using Toci.Ptc.Users.Interfaces.Skeleton;

namespace Toci.Ptc.Projects.Documents.Changes.Managers
{
    public class VisualStudioEditDocManager : VisualStudioChangeDocManager
    {
        public override bool ChangeDocument(IVsChange change, IVsUser user)
        {
            return base.ChangeDocument(change, user);
        }
    }
}