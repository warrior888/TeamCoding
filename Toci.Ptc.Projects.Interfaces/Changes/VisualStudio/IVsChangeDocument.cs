using Microsoft.VisualStudio.Text.Projection;
using Toci.Piastcode.Social.Entities.Interfaces;

namespace Toci.Ptc.Projects.Interfaces.Changes.VisualStudio
{
    public interface IVsChangeDocument<in TDocument> : IVsChange
        where TDocument : IProjectItem
    {
        void Change(TDocument projectItem, EnvDTE.DTE dte);
    }
}