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
    public abstract class Server : ServerBase
    {
        protected Server(int port) : base(port)
        {
        }
    }
}