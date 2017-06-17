using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Toci.TeamCoding.Tests.TeamCoding.Tests
{
    [TestClass]
    public class FileManipulationTests
    {
        [TestMethod]
        public void test()
        {
            string file = @"C:\Users\bzapart\Documents\TeamCoding\TeamCoding.Tests\Toci.TeamCoding.Tests.csproj";
            using (StreamWriter swr = new StreamWriter(file))
            {
                
            }
        }
    }

    
}
