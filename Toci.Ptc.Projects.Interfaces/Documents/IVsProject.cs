using System.Collections.Generic;

namespace Toci.Ptc.Projects.Interfaces.Documents
{
    public interface IVsProject : IProject<IVsDocument>
    {
        string SlnName { get; set; }

        string DirectoryPath { get; set; }

        Dictionary<string, IVsDocument> ProjectSrtucture { get; set; }
    }
}