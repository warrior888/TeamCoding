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
        public override bool IntroduceOneself(IUser user)
        {
            user.SetConnectionSocket(GetServer().CreateSocket(user.LocalIp));

            return true;
        }
    }
}