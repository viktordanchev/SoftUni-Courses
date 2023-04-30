using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string CollectGettersAndSetters(string className)
        {
            Type type = Type.GetType(className);
            MethodInfo[] methods = type.GetMethods((BindingFlags)54);
            StringBuilder sb = new StringBuilder();

            foreach (var method in methods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            }
            foreach (var method in methods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} will set field of {method.ReturnType}");
            }

            return sb.ToString().Trim();
        }
    }
}
