using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.Shell;
using TeamCoding.Toci.Interfaces;
using Toci.Piastcode.Social.Client.Interfaces;
using Toci.Piastcode.Social.Sockets.Interfaces;
using Project = Microsoft.Build.Evaluation.Project;

namespace TeamCoding.Toci.Implementations
{
    public class ProjectFileManager : Package, IProjectFileManager
    {
        static Dictionary<string, Project> OpenProjectsMap = new Dictionary<string, Project>();

        public virtual void AddNewFile(IProjectItem projectItem, EnvDTE.DTE dte)
        {
            CreateAndFillWithContentFile(projectItem.FilePath, projectItem.Content);
            AddFileToProjest(projectItem.ProjectPath, projectItem.FilePath, dte);
        }

        protected virtual void AddFileToProjest(string projectPath, string filePath, EnvDTE.DTE dte)
        {
            projectPath = ProjectManager.SolutionDirectoryPath + projectPath;

            Project pr;
            if (OpenProjectsMap.ContainsKey(projectPath))
            {
                pr = OpenProjectsMap[projectPath];
            }
            else
            {
                pr = new Project(projectPath);
                OpenProjectsMap.Add(projectPath, pr);
            }

            pr.ReevaluateIfNecessary();
            pr.DisableMarkDirty = true;

            pr.AddItem("Compile", CalculateCsprojFileNameEntry(filePath));
            pr.Save();
            
            //dte.ItemOperations.AddExistingItem(filePath);
        }

        protected virtual void CreateAndFillWithContentFile(string filePath, string fileContent)
        {
            using (StreamWriter swr = new StreamWriter(ProjectManager.SolutionDirectoryPath + filePath))
            {
                swr.Write(fileContent);
                swr.Close();
            }
        }

        protected virtual string CalculateCsprojFileNameEntry(string filePath)
        {
            string[] chunks = filePath.Split(new[] {ProjectManager.PathDelimiter}, StringSplitOptions.None);
            return string.Join(ProjectManager.PathDelimiter, chunks.Skip(1).Take(chunks.Length - 1));
        }
    }
}
