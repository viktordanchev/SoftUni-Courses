using System;

namespace _05.GenericCountMethodString
{
    public class Box<T> where T : IComparable<T>
    {
        public T BoxValue { get; set; }
    }
}