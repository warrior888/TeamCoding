using ProtoBuf;

namespace Toci.Piastcode.Social.Client.Interfaces
{
    [ProtoContract]
    public interface IProjectItem : IItem
    {
        [ProtoMember(1)]
        string ProjectPath { get; set; } //sln

        [ProtoMember(2)]
        string FilePath { get; set; }

        [ProtoMember(3)]
        string Content { get; set; }
    }
}