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

        protected virtual Dictionary<string, IChange<IEnvironment>> GetChangesForUser(IUser user, string documentName)
        {
            IDocument<IEnvironment, IChange<IEnvironment>, IUser> document = GetProject(ProjectName).GetDocument(documentName);

            if (document.Changes.ContainsKey(user))
            {
                //IEnumerable<KeyValuePair<> > document.Changes.Where(m => m.Key == user); 
            }

            return null;
        }

        public TProject GetProject(string projectName)
        {
            throw new System.NotImplementedException();
        }

        public TBroadcast GetBroadcast()
        {
            throw new System.NotImplementedException();
        }

        public abstract bool ChangeDocument(IChange<IEnvironment> change, IUser user);
    }
}