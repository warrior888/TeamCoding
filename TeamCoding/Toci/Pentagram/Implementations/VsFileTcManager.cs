using TeamCoding.Toci.Pentagram.Interfaces;
using Toci.Ptc.Broadcast;
using Toci.Ptc.Users.Interfaces.Skeleton;

namespace TeamCoding.Toci.Pentagram.Implementations
{
    public class VsFileTcManager : IVsFileTcManager
    {
        protected VisualStudioBroadcast VsBroadcast = new VisualStudioBroadcast();

        public bool Connect(IVsUser user)
        {
            return VsBroadcast.IntroduceOneself(user);
        }
    }
}