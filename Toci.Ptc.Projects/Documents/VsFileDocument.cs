using ProtoBuf;
using Toci.Piastcode.Social.Sockets.Implementations;
using Toci.Ptc.Environment.Interfaces;
using Toci.Ptc.Projects.Interfaces.Changes;

namespace Toci.Ptc.Projects.Documents
{
    [ProtoContract]
    public class VsFileDocument : VsDocumentBase
    {
        [ProtoMember(1)]
        public new TcEditedProjectItem TcEditedProjectItem { get; set; }

        public override bool CreateChange(ChangeTypes chngType, string base64EncodedChange)
        {
            throw new System.NotImplementedException();
        }
    }
}