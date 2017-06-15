using System;
using System.Collections.Generic;
using System.IO;
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

            TcProjectItemsCollection collection = new TcProjectItemsCollection();

            using (StreamReader sr = new StreamReader(fullPath))
            {
                TcProjectItem item = new TcProjectItem {FilePath = fileName, Content = sr.ReadToEnd(), ItemModificationType = mdType, ProjectPath = projectItem.ContainingProject.FileName.Replace(ProjectManager.SolutionDirectoryPath, string.Empty) };
                collection.Add(item);
            }

            return collection;
        }

    }
}