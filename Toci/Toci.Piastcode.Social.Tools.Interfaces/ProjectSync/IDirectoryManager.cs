using Toci.Piastcode.Social.Entities.Interfaces;

namespace Toci.Piastcode.Social.Tools.Interfaces.ProjectSync
{
    public interface IDirectoryManager
    {
        IProject Project { get; set; }

        void CreateDirectories(string[] directories);

        void PasteFiles(string[] files);
    }
}