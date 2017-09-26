using Toci.Ptc.Environment.Interfaces;
using Toci.Ptc.Projects.Interfaces.Changes;

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

        public VisualStudioServer() : base(2088)
        {
        }
    }
}