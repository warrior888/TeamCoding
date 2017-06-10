using System.Net.Sockets;
using Toci.Piastcode.Social.Entities.Interfaces;

namespace Toci.Piastcode.Social.Server.Interfaces
{
    public interface IClient
    {
        Socket socket { get; set; }

        IUser User { get; set; }
    }
}