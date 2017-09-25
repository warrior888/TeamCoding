using Toci.Ptc.Environment.Interfaces;
using Toci.Ptc.Projects.Interfaces.Documents;
using Toci.Ptc.Users.Interfaces.Skeleton;

namespace Toci.Ptc.Broadcast.Interfaces
{
    public interface IBroadcast<in TEnvironment, in TDocument> 
        where TEnvironment : IEnvironment
        where TDocument : IDocument
    {
        bool BroadcastDocument(IUser user, TDocument doc, TEnvironment env);
    }
}