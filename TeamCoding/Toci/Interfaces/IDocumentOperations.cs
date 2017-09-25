using TeamCoding.Documents;
using Toci.Piastcode.Social.Sockets.Interfaces;

namespace TeamCoding.Toci.Interfaces
{
    public interface IDocumentOperations
    {
        void EditItem(string filePath, IEditedProjectItem editedFile);
    }
}