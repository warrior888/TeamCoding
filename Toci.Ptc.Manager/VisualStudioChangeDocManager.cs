using System;
using System.Collections.Generic;
using Toci.Ptc.Broadcast.Interfaces;
using Toci.Ptc.Environment.Interfaces;
using Toci.Ptc.Manager.Managers;
using Toci.Ptc.Projects.Interfaces.Changes;
using Toci.Ptc.Projects.Interfaces.Documents;
using Toci.Ptc.Server.Interfaces.Communication;
using Toci.Ptc.Users.Interfaces.Skeleton;

namespace Toci.Ptc.Manager
{
    public class VisualStudioChangeDocManager : EnvUserChangeDocManagerBase
    <
        IBroadcast<IDocument<IEnvironment, IChange<IEnvironment>, IUser>, IServer<IChange<IEnvironment>, IEnvironment>>, 
        IProject<IDocument<IEnvironment, IChange<IEnvironment>, IUser>>
    >
    {
        protected Dictionary<ChangeTypes, Func<VisualStudioChangeDocManager>> Map;

        public VisualStudioChangeDocManager(string projName) : base(projName)
        {
            Map  = new Dictionary<ChangeTypes, Func<VisualStudioChangeDocManager>>
            {
                {ChangeTypes.Add, () => new VisualStudioAddDocManager(ProjectName) },
                {ChangeTypes.Edit, () => new VisualStudioEditDocManager(ProjectName) },
            };
        }

       /* public override bool ChangeDocument(IVsChange change, IVsUser user)
        {
            if (Map.ContainsKey(change.ChgType))
            {
                return Map[change.ChgType]().ChangeDocument(change, user);
            }

            return false;
        }*/
        public override bool ChangeDocument(IChange<IEnvironment> change, IUser user)
        {
            throw new NotImplementedException();
        }

        public override IProject<IDocument<IEnvironment, IChange<IEnvironment>, IUser>> GetProject(string projectName)
        {
            throw new NotImplementedException();
        }

        public override IBroadcast<IDocument<IEnvironment, IChange<IEnvironment>, IUser>, IServer<IChange<IEnvironment>, IEnvironment>> GetBroadcast()
        {
            throw new NotImplementedException();
        }
    }
}