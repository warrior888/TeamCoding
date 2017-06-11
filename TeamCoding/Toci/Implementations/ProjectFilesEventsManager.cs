using System;
using System.Collections.Generic;
using EnvDTE;
using Toci.Piastcode.Social.Client;
using Toci.Piastcode.Social.Client.Interfaces;
using Toci.Piastcode.Social.Sockets.Interfaces;

namespace TeamCoding.Toci.Implementations
{
    public class ProjectFilesEventsManager
    {
        protected ProjectItemsEvents Events;
        protected SocketClientManager ScManager;

        public ProjectFilesEventsManager()
        {
            ScManager = new SocketClientManager("127.0.0.1", 25016, null);
        }

        public void Register(EnvDTE.DTE dte)
        {
            Events = dte.Events.GetObject("CSharpProjectItemsEvents") as ProjectItemsEvents;

            Events.ItemAdded += Events_ItemAdded;
        }


        protected virtual void Events_ItemAdded(ProjectItem projectItem)
        {
            //projectItem.FileNames
            //ScManager.BroadCastFile(new global::Toci.Piastcode.Social.Client.Implementations.ProjectItem { Content = projectItem.Document.});
        }
    }
}