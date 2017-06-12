using System;
using System.Collections.Generic;
using System.IO;
using EnvDTE;
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

        public void Register(EnvDTE.DTE dte)
        {
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
            string fileName = projectItem.FileNames[0];
            TcProjectItemsCollection collection = new TcProjectItemsCollection();

            using (StreamReader sr = new StreamReader(fileName))
            {
                TcProjectItem item = new TcProjectItem {FilePath = fileName, Content = sr.ReadToEnd(), ItemModificationType = mdType, ProjectPath = projectItem.ContainingProject.FileName };
                collection.Add(item);
            }

            return collection;
        }
    }
}