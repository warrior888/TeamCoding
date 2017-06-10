namespace Toci.Piastcode.Social.Entities.Interfaces
{
    public interface IProject : IData
    {
        string SourcePath { get; set; }
        
        string DestinationPath { get; set; }

        string[] FilePaths { get; set; }
    }
}