using System;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string AnalyzeAccessModifiers(string className)
        {
            Type type = Type.GetType(className);
            FieldInfo[] fieldsInfo = type.GetFields((BindingFlags)60);
            PropertyInfo[] propertiesInfo = type.GetProperties((BindingFlags)60);
            StringBuilder sb = new StringBuilder();

            foreach (FieldInfo field in fieldsInfo) 
            {
                if (!field.IsPrivate)
                    sb.AppendLine($"{field.Name} must be private!");
            }
            foreach (PropertyInfo property in propertiesInfo)
            {
                if (!property.GetMethod.IsPublic)
                    sb.AppendLine($"{property.GetMethod.Name} have to be public!");
            }
            foreach(PropertyInfo property in propertiesInfo)
            {
                if (property.SetMethod.IsPublic)
                    sb.AppendLine($"{property.SetMethod.Name} have to be private!");
            }
        
            return sb.ToString().Trim();
        }
    }
}
