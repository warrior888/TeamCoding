using System.Collections.Generic;
using Toci.Ptc.Environment.Interfaces;
using Toci.Ptc.Projects.Interfaces.Changes;
using Toci.Ptc.Projects.Interfaces.Documents;
using Toci.Ptc.Users.Interfaces.Skeleton;

namespace Toci.Ptc.Projects.Documents
{
    public abstract class DocumentBase<TEnvironment, TChange, TUser> : IDocument<TEnvironment, TChange, TUser>
    {
        public DocumentType DocType { get; set; }

        public Dictionary<TUser, List<TChange>> Changes { get; set; }
        
        public abstract bool CreateChange(ChangeTypes chngType, string base64EncodedChange, TEnvironment env);
    }
}