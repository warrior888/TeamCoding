using System.IO;
using System.Net.Sockets;
using ProtoBuf;
using Toci.Piastcode.Social.Entities;
using Toci.Piastcode.Social.Entities.Interfaces;

namespace Toci.Piastcode.Social.Sockets.Connection
{
    public class SocketFrameConnection : SocketConnection<byte[], IFrame>
    {
        public SocketFrameConnection(Socket socket) : base(socket)
        {
        }

        public override void SendData(byte[] data)
        {
            socket.Send(data);
        }

        public override IFrame ReceiveData()
        {
            IFrame frame = new Frame();

            byte[] buffer = new byte[socket.SendBufferSize];
            int bytesRead = socket.Receive(buffer);

            byte[] formatted = new byte[bytesRead];

            for (int i = 0; i < bytesRead; i++)
            {
                formatted[i] = buffer[i];
            }

            MemoryStream ms = new MemoryStream(formatted);

            frame = Serializer.Deserialize<Frame>(ms);

            return frame;
        }
    }
}