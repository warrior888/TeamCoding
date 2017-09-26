using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using ProtoBuf;
using Toci.Common.Extensions.Network;
using Toci.Ptc.Environment.Interfaces;
using Toci.Ptc.Projects.Interfaces.Changes;
using Toci.Ptc.Server.Interfaces.Communication;
using Toci.Ptc.Users;
using Toci.Ptc.Users.Interfaces.Skeleton;

namespace Toci.Ptc.Server
{
    public abstract class ServerBase : IServer<IChange<IEnvironment>, IEnvironment>
    {
        protected Socket Socket { get; set; }

        private string ipAddress;

        protected virtual string IpAddress
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

        protected ServerBase(int port)
        {
            Port = port;
        }

        public abstract bool Send(IChange<IEnvironment> frame);

        public abstract IChange<IEnvironment> Receive();

        protected abstract IUser CreateUser(IUserDataEntity udEnt);

        public virtual void AcceptConnection()
        {
            Socket.Listen(8);

            while (true)
            {
                Socket accepted = Socket.Accept();

                Task.Factory.StartNew(() => ListenForChanges(CreateUser(accepted)));
            }
        }

        protected virtual IUser CreateUser(Socket socket)
        {
            byte[] formatted = socket.ReceiveFromSocket();
            MemoryStream ms = new MemoryStream(formatted);

            IUserDataEntity tuser = Serializer.Deserialize<IUserDataEntity>(ms);

            IUser user = CreateUser(tuser);

            user.SetConnectionSocket(socket);

            return user;
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
                    byte[] formatted = client.UserSocket.ReceiveFromSocket();

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
                    Debug.WriteLine(ex.Message);
                    //Clients.Remove(client);
                    break;
                }
            }
        }

    }
}