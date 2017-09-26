using Toci.Ptc.Environment.Interfaces;
using Toci.Ptc.Projects.Interfaces.Changes;
using Toci.Ptc.Users;
using Toci.Ptc.Users.Interfaces.Skeleton;

namespace Toci.Ptc.Server
{
    public class VisualStudioServer : Server
    {
        public override bool Send(IChange<IEnvironment> frame)
        {
            throw new System.NotImplementedException();
        }

        public override IChange<IEnvironment> Receive()
        {
            throw new System.NotImplementedException();
        }

        protected override IUser CreateUser(IUserDataEntity udEnt)
        {
            return new VsUser
            {
                
            };
        }

        public VisualStudioServer() : base(2088)
        {
        }
    }
}