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
using Toci.Ptc.Broadcast;


namespace Toci.Piastcode.Social.Client
{
    public abstract class SocketClientManager : VisualStudioBroadcast
    {
        protected Socket Socket;

        protected SocketClientManager(string ipAddress) : base(ipAddress)
        {

        }

        public void StartClient()
        {
            Task.Factory.StartNew(ListenForFrame);
        }

        public virtual void BroadcastChange(IItem projectItem)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Serializer.Serialize(ms, projectItem);
                CoreUser.UserSocket.Send(ms.ToArray()); 
            }
        }

        protected IFrame ListenForFrame()
        {
            byte[] formatted = CoreUser.UserSocket.ReceiveFromSocket();

            //IFrame frame = new Frame();

            //frame = Serializer.Deserialize<IFrame>(new MemoryStream(formatted));
            return null;
        }

        public override void CreateSocket(string serverIp)
        {
            // TODOD rem,ove dirty if once fixed architecture
            if (string.IsNullOrEmpty(serverIp))
            {
                serverIp = "54.36.98.229";
            }

            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(serverIp), GetServer().ConnectionPort);
            Socket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            Socket.Connect(endPoint);

            IntroduceOneself(Socket);
        }
    }
}