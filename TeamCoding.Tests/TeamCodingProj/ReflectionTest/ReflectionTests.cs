using System.Reflection;
using TeamCoding.VisualStudio.TextAdornment;
using Toci.TeamCoding.Tests.TeamCodingProj.Loggers;

namespace Toci.TeamCoding.Tests.TeamCodingProj.ReflectionTest
{
    public class ReflectionTests
    {
        public void Test()
        {
            //TextAdornment txtAdr = new TextAdornment(null);
            BasicLoggerTest test = new BasicLoggerTest();

            PropertyInfo propInfo = test.GetType().GetProperty("IAmPrivate", BindingFlags.Instance | BindingFlags.NonPublic);

            propInfo.GetValue(test);
        }
    }
}