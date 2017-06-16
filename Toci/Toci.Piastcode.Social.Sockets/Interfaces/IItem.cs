using ProtoBuf;
using Toci.Piastcode.Social.Sockets.Interfaces;

namespace Toci.Piastcode.Social.Client.Interfaces
{
    public interface IItem
    {
        ModificationType ItemModificationType { get; set; }
    }
}