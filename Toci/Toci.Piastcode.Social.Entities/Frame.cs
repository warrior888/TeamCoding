using Toci.Piastcode.Social.Entities.Interfaces;

namespace Toci.Piastcode.Social.Entities
{
    public class Frame : IFrame
    {
        public IUser User { get; set; }
        public IFile File { get; set; }
        public IText Data { get; set; }
    }
}