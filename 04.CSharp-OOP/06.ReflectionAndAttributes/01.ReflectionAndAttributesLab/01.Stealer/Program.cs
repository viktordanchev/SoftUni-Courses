using System;
using System.Reflection;

namespace _01.Stealer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(Da);

            ConstructorInfo[] constructors = type.GetConstructors();

            foreach (ConstructorInfo constructor in constructors)
            {
                ParameterInfo[] parameters = constructor.GetParameters();

                object[] values = new object[parameters.Length];

                int index = 0;
                foreach (ParameterInfo value in parameters)
                {
                    values[index++] = GetDefault(value.ParameterType);
                }

                Da da = Activator.CreateInstance(type, values) as Da;
            }
        }

        static object GetDefault(Type type)
        {
            if (type.IsValueType)
                return Activator.CreateInstance(type);

            return null;
        }
    }

    class Da
    {
        private int id;
        private int age;

        public Da(int id, int age)
        {
            Id = id;
            Age = age;
        }

        public int Id { get => 1; set { id = value; } }
        public int Age { get => 5; set { age = value; } }
    }
}
