using System;
using System.Net;
using System.Net.Sockets;
using Toci.Ptc.Users.Interfaces.Skeleton;

namespace Toci.Ptc.Users
{
    public class User : IUser
    {
        protected string MyGlobalIp;

        public string Name
        {
            get
            {
                return Environment.UserDomainName;
            }
        }

        public string GlobalIp
        {
            get
            {
                if (string.IsNullOrEmpty(MyGlobalIp))
                {
                    MyGlobalIp = new WebClient().DownloadString("http://icanhazip.com");
                }

                return MyGlobalIp; 
            }
        }
    }
}