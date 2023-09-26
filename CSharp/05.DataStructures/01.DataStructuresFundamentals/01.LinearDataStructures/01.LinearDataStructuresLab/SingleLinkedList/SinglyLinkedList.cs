namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
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

        private Node node;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            node = new Node(item, node);
            Count++;
        }

        public void AddLast(T item)
        {
            if(Count == 0)
            {
                node = new Node(item, node);
            }
            else
            {
                Node currNode = node;

                while (currNode.Next != null)
                {
                    currNode = currNode.Next;
                }

                currNode.Next = new Node(item, null);
            }

            Count++;
        }

        public T GetFirst()
        {
            IsEmpty();
            return node.Element;
        }

        public T GetLast()
        {
            IsEmpty();
            return GetFirstElement(Count);
        }

        public T RemoveFirst()
        {
            IsEmpty();

            T currElement = node.Element;
            node = node.Next;
            Count--;
            return currElement;
        }

        public T RemoveLast()
        {
            IsEmpty();

            T element = GetFirstElement(Count);
            Node currNode = node;

            Count--;
            for (int i = 0; i < Count; i++)
            {
                currNode = currNode.Next;
            }

            currNode.Next = null;

            return element;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node currNode = node;

            for (int i = 0; i < Count; i++)
            {
                yield return currNode.Element;
                currNode = currNode.Next;
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

        private T GetFirstElement(int position)
        {
            Node currNode = node;

            for (int i = 0; i < position - 1; i++)
            {
                currNode = currNode.Next;
            }

            return currNode.Element;
        }
    }
}