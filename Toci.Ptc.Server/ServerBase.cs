using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
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
    public abstract class ServerBase<TChange, TEnvironment> : IServer<TChange, TEnvironment>
    {
        public static object LockObject = new object();

        protected List<IUser> Clients = new List<IUser>();

        protected static Socket UserSocket // fucking bullshit
        {
            get;
            set;
        }

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

        protected abstract IUser CreateUser(IUserDataEntity udEnt);

        public virtual void AcceptConnection()
        {
            UserSocket.Listen(8);

            while (true)
            {
                Socket accepted = UserSocket.Accept();

                IUser user = CreateUser(accepted);

                Clients.Add(user);

                Task.Factory.StartNew(() => ListenForChanges(user));
            }
        }

        protected virtual IUser CreateUser(Socket socket)
        {
            byte[] formatted = socket.ReceiveFromSocket();
            MemoryStream ms = new MemoryStream(formatted);

            IUserDataEntity tuser = Serializer.Deserialize<UserDataEntity>(ms);

            Console.WriteLine("Connected user: " + tuser.Name);

            IUser user = CreateUser(tuser);

            user.SetConnectionSocket(socket);
            GetSocket(socket);
            //UserSocket = socket;

            return user;
        }

        public abstract bool Send(TChange frame);

        public abstract TChange Receive();

        public virtual void CreateSocket()
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(IpAddress), Port);
            UserSocket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            UserSocket.Bind(endPoint);
        }

        public void GetSocket(Socket socket)
        {
            UserSocket = socket;
        }

        public int ConnectionPort
        {
            get
            {
                return Port;
            }
        }

        public void Connect(string serverIp)
        {
           
        }

        protected virtual void ListenForChanges(IUser client)
        {
            while (true)
            {
                try
                {
                    byte[] formatted = client.UserSocket.ReceiveFromSocket();

                    string temp = Encoding.ASCII.GetString(formatted);
                    Debug.WriteLine(client.Name + " says: " + temp);

                    BroadcastData(formatted, client);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    Clients.Remove(client);
                    break;
                }
            }
        }

        protected virtual void BroadcastData(byte[] data, IUser filteredClient = null)
        {
            lock (LockObject)
            {
                foreach (var client in Clients)
                {
                    if (filteredClient != null && filteredClient.Name == client.Name)
                    {
                        continue;
                    }
                    //byte[] name = Encoding.ASCII.GetBytes(client.Name + ": ");

                    client.UserSocket.Send(data);
                }
            }
        }
    }
}