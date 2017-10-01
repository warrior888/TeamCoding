using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Toci.Hack.Tc.Traininig.Reflection;

namespace Toci.SimpleTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ReflectionExample rEx = new ReflectionExample();

            //rEx.DerivingRypesExample<int>();

            MakeGenericMethodExample mgEx = new MakeGenericMethodExample();

            mgEx.MgMeShowdown("DerivingRypesExample");


        }
    }
}
