using System;
using System.Collections.Generic;
using Toci.Ptc.Environment.Interfaces;
using Toci.Ptc.Projects.Documents.Changes.Managers;
using Toci.Ptc.Projects.Interfaces.Changes;
using Toci.Ptc.Projects.Interfaces.Documents;
using Toci.Ptc.Users.Interfaces.Skeleton;

namespace Toci.Ptc.Projects.Documents.Changes
{
    public class VisualStudioChangeDocManager : EnvUserChangeDocManagerBase<IVisualStudioEnvironment, IVsUser, IVsChange, IVsDocument>
    {
        protected Dictionary<ChangeTypes, Func<VisualStudioChangeDocManager>> Map;

        public VisualStudioChangeDocManager()
        {
            Map  = new Dictionary<ChangeTypes, Func<VisualStudioChangeDocManager>>
            {
                {ChangeTypes.Add, () => new VisualStudioAddDocManager() },
                {ChangeTypes.Edit, () => new VisualStudioEditDocManager() },
            };
        }

        public override bool ChangeDocument(IVsChange change, IVsUser user)
        {
            if (Map.ContainsKey(change.ChgType))
            {
                return Map[change.ChgType]().ChangeDocument(change, user);
            }

            return false;
        }
    }
}