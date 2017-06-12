using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;
using Toci.Piastcode.Social.Client.Interfaces;
using Toci.Piastcode.Social.Entities;
using Toci.Piastcode.Social.Entities.Interfaces;
using Toci.Piastcode.Social.Sockets;
using Toci.Piastcode.Social.Sockets.Implementations;
using Toci.Piastcode.Social.Client.Implementations;
using Toci.Piastcode.Social.Sockets.Interfaces;

namespace Toci.Piastcode.Social.Client
{
    public class SocketClientManager : SocketClientBase
    {
        protected Dictionary<ModificationType, Action<IItem>> Map;

        public SocketClientManager(string ipAddress, int port, Dictionary<ModificationType, Action<IItem>> map) : base(ipAddress, port)
        {
            Map = map;
        }

        public void StartClient()
        {
            Task.Factory.StartNew(ListenForString);
        }


        protected void ListenForString()
        {
            while(true)
            { 
                byte[] buffer = new byte[socket.SendBufferSize];
                int bytesRead = socket.Receive(buffer);

                byte[] formatted = new byte[bytesRead];

                for (int i = 0; i < bytesRead; i++)
                {
                    formatted[i] = buffer[i];
                }

                IItem item;
                using (MemoryStream ms = new MemoryStream(formatted))
                {
                    item = Serializer.Deserialize<ProjectItem>(ms);


                    if (item.ItemModificationType == ModificationType.Add)
                    {
                        AddFile(Map[ModificationType.Add], (IProjectItem)item);
                    }
                }
            }
        }

        public virtual void BroadCastFile(IItem projectItem)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Serializer.Serialize(ms, projectItem);
                socket.Send(ms.ToArray());
            }
        }

        protected void Listen()
        {
            byte[] buffer = new byte[socket.SendBufferSize];
            int bytesRead = socket.Receive(buffer);

            byte[] formatted = new byte[bytesRead];

            for (int i = 0; i < bytesRead; i++)
            {
                formatted[i] = buffer[i];
            }

            IItem item;
            using (MemoryStream ms = new MemoryStream(formatted))
            {
                item = Serializer.Deserialize<IItem>(ms);


                if (item.ItemModificationType == ModificationType.Add)
                {
                    AddFile(Map[ModificationType.Add], (IProjectItem)item);
                }
            }
        }

        protected IFrame ListenForFrame()
        {
            byte[] buffer = new byte[socket.SendBufferSize];
            int bytesRead = socket.Receive(buffer);

            byte[] formatted = new byte[bytesRead];

            for (int i = 0; i < bytesRead; i++)
            {
                formatted[i] = buffer[i];
            }
            IFrame frame = new Frame();

            frame = Serializer.Deserialize<IFrame>(new MemoryStream(formatted));
            return frame;
        }

        public override void CreateSocket()
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(IpAddress), Port);
            socket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                socket.Connect(endPoint);
                string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                IUser user = new User
                {
                    Name = userName,
                };
                using (MemoryStream ms = new MemoryStream())
                {
                    Serializer.Serialize(ms, user);
                    socket.Send(ms.ToArray());
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Couldn't connect to the server, exception: " + ex);
            }
        }

        public void AddFile(Action<IProjectItem> action, IProjectItem projectItem)
        {
            action(projectItem);
        }
    }
}