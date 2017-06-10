using System.IO;
using System.Net.Sockets;
using ProtoBuf;
using Toci.Piastcode.Social.Entities;
using Toci.Piastcode.Social.Entities.Interfaces;

namespace Toci.Piastcode.Social.Sockets.Connection
{
    public class SocketUserConnection : SocketConnection<byte[], IUser>
    {
        public SocketUserConnection(Socket socket) : base(socket)
        {
        }

        public override void SendData(byte[] data)
        {
            socket.Send(data);
        }

        public override IUser ReceiveData()
        {
            IUser user = new User();

            byte[] buffer = new byte[socket.SendBufferSize];
            int bytesRead = socket.Receive(buffer);

            byte[] formatted = new byte[bytesRead];

            for (int i = 0; i < bytesRead; i++)
            {
                formatted[i] = buffer[i];
            }

            MemoryStream ms = new MemoryStream(formatted);

            user = Serializer.Deserialize<User>(ms);

            return user;
        }
    }
}