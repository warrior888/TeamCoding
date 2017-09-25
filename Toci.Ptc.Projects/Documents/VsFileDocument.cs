using Toci.Ptc.Environment.Interfaces;
using Toci.Ptc.Projects.Interfaces.Changes;

namespace Toci.Ptc.Projects.Documents
{
    public class VsFileDocument : VsDocumentBase
    {
        public override bool CreateChange(ChangeTypes chngType, string base64EncodedChange, IVisualStudioEnvironment env)
        {
            throw new System.NotImplementedException();
        }
    }
}