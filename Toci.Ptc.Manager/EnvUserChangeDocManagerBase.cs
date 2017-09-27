using System.Collections.Generic;
using System.Linq;
using Toci.Ptc.Broadcast.Interfaces;
using Toci.Ptc.Environment.Interfaces;
using Toci.Ptc.Manager.Interfaces;
using Toci.Ptc.Projects.Interfaces.Changes;
using Toci.Ptc.Projects.Interfaces.Documents;
using Toci.Ptc.Server.Interfaces.Communication;
using Toci.Ptc.Users.Interfaces.Skeleton;

namespace Toci.Ptc.Manager
{
    public abstract class EnvUserChangeDocManagerBase<TBroadcast, TProject> : IEnvUserChangeDocManager<TBroadcast, TProject>
        where TBroadcast : IBroadcast<IDocument<IEnvironment, IChange<IEnvironment>, IUser>, IServer<IChange<IEnvironment>, IEnvironment>>
        where TProject : IProject<IDocument<IEnvironment, IChange<IEnvironment>, IUser>>
    {
        protected string ProjectName;

        protected EnvUserChangeDocManagerBase(string projectName)
        {
            ProjectName = projectName;
        }

        public abstract bool ChangeDocument(IChange<IEnvironment> change, IUser user);

        public abstract TProject GetProject(string projectName);

        public abstract TBroadcast GetBroadcast();
    }
}