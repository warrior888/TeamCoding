using System.Net.Sockets;

namespace Toci.Common.Extensions.Network
{
    public static class NetworkExtensions
    {
        public static byte[] ReceiveFromSocket(this Socket socket)
        {
            byte[] buffer = new byte[socket.SendBufferSize];
            int bytesRead = socket.Receive(buffer);

            byte[] formatted = new byte[bytesRead];

            for (int i = 0; i < bytesRead; i++)
            {
                formatted[i] = buffer[i];
            }

            return formatted;
        }
    }
}