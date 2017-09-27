using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;
using Toci.Common.Extensions.Network;
using Toci.Piastcode.Social.Client.Interfaces;
using Toci.Piastcode.Social.Entities;
using Toci.Piastcode.Social.Entities.Interfaces;
using Toci.Piastcode.Social.Sockets;
using Toci.Piastcode.Social.Sockets.Implementations;
using Toci.Piastcode.Social.Sockets.Interfaces;
using Toci.Ptc.Broadcast;
using Toci.Ptc.Users;
using Toci.Ptc.Users.Interfaces.Skeleton;

namespace Toci.Piastcode.Social.Client
{
    public class SocketClientManager : VisualStudioBroadcast
    {
        protected Dictionary<ModificationType, Action<IItem>> Map;

        public SocketClientManager(string ipAddress, Dictionary<ModificationType, Action<IItem>> map) : base(ipAddress)
        {
            Map = map;
        }

        public void StartClient()
        {
            Task.Factory.StartNew(ListenForFrame);
        }

        public virtual void BroadCastFile(IItem projectItem)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Serializer.Serialize(ms, projectItem);
                //CoreUser.UserSocket.Send(ms.ToArray());
            }
        }

        protected IFrame ListenForFrame()
        {
            byte[] formatted = CoreUser.UserSocket.ReceiveFromSocket();

            IFrame frame = new Frame();

            frame = Serializer.Deserialize<IFrame>(new MemoryStream(formatted));
            return frame;
        }

        public override void CreateSocket(string serverIp)
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(serverIp), GetServer().ConnectionPort);
            Socket socket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(endPoint);

            IntroduceOneself(socket);

            return;
            try
            {
                socket.Connect(endPoint);
                
                using (MemoryStream ms = new MemoryStream())
                {
                    Serializer.Serialize(ms, CoreUser);
                    socket.Send(ms.ToArray());
                }

                CoreUser.SetConnectionSocket(socket);
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Couldn't connect to the server, exception: " + ex.Message);
            }
        }
    }
}