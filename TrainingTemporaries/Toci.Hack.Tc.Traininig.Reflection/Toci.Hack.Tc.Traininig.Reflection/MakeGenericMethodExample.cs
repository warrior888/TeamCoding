using System.Reflection;

namespace Toci.Hack.Tc.Traininig.Reflection
{
    public class MakeGenericMethodExample
    {
        public void MgMeShowdown(string methodToInvokeName)
        {
            ReflectionExample re = new ReflectionExample();

            MethodInfo[] meIenum = re.GetType().GetMethods();

            foreach (var meIenumItem in meIenum)
            {
                if (meIenumItem.Name == methodToInvokeName)
                {
                    //meIenumItem.MakeGenericMethod()
                }
            }
        }
    }
}