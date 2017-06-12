using ProtoBuf;
using Toci.Piastcode.Social.Client.Interfaces;

namespace Toci.Piastcode.Social.Sockets.Implementations
{
    [ProtoContract]
    public class ProjectItem : IProjectItem
    {
        private string _projectPath; //sln
        private string _filePath;
        private string _content;

        

        [ProtoMember(1)]
       public string ProjectPath
        {
            get
            {
                return _projectPath;
            }
            set
            {
                _projectPath = value;
            }
        }

        [ProtoMember(2)]
        public string FilePath
        {
            get
            {
                return _filePath;
            }
            set
            {
                _filePath = value;
            }
        }

        [ProtoMember(3)]
        public string Content
        {
            get
            {
                return _content;
            }
            set
            {
                _content = value;
            }
        }
        [ProtoMember(4)]
        public ModificationType ItemModificationType { get; set; }
    }
}
