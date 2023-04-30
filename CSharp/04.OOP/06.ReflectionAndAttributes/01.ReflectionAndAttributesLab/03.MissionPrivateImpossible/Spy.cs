using System;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string RevealPrivateMethods(string className)
        {
            Type type = Type.GetType(className);
            MethodInfo[] privateMethods = type.GetMethods((BindingFlags)36);
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"All Private Methods of Class: {type.FullName}");
            sb.AppendLine($"Base Class: {type.BaseType.Name}");

            foreach (var method in privateMethods)
            {
                sb.AppendLine(method.Name);
            }

            return sb.ToString().Trim();
        }
    }
}
