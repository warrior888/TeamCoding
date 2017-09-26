using Toci.Ptc.Broadcast.Interfaces;
using Toci.Ptc.Environment.Interfaces;
using Toci.Ptc.Projects.Interfaces.Changes;
using Toci.Ptc.Projects.Interfaces.Documents;
using Toci.Ptc.Server.Interfaces.Communication;
using Toci.Ptc.Users.Interfaces.Skeleton;

namespace Toci.Ptc.Manager.Interfaces
{
    public interface IEnvUserChangeDocManager<out TBroadcast, out TProject> : IManager<TBroadcast, TProject>
        where TBroadcast : IBroadcast<IDocument<IEnvironment, IChange<IEnvironment>, IUser>, IServer<IChange<IEnvironment>, IEnvironment>>
    {
        bool ChangeDocument(IChange<IEnvironment> change, IUser user);
    }
}