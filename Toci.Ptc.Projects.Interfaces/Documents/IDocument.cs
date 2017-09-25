using System.Collections.Generic;
using Toci.Ptc.Projects.Interfaces.Changes;
using Toci.Ptc.Users.Interfaces.Skeleton;

namespace Toci.Ptc.Projects.Interfaces.Documents
{
    public interface IDocument<TEnvironment>
    {
        DocumentType DocType { get; set; }

        Dictionary<IUser, List<IChange<TEnvironment>>> Changes { get; set; }
    }
}