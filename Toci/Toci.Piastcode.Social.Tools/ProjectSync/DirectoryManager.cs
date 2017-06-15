using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
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

        public void GetFilesFromCurrentProject(Dictionary<string, string> fileContents)
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

        /// <summary>
        /// Compares server files with client files.
        /// Iterates through all server files and checks if client has these files or if these files were changed.
        /// IMPORTANT: Due to paths being different for all machines (clients, server), all paths must be trimmed to
        /// contain relative path starting from the root directory of the solution.
        /// </summary>
        /// <param name="serverFiles"></param>
        /// <param name="clientFiles"></param>
        /// <returns></returns>
        public virtual string[] GetChangedFiles(Dictionary<string, string> serverFiles, Dictionary<string, string> clientFiles)
        {
            Dictionary<string, string> newDict = new Dictionary<string, string>(serverFiles);
            List<string> changedFiles = new List<string>();

            using (var md5 = MD5.Create())
            {
                foreach (var serverFile in serverFiles)
                {
                    if (clientFiles.ContainsKey(serverFile.Key))
                    {
                        if (BitConverter.ToString(md5.ComputeHash(Encoding.ASCII.GetBytes(clientFiles[serverFile.Key]))) !=
                            BitConverter.ToString(md5.ComputeHash(Encoding.ASCII.GetBytes(serverFile.Value))))
                        {
                            changedFiles.Add(serverFile.Key);
                        }
                    }
                    else
                    {
                        changedFiles.Add(serverFile.Key);
                    }
                }
            }

            return changedFiles.ToArray();
        }

        public void PasteFiles(string[] files)
        {
            throw new System.NotImplementedException();
        }
    }
}