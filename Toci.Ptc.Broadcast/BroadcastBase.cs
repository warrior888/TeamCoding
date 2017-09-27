using System.Net.Sockets;
using Toci.Ptc.Broadcast.Interfaces;
using Toci.Ptc.Environment.Interfaces;
using Toci.Ptc.Projects.Interfaces.Changes;
using Toci.Ptc.Projects.Interfaces.Documents;
using Toci.Ptc.Server;
using Toci.Ptc.Server.Interfaces.Communication;
using Toci.Ptc.Users.Interfaces.Skeleton;

namespace Toci.Ptc.Broadcast
{
    public abstract class BroadcastBase<TDocument, TServer> : IBroadcast<TDocument, TServer> 
        where TServer : IServer<IChange<IEnvironment>, IEnvironment>
    {
        protected TServer Server;
        protected string ServerIp;
        protected IUser CoreUser;

        public virtual TServer GetServer()
        {
            return Server;
        }

        public abstract bool BroadcastDocument(IUser user, TDocument doc);

        public abstract bool BroadcastChange(IUser user, TDocument doc);

        public abstract bool IntroduceOneself(Socket socket);

        public abstract void CreateSocket(string serverIp);
    }
}