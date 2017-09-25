using TeamCoding.Toci.Interfaces;
using Toci.Piastcode.Social.Sockets.Interfaces;

namespace TeamCoding.Toci.Implementations.Pentagram
{
    public abstract class ProjectDocumentBase : IDocumentOperations
    {
        public abstract void EditItem(string filePath, IEditedProjectItem editedFile);
    }
}