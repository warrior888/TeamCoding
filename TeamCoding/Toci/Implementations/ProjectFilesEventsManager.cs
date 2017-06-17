using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EnvDTE;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Toci.Piastcode.Social.Client;
using Toci.Piastcode.Social.Client.Interfaces;
using Toci.Piastcode.Social.Sockets.Implementations;
using Toci.Piastcode.Social.Sockets.Interfaces;

namespace TeamCoding.Toci.Implementations
{
    public class ProjectFilesEventsManager
    {
        protected ProjectItemsEvents Events;
        protected BroadcastManager BCastManager;
        protected DTE Dte;
        

        public virtual void Register(EnvDTE.DTE dte)
        {
            Dte = dte;
            Events = dte.Events.GetObject("CSharpProjectItemsEvents") as ProjectItemsEvents;

            BCastManager = new BroadcastManager();

            Events.ItemAdded += Events_ItemAdded;
        }

        

        protected virtual void Events_ItemAdded(ProjectItem projectItem)
        {
            //projectItem.FileNames
            //ScManager.BroadCastFile(new global::Toci.Piastcode.Social.Client.Implementations.ProjectItem { Content = projectItem.Document.});
            BCastManager.Broadcast(GetItems(projectItem, ModificationType.Add));
        }

        protected virtual TcProjectItemsCollection GetItems(ProjectItem projectItem, ModificationType mdType)
        {
            string fullPath = projectItem.FileNames[0];
            string fileName = projectItem.FileNames[0].Replace(ProjectManager.SolutionDirectoryPath, string.Empty);

            string projectPath =
                projectItem.ContainingProject.FileName.Replace(ProjectManager.SolutionDirectoryPath, string.Empty);
            projectItem.ContainingProject.Save();


            TcProjectItemsCollection collection = new TcProjectItemsCollection();

            using (StreamReader sr = new StreamReader(fullPath))
            {
                TcEditedProjectItem item = new TcEditedProjectItem { FilePath = fileName, Content = sr.ReadToEnd(), ItemModificationType = mdType };

                collection.Add(item);
            }

            using (StreamReader sr = new StreamReader(projectItem.ContainingProject.FileName))
            {
                string relativeFileName = string.Join("\\", fileName.Split(new[] {"\\"}, StringSplitOptions.None).Skip(1));
                string template = $"<Compile Include=\"{relativeFileName}\" />";
                int templatePosition = sr.ReadToEnd().IndexOf(template);
                TcEditChanges edit = new TcEditChanges
                {
                    Text = template,
                    PositionStart = templatePosition,
                    OldPositionEnd = templatePosition ,//for adding
                };
                
                TcEditedProjectItem item = new TcEditedProjectItem
                {
                    FilePath = projectPath,
                    Content = sr.ReadToEnd(),
                    ItemModificationType = ModificationType.Edit,
                    EditChanges = new List<TcEditChanges> { edit },
                };

                collection.Add(item);
            }
            // Stare ale jare
            //using (StreamReader sr = new StreamReader(projectItem.ContainingProject.FileName))
            //{
            //    TcEditedProjectItem item = new TcEditedProjectItem { FilePath = projectPath, Content = sr.ReadToEnd(),
            //        ItemModificationType = ModificationType.Add };

            //    collection.Add(item);
            //}

            return collection;
        }

    }
}