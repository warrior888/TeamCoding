using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamCoding.Logging;

namespace Toci.TeamCoding.Tests.TeamCodingProj.Loggers
{
    [TestClass]
    public class BasicLoggerTest
    {
        [TestMethod]
        public void BasicLoggerBasicTest()
        {
            Logger logger = new Logger();

            //Logger log = new Logger();

            logger.OurTest("Hello toci");
        }
    }
}
