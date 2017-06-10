namespace Toci.Piastcode.Social.Entities.Interfaces
{
    public interface IFrame : IData
    {
        IUser User { get; set; }

        IFile File { get; set; }

        IText Data { get; set; }
    }
}