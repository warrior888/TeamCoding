using System.Collections.Generic;
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

        public static void GetFilesFromCurrentProject(Dictionary<string, string> fileContents)
        {
            List<string> files = new List<string>();
            string[] searchPattern = {"*.sln", "*.csproj", "*.cs", "*.xml", ".txt"};
            string projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            SearchOption searchOption = SearchOption.AllDirectories;

            foreach (var sp in searchPattern)
            {
                files.AddRange(Directory.GetFiles(projectPath, sp, searchOption));
            }

            foreach (var file in files)
            {
                fileContents.Add(file, File.ReadAllText(file));
            }
        }

        public void PasteFiles(string[] files)
        {
            throw new System.NotImplementedException();
        }
    }
}