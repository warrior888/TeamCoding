using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.Piastcode.Social.Server;
using Toci.Piastcode.SpeechRecognition.Tools;

namespace Toci.VoiceRecognition.Poc
{
    class Program
    {
        static void Main(string[] args)
        {
            SpeechRecognitionManager srManagewr = new SpeechRecognitionManager();
            //srManagewr.ManageVoiceInstructions(test);

            SocketServerManager server = new SocketServerManager("127.0.0.1", 25016);
            server.StartServer();

            Console.ReadLine();
        }

        static void test(string speech)
        {
            
        }
}
}
