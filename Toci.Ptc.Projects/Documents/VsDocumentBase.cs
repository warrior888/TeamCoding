using System.Collections.Generic;
using Toci.Ptc.Environment.Interfaces;
using Toci.Ptc.Projects.Interfaces.Changes;
using Toci.Ptc.Projects.Interfaces.Documents;
using Toci.Ptc.Users.Interfaces.Skeleton;

namespace Toci.Ptc.Projects.Documents
{
    public abstract class VsDocumentBase : DocumentBase<IVisualStudioEnvironment, IVsChange, IVsUser>, IVsDocument
    {
        public string ProjectPath { get; set; }

        public string FilePath { get; set; }

        public string Content { get; set; }

        public List<IVsChange> Changes { get; set; }
    }
}