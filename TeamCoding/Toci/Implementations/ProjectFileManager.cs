using System.Collections.Generic;
using System.IO;
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

        public void AddNewFile(IProjectItem projectItem, EnvDTE.DTE dte)
        {
            CreateAndFillWithContentFile(projectItem.FilePath, projectItem.Content);
            AddFileToProjest(projectItem.ProjectPath, projectItem.FilePath, dte);
        }

        private void AddFileToProjest(string projectPath, string filePath, EnvDTE.DTE dte)
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

            pr.AddItem("Compile", filePath);
            pr.Save();
            
            //dte.ItemOperations.AddExistingItem(filePath);
        }

        private void CreateAndFillWithContentFile(string filePath, string fileContent)
        {
            using (StreamWriter swr = new StreamWriter(ProjectManager.SolutionDirectoryPath + filePath))
            {
                swr.Write(fileContent);
                swr.Close();
            }
        }
    }
}
