using System.Collections.Generic;
using Toci.Ptc.Projects.Interfaces.Changes;
using Toci.Ptc.Users.Interfaces.Skeleton;

namespace Toci.Ptc.Projects.Interfaces.Documents
{
    public interface IDocument<out TEnvironment, out TChange, out TUser>
    {
        DocumentType DocType { get; set; }

        bool CreateChange(ChangeTypes chngType, string base64EncodedChange);

        string Base64EncodedEntireDocument { get; set; }
    }
}