using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Threading;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Text;
using TeamCoding.Toci.Interfaces;
using TeamCoding.VisualStudio;
using Toci.Piastcode.Social.Client.Interfaces;
using Toci.Piastcode.Social.Sockets.Interfaces;
using Project = Microsoft.Build.Evaluation.Project;

namespace TeamCoding.Toci.Implementations
{
    public class ProjectFileManager : Package, IProjectFileManager
    {
        static Dictionary<string, Project> OpenProjectsMap = new Dictionary<string, Project>();
        protected EnvOpenedFilesManager EnvironmentOpenedFilesManager;

        public ProjectFileManager()
        {
            EnvironmentOpenedFilesManager = TeamCodingPackage.Current.EnvironmentOpenedFilesManager;
        }

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

        protected virtual void UpdateFile(string filePath, IEditedProjectItem editedFile)
        {
            foreach (var editChange in editedFile.EditChanges)
            {
                TeamCodingTextViewConnectionListener.IsEditPending = true;
                //EnvironmentOpenedFilesManager.GetEnvOpenedFile(filePath).Insert(editChange.PositionStart, editChange.Text);
                EnvironmentOpenedFilesManager.GetEnvOpenedFile(filePath)
                    .Replace(new Span(editChange.PositionStart, editChange.OldPositionEnd - editChange.PositionStart), editChange.Text);
                TeamCodingTextViewConnectionListener.IsEditPending = false;
                //Dispatcher.CurrentDispatcher.Invoke(() => EnvironmentOpenedFilesManager.GetEnvOpenedFile(filePath).Insert(editChange.Position, editChange.Text));
            }
        }

        public virtual void EditItem(string filePath, IEditedProjectItem editedFile)
        {
            if (EnvironmentOpenedFilesManager.IsFileOpenedInEnv(filePath))
            {
                EnvOpenedFilesManager.SynContext.Post(new SendOrPostCallback(o => UpdateFile(filePath, editedFile)), null);

            }
            else
            {
                //string fileContent;
                try
                {
                    StreamReader stR = new StreamReader(ProjectManager.MakeAbsoluteFilePath(filePath));

                    StringBuilder sb = new StringBuilder(stR.ReadToEnd());
                    stR.Close();

                    foreach (var editChange in editedFile.EditChanges)
                    {
                        if (editChange.Text.Length < editChange.OldPositionEnd - editChange.PositionStart) //deletion
                            sb.Remove(editChange.PositionStart, editChange.OldPositionEnd - editChange.PositionStart);
                        sb.Insert(editChange.PositionStart, editChange.Text);

                    }

                    StreamWriter swR = new StreamWriter(ProjectManager.MakeAbsoluteFilePath(filePath));

                    swR.WriteLine(sb.ToString());
                    swR.Close();
                }
                catch (IOException ex)
                {

                }


            }
            //IWpfTextView 
            //ITextBuffer 
            //ITextView
        }

        protected virtual string CalculateCsprojFileNameEntry(string filePath)
        {
            string[] chunks = filePath.Split(new[] { ProjectManager.PathDelimiter }, StringSplitOptions.None);
            return string.Join(ProjectManager.PathDelimiter, chunks.Skip(1).Take(chunks.Length - 1));
        }
    }
}
