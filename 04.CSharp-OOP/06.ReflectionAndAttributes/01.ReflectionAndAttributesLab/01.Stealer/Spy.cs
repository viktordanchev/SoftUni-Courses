using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fieldsNames)
        {
            Type type = Type.GetType(className);
            FieldInfo[] fieldsInfo = type.GetFields((BindingFlags)60);
            StringBuilder sb = new();

            Object obj = Activator.CreateInstance(type, new object[] { });

            sb.AppendLine($"Class under investigation: {className}");
            foreach (FieldInfo field in fieldsInfo.Where(f => fieldsNames.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(obj)}");
            }

            return sb.ToString().Trim();
        }
    }
}
