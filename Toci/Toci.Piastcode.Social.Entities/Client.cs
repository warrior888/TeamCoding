using System.Net.Sockets;
using Toci.Piastcode.Social.Entities.Interfaces;

namespace Toci.Piastcode.Social.Entities
{
    public class Client : IClient
    {
        public string Name { get; set; }
        public int ClientID { get; set; }
        public Socket socket { get; set; }
    }
}