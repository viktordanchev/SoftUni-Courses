namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {
        private class Node
        {
            
        }

        private Node top;

        public int Count => throw new System.NotImplementedException();

        public void Push(T item)
        {
            throw new NotImplementedException();
        }

        public T Pop()
        {
            throw new System.NotImplementedException();
        }

        public T Peek()
        {
            throw new System.NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}