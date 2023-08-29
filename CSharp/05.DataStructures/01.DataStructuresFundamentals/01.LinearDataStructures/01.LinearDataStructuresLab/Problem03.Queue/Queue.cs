namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private class Node
        {
            public Node(T element)
                : this(element, null)
            {
                Next = null;
            }

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
                head = new Node(item);
            else
                head = new Node(item, head);
            
            Count++;
        }

        public T Dequeue()
        {
            if (Count == 0)
                throw new InvalidOperationException();

            T element = GetHeadElement(Count);

            Node currHead = head;

            Count--;
            for (int i = 1; i <= Count; i++)
            {
                if(i == Count)
                {
                    head.Next = null;
                    break;
                }

                head = head.Next;
            }

            head = currHead;
            return element;
        }

        public T Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException();

            return GetHeadElement(Count);
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
            for (int i = Count; i > 0; i--)
            {
                yield return GetHeadElement(i);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private T GetHeadElement(int position)
        {
            Node currHead = head;
        
            for (int i = 0; i < position - 1; i++)
            {
                currHead = currHead.Next;
            }

            return currHead.Element;
        }
    }
}