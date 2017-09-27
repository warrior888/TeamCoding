using System;
using Toci.Ptc.Environment.Interfaces;
using Toci.Ptc.Projects.Interfaces.Changes;
using Toci.Ptc.Projects.Interfaces.Documents;
using Toci.Ptc.Server;
using Toci.Ptc.Users.Interfaces.Skeleton;

namespace Toci.Ptc.Broadcast
{
    public class VisualStudioBroadcast : BroadcastBase<IDocument<IEnvironment, IChange<IEnvironment>, IUser>, VisualStudioClient>
    {
        public VisualStudioBroadcast()
        {
            Server = new VisualStudioClient();
            ServerIp = "54.36.98.229"; // put this to config cnstruct  etc
        } 

        public override bool IntroduceOneself(IUser user)
        {
            user.SetConnectionSocket(GetServer().CreateSocket(ServerIp)); 

            return true;
        }
    }
}