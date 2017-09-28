using System.IO;
using ProtoBuf;
using Toci.Ptc.Environment.Interfaces;
using Toci.Ptc.Projects.Documents;
using Toci.Ptc.Projects.Interfaces.Changes;
using Toci.Ptc.Projects.Interfaces.Documents;
using Toci.Ptc.Users;
using Toci.Ptc.Users.Interfaces.Skeleton;

namespace Toci.Ptc.Server
{
    public class VisualStudioServer : Server<IVsDocument, IVisualStudioEnvironment>
    {
        public override bool Send(IVsDocument frame)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Serializer.Serialize(ms, frame);
                UserSocket.Send(ms.ToArray());
            }

            return true;
        }

        public override IVsDocument Receive(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                VsFileDocument frame = Serializer.Deserialize<VsFileDocument>(ms);
                return frame;
            }
        }

        protected override IUser CreateUser(IUserDataEntity udEnt)
        {
            return new VsUser
            {
                Name = udEnt.Name,
                UserId = udEnt.UserId,
                Id = udEnt.Id
            };
        }

        public VisualStudioServer() : base(2088)
        {
        }
    }
}