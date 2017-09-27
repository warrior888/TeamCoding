using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;
using Toci.Common.Extensions.Network;
using Toci.Piastcode.Social.Client.Interfaces;
using Toci.Piastcode.Social.Entities;
using Toci.Piastcode.Social.Entities.Interfaces;
using Toci.Piastcode.Social.Sockets;
using Toci.Piastcode.Social.Sockets.Connection;
using Toci.Piastcode.Social.Sockets.Implementations;
using Toci.Piastcode.Social.Sockets.Interfaces;
using Toci.Ptc.Users.Interfaces.Skeleton;

namespace Toci.Piastcode.Social.Server
{
    public class SocketServerManager : SocketServerBase
    {
        public static object LockObject = new object();

        protected List<IUser> Clients;
    }
}