namespace Hierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Collections;

    public class Hierarchy<T> : IHierarchy<T>
    {
        public Hierarchy(T value)
        {
            throw new NotImplementedException();
        }

        public int Count => throw new NotImplementedException();

        public void Add(T element, T child)
        {
            throw new NotImplementedException();
        }

        public bool Contains(T element)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetChildren(T element)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetCommonElements(Hierarchy<T> other)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public T GetParent(T element)
        {
            throw new NotImplementedException();
        }

        public void Remove(T element)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}