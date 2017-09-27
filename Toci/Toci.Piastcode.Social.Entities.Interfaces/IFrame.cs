namespace Toci.Piastcode.Social.Entities.Interfaces
{
    public interface IFrame : IData
    {

        IFile File { get; set; }

        IText Data { get; set; }
    }
}