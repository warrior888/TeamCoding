using Toci.Ptc.Broadcast.Interfaces;
using Toci.Ptc.Environment.Interfaces;
using Toci.Ptc.Projects.Interfaces.Documents;
using Toci.Ptc.Users.Interfaces.Skeleton;

namespace Toci.Ptc.Broadcast
{
    public abstract class BroadcastBase<TEnvironment, TDocument, TChange, TUser, TServer> : IBroadcast<TEnvironment, TDocument, TChange, TUser, TServer>
        where TEnvironment : IEnvironment
        where TDocument : IDocument<TEnvironment, TChange, TUser>
    {
        public abstract bool BroadcastDocument(IUser user, TDocument doc, TEnvironment env, TServer srv);
    }
}