using System.Collections.Generic;
using Microsoft.VisualStudio.Text;

namespace TeamCoding.Toci.Implementations
{
    public class EnvOpenedFilesManager
    {
        protected Dictionary<string, ITextBuffer> EnvOpenedFiles = new Dictionary<string, ITextBuffer>();

        public virtual void AddOpenedFile(string filePath, ITextBuffer file)
        {
            filePath = NormalizeFilePath(filePath);
            if (IsFileOpenedInEnv(filePath))
            {
                EnvOpenedFiles[filePath] = file;
            }
            else
            {
                EnvOpenedFiles.Add(filePath, file);
            }
        }

        public virtual bool IsFileOpenedInEnv(string filePath)
        {
            filePath = NormalizeFilePath(filePath);
            return EnvOpenedFiles.ContainsKey(filePath);
        }

        public virtual ITextBuffer GetEnvOpenedFile(string filePath)
        {
            filePath = NormalizeFilePath(filePath);
            return EnvOpenedFiles[filePath];
        }

        public virtual void RemoveEnvOpenedFile(string filePath)
        {
            filePath = NormalizeFilePath(filePath);
            if (!string.IsNullOrEmpty(filePath))
            {
                EnvOpenedFiles.Remove(filePath);
            }
        }

        protected virtual string NormalizeFilePath(string path)
        {
            return path.Replace(ProjectManager.SolutionDirectoryPath, string.Empty);
        }
    }
}