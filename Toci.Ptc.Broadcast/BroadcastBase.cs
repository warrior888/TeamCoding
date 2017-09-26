using Toci.Ptc.Broadcast.Interfaces;
using Toci.Ptc.Environment.Interfaces;
using Toci.Ptc.Projects.Interfaces.Changes;
using Toci.Ptc.Projects.Interfaces.Documents;
using Toci.Ptc.Users.Interfaces.Skeleton;

namespace Toci.Ptc.Broadcast
{
    public abstract class BroadcastBase<TDocument, TServer> : IBroadcast<TDocument, TServer>
        where TDocument : IDocument<IEnvironment, IChange<IEnvironment>, IUser>
    {
        public TServer GetServer()
        {
            throw new System.NotImplementedException();
        }

        public bool BroadcastDocument(IUser user, TDocument doc)
        {
            throw new System.NotImplementedException();
        }

        public bool BroadcastChange(IUser user, TDocument doc, IChange<IEnvironment> change)
        {
            throw new System.NotImplementedException();
        }
    }
}