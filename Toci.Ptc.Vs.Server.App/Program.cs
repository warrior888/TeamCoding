using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Ptc.Server;
using Toci.Ptc.Users;
using Toci.Ptc.Users.Interfaces.Skeleton;

namespace Toci.Ptc.Vs.Server.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"[{DateTime.Now}] Server started.");

            VisualStudioServer srv = new VisualStudioServer();
            srv.CreateSocket();

            IUser vsUSer = new VsUser();
            
            Task task = new Task(() => srv.AcceptConnection(vsUSer));
            task.Start();

            task.Wait();
        }
    }
}
