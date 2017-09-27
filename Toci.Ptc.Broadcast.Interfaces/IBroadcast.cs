using System.Net.Sockets;
using Toci.Ptc.Environment.Interfaces;
using Toci.Ptc.Projects.Interfaces.Changes;
using Toci.Ptc.Projects.Interfaces.Documents;
using Toci.Ptc.Users.Interfaces.Skeleton;

namespace Toci.Ptc.Broadcast.Interfaces
{
    public interface IBroadcast<in TDocument, out TServer>
    {
        TServer GetServer();

        bool BroadcastDocument(IUser user, TDocument doc);

        bool BroadcastChange(IUser user, TDocument doc);

        bool IntroduceOneself(Socket socket);
    }
}