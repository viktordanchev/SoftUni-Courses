namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {
        private class Node
        {
            public Node(T element, Node next)
            {
                Element = element;
                Next = next;
            }

            public T Element { get; set; }
            public Node Next { get; set; }
        }

        private Node top;

        public int Count { get; private set; }

        public void Push(T item)
        {
            top = new Node(item, top);
            Count++;
        }

        public T Pop()
        {
            if (Count == 0)
                throw new InvalidOperationException();

            T currElement = top.Element;
            top = top.Next;
            Count--;
            return currElement;
        }

        public T Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException();

            return top.Element;
        }

        public bool Contains(T item)
        {
            Node currTop = top;

            for (int i = 0; i < Count; i++)
            {
                if (currTop.Element.Equals(item))
                    return true;

                currTop = currTop.Next;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node currTop = top;

            for (int i = 0; i < Count; i++)
            {
                yield return currTop.Element;
                currTop = currTop.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}