using Toci.Piastcode.Social.Client.Interfaces;

namespace TeamCoding.Toci.Interfaces
{
    public interface IProjectFileManager
    {
        void AddNewFile(IProjectItem projectItem, EnvDTE.DTE dte);
    }
}