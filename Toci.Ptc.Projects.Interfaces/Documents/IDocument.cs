using System.Collections.Generic;
using Toci.Ptc.Projects.Interfaces.Changes;
using Toci.Ptc.Users.Interfaces.Skeleton;

namespace Toci.Ptc.Projects.Interfaces.Documents
{
    public interface IDocument<in TEnvironment, TChange, TUser>
    {
        DocumentType DocType { get; set; }

        Dictionary<TUser, List<TChange>> Changes { get; set; }

        bool CreateChange(ChangeTypes chngType, string base64EncodedChange, TEnvironment env);
    }
}