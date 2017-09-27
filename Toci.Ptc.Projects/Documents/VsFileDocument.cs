using Toci.Piastcode.Social.Sockets.Implementations;
using Toci.Ptc.Environment.Interfaces;
using Toci.Ptc.Projects.Interfaces.Changes;

namespace Toci.Ptc.Projects.Documents
{
    public class VsFileDocument : VsDocumentBase
    {
        public TcEditedProjectItem TcEditedProjectItem { get; set; }

        public override bool CreateChange(ChangeTypes chngType, string base64EncodedChange)
        {
            throw new System.NotImplementedException();
        }
    }
}