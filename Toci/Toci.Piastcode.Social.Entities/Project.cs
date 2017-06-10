using ProtoBuf;
using Toci.Piastcode.Social.Entities.Interfaces;

namespace Toci.Piastcode.Social.Entities
{
    [ProtoContract]
    public class Project : IProject
    {
        [ProtoMember(1)]
        public string SourcePath { get; set; }

        [ProtoMember(2)]
        public string DestinationPath { get; set; }

        [ProtoMember(3)]
        public string[] FilePaths { get; set; }
    }
}