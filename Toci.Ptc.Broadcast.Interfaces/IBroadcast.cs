using Toci.Ptc.Environment.Interfaces;
using Toci.Ptc.Projects.Interfaces.Documents;
using Toci.Ptc.Users.Interfaces.Skeleton;

namespace Toci.Ptc.Broadcast.Interfaces
{
    public interface IBroadcast<in TEnvironment, in TDocument, TChange, TUser, in TServer> 
        where TEnvironment : IEnvironment
        where TDocument : IDocument<TEnvironment, TChange, TUser>
    { 
        bool BroadcastDocument(IUser user, TDocument doc, TEnvironment env, TServer srv);
    }
}