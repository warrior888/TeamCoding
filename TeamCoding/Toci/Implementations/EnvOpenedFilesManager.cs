using System.Collections.Generic;
using System.Threading;
using Microsoft.VisualStudio.Text;

namespace TeamCoding.Toci.Implementations
{
    public class EnvOpenedFilesManager
    {
        public static SynchronizationContext SynContext;
        protected Dictionary<string, ITextBuffer> EnvOpenedFiles = new Dictionary<string, ITextBuffer>();

        public virtual void AddOpenedFile(string filePath, ITextBuffer file)
        {
            if (SynContext == null && SynchronizationContext.Current != null)
            {
                SynContext = SynchronizationContext.Current;
            }

            filePath = ProjectManager.MakeRelativeFilePath(filePath);
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
            filePath = ProjectManager.MakeRelativeFilePath(filePath);
            return EnvOpenedFiles.ContainsKey(filePath);
        }

        public virtual ITextBuffer GetEnvOpenedFile(string filePath)
        {
            filePath = ProjectManager.MakeRelativeFilePath(filePath);
            return EnvOpenedFiles[filePath];
        }

        public virtual void RemoveEnvOpenedFile(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
            { 
                filePath = ProjectManager.MakeRelativeFilePath(filePath);          
                EnvOpenedFiles.Remove(filePath);
            }
        }
    }
}