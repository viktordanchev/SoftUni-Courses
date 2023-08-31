namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
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

        private Node head;

        public int Count { get; private set; }

        public void Enqueue(T item)
        {
            if (Count == 0)
            {
                head = new Node(item, head);
            }
            else
            {
                Node currHead = head;

                while (currHead.Next != null)
                {
                    currHead = currHead.Next;
                }

                currHead.Next = new Node(item, null);
            }

            Count++;
        }

        public T Dequeue()
        {
            IsEmpty();

            T currElement = head.Element;
            head = head.Next;
            Count--;
            return currElement;
        }

        public T Peek()
        {
            IsEmpty();
            return head.Element;
        }

        public bool Contains(T item)
        {
            Node currHead = head;

            for (int i = 0; i < Count; i++)
            {
                if (currHead.Element.Equals(item))
                    return true;

                currHead = currHead.Next;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node currHead = head;

            for (int i = Count; i > 0; i--)
            {
                yield return currHead.Element;
                currHead = currHead.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void IsEmpty()
        {
            if (Count == 0)
                throw new InvalidOperationException();
        }
    }
}