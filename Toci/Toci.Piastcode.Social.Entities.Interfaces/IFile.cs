using System.IO;

namespace Toci.Piastcode.Social.Entities.Interfaces
{
    public interface IFile
    {
        FileStream File { get; set; }

        string FileName { get; set; }

        string RelativePath { get; set; }
    }
}