using System.Collections.Generic;
using Toci.Ptc.Projects.Interfaces.Changes;
using Toci.Ptc.Users.Interfaces.Skeleton;

namespace Toci.Ptc.Projects.Documents.Changes.Managers
{
    public class VisualStudioAddDocManager : VisualStudioChangeDocManager
    {
        public override bool ChangeDocument(IVsChange change, IVsUser user)
        {
            List<IVsChange> result = GetChangesForUser(user);

            //Document.Changes.Add(user, result);

            return true;
        }
    }
}