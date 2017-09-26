using Toci.Ptc.Environment.Interfaces;
using Toci.Ptc.Projects.Interfaces.Changes;
using Toci.Ptc.Users.Interfaces.Skeleton;

namespace Toci.Ptc.Projects.Interfaces.Documents
{
    public interface IVsDocument : IDocument<IVisualStudioEnvironment, IVsChange, IVsUser>
    {
        string Path { get; set; }

     //   System.IO.DirectoryInfo
    }
}