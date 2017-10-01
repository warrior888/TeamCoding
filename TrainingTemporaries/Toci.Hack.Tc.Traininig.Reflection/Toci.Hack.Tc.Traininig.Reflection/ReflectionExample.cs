
using System;
using System.Linq;
using System.Reflection;


namespace Toci.Hack.Tc.Traininig.Reflection
{
    public class ReflectionExample
    {
        public void DerivingRypesExample<TType>()
        {
            Type[] types = GetAssembly().GetTypes();

            //types.Where(t => t.IsSubclassOf(typeof(TType)));
        }

        protected virtual Assembly GetAssembly()
        {
            return Assembly.GetExecutingAssembly();
        }
    }
}
