using System.IO;
using Toci.Piastcode.Social.Entities.Interfaces;
using Toci.Piastcode.Social.Tools.Interfaces.ProjectSync;

namespace Toci.Piastcode.Social.Tools.ProjectSync
{
    public class DirectoryManager : IDirectoryManager
    {
        public IProject Project { get; set; }

        public void CreateDirectories(string[] directories)
        {
            foreach (var directory in directories)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(directory));
            }
        }

        public void PasteFiles(string[] files)
        {
            throw new System.NotImplementedException();
        }
    }
}