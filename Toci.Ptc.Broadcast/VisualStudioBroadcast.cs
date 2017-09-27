using ProtoBuf;
using System;
using System.IO;
using System.Net.Sockets;
using Toci.Ptc.Environment.Interfaces;
using Toci.Ptc.Projects.Interfaces.Changes;
using Toci.Ptc.Projects.Interfaces.Documents;
using Toci.Ptc.Server;
using Toci.Ptc.Users;
using Toci.Ptc.Users.Interfaces.Skeleton;

namespace Toci.Ptc.Broadcast
{
    public abstract class VisualStudioBroadcast : BroadcastBase<IDocument<IEnvironment, IChange<IEnvironment>, IUser>, VisualStudioClient>
    {
        protected VisualStudioBroadcast(string srvIp)
        {
            Server = new VisualStudioClient();
            ServerIp = srvIp; 
        } 

        public override bool IntroduceOneself(Socket socket)
        {
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            CoreUser = new VsUser
            {
                Name = userName,
            };
            CoreUser.SetConnectionSocket(socket);

            using (MemoryStream ms = new MemoryStream())
            {
                Serializer.Serialize(ms, CoreUser.Convert());
                socket.Send(ms.ToArray());
            }

            return true;
        }
    }
}