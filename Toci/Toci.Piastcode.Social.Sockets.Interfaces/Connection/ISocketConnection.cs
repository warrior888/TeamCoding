using System.Net.Sockets;

namespace Toci.Piastcode.Social.Sockets.Interfaces.Connection
{
    public interface ISocketConnection<TInput, TOutput>
    {
        void SendData(TInput data);

        TOutput ReceiveData();
    }
}