using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using Toci.Ptc.Environment.Interfaces;
using Toci.Ptc.Projects.Interfaces.Changes;
using Toci.Ptc.Server.Interfaces.Communication;
using Toci.Ptc.Users.Interfaces.Skeleton;

namespace Toci.Ptc.Server
{
    public abstract class Server : IServer<IChange<IEnvironment>, IEnvironment>
    {
        protected Socket Socket { get; set; }

        private string ipAddress;

        protected string IpAddress
        {
            get
            {
                if (string.IsNullOrEmpty(ipAddress))
                {
                    ipAddress = new WebClient().DownloadString("http://icanhazip.com").Trim();
                }

                return ipAddress;
            }
        }

        protected int Port { get; set; }

        protected Server(int port)
        {
            Port = port;
        }

        public abstract bool Send(IChange<IEnvironment> frame);

        public abstract IChange<IEnvironment> Receive();

        // protected virtual  ??

        public virtual void AcceptConnection(IUser user)
        {
            Socket.Listen(8);

            while (true)
            {
                Socket accepted = Socket.Accept();
                user.SetConnectionSocket(accepted);

                Task.Factory.StartNew(() => ListenForChanges(user));
            }
        }

        public virtual void CreateSocket()
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(IpAddress), Port);
            Socket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            Socket.Bind(endPoint);
        }

        protected virtual void ListenForChanges(IUser client)
        {
            while (true)
            {
                try
                {
                    byte[] buffer = new byte[client.UserSocket.SendBufferSize];
                    int bytesRead = client.UserSocket.Receive(buffer);

                    byte[] formatted = new byte[bytesRead];

                    for (int i = 0; i < bytesRead; i++)
                    {
                        formatted[i] = buffer[i];
                    }

                    //IItem item;

                    using (MemoryStream ms = new MemoryStream(formatted))
                    {
                        //item = Serializer.Deserialize<TcEditedProjectItem>(ms);

                        // Pseudo Logger 
                       // Map[item.ItemModificationType](item, client);
                    }

                    //BroadcastData(formatted, client);
                }
                catch (Exception ex)
                {
                    //Clients.Remove(client);
                    break;
                }
            }
        }
    }
}