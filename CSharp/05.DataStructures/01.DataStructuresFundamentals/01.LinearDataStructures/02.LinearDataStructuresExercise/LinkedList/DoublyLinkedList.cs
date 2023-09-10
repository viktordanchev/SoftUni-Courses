namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Xml.Linq;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private class Node
        {
            public Node(T element)
            {
                Element = element;
            }

            public T Element { get; set; }
            public Node Next { get; set; }
            public Node Previous { get; set; }
        }

        private Node head;
        private Node tail;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var node = new Node(item);

            if(Count == 0)
            {
                head = node;
                tail = node;
            }
            else
            {
                head.Previous = node;
                node.Next = head;
                head = node;
            }

            Count++;
        }

        public void AddLast(T item)
        {
            var node = new Node(item);

            if (Count == 0)
            {
                head = node;
                tail = node;
            }
            else
            {
                tail.Next = node;
                node.Previous = tail;
                tail = node;
            }

            Count++;
        }

        public T GetFirst()
        {
            IsEmpty();
            return head.Element;
        }

        public T GetLast()
        {
            IsEmpty();
            return tail.Element;
        }

        public T RemoveFirst()
        {
            IsEmpty();

            T currElement = head.Element;
            head = head.Next;
            Count--;
            return currElement;
        }

        public T RemoveLast()
        {
            IsEmpty();

            T currElement = tail.Element;
            tail = tail.Previous;
            Count--;
            return currElement;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node currHead = head;

            for (int i = 0; i < Count; i++)
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