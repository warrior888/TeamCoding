using ProtoBuf;
using Toci.Piastcode.Social.Client.Interfaces;

namespace Toci.Piastcode.Social.Sockets.Interfaces
{
    public interface IProjectItem : IItem
    {
        string ProjectPath { get; set; } //sln

        string FilePath { get; set; }

        string Content { get; set; }
    }
}