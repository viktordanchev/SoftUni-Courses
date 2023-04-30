using System;

namespace _06.GenericCountMethodDouble
{
    internal class Box<T> where T : IComparable<T>
    {
        public T BoxValue { get; set; }
    }
}