using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace TeamCoding.Logging
{
    public sealed class FileLogger : ILogger
    {
        private static FileLogger _fileLogger = null;
        private StreamWriter _sw;
        public static FileLogger FileLoggerInstance => _fileLogger ?? (_fileLogger = new FileLogger());
        

        public void CreateLogFile(string filePath)
        {
            _sw = new StreamWriter(filePath);
        }

        public void WriteError(string error, Exception ex = null, string filePath = null, string memberName = null)
        {
            throw new NotImplementedException();
        }

        public void WriteError(Exception ex, string filePath = null, string memberName = null)
        {
            throw new NotImplementedException();
        }

        public void WriteInformation(string info, string filePath = null, string memberName = null)
        {
            
        }
    }
}
