using System.Net.Sockets;

namespace Toci.Piastcode.Social.Entities.Interfaces
{
    public interface IClient
    {
        string Name { get; set; }
        Socket socket { get; set; }
    }
}