using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace TeamCoding.Logging
{
    public class GK_Logger
    {

        public void WriteToFile()
        {
            System.Diagnostics.Debug.WriteLine("Windows user name: "+System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            IPHostEntry host;
            string localIp;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIp = ip.ToString();
                    System.Diagnostics.Debug.WriteLine("My local ip: "+localIp);
                }
            }

            /*
            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (StreamWriter outputFile) = new StreamWriter(mydocpath + @"\TeamCodingLog.log"))
            {
                outputFile.WriteLine("error");
            }
            */

        }
    }
}
