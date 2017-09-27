using System;
using System.Net;
using System.Net.Sockets;
using Toci.Ptc.Users.Interfaces.Skeleton;

namespace Toci.Ptc.Users
{
    public class User : IUser
    {
        protected string MyGlobalIp;
        protected string MyLocalIp;
        protected string ServerUserName;
        protected string ClientUserIp;
        protected Socket Socket;

        public string LocalIp
        {
            get
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        MyLocalIp = ip.ToString();
                    }
                }

                return MyLocalIp;
            }
        }

        public Socket UserSocket
        {
            get
            {
                return Socket;
            }
        }

        public string Name
        {
            get
            {
                return Environment.UserDomainName;
            }

            set
            {
                ServerUserName = value;
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

        public void SetConnectionSocket(Socket socket)
        {
            Socket = socket;
        }

        public virtual void SetUserConnectionData(IUserDataEntity udEnt)
        {
            ServerUserName = udEnt.Name;
            ClientUserIp = udEnt.GlobalIp;
        }

        public IUserDataEntity Convert()
        {
            return new UserDataEntity
            {
                GlobalIp = MyGlobalIp,
                Name = ServerUserName
            };
        }
    }
}