namespace Toci.Piastcode.Social.Entities.Interfaces
{
    public interface IProjectItem
    {
        string ProjectPath { get; set; } //sln

        string FilePath { get; set; }

        string Content { get; set; }
    }
}