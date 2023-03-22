using System;

namespace AuthorProblem
{
    [AttributeUsage((AttributeTargets)68, AllowMultiple = true)]
    public class AuthorAttribute : Attribute
    {
        public AuthorAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}