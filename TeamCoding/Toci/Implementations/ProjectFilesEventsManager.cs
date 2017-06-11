using EnvDTE;

namespace TeamCoding.Toci.Implementations
{
    public class ProjectFilesEventsManager
    {
        public void Register(EnvDTE.DTE dte)
        {
            ProjectItemsEvents events = dte.Events.GetObject("CSharpProjectItemsEvents") as ProjectItemsEvents;

            events.ItemAdded += Events_ItemAdded;
        }

        protected virtual void Events_ItemAdded(ProjectItem ProjectItem)
        {
            // broadcast
        }
    }
}