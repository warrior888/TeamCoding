using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamCoding.Logging;
//using TeamCoding.VisualStudio.Models;

namespace Toci.TeamCoding.Tests.GKTests
{
    [TestClass]
 public class GKLoggerTest
    {
        [TestMethod]
        public void TestMyLogger()
        {
            GK_Logger logger = new GK_Logger();

            logger.WriteToFile();
            //Lazy(); //jak wyciągnąć uuid z Lazy ?
        }
    }
}
