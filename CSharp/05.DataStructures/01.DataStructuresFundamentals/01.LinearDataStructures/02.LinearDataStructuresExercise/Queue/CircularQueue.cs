namespace Problem01.CircularQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CircularQueue<T> : IAbstractQueue<T>
    {
        private const int DefaultCapacity = 4;
        private T[] items;
        private int firstItemIndex;
        private int lastItemIndex;

        public CircularQueue()
            : this(DefaultCapacity)
        {
        }

        public CircularQueue(int capacity)
        {
            items = new T[capacity];
        }

        public int Count { get; private set; }

        public void Enqueue(T item)
        {
            if (Count == items.Length)
            {
                T[] newArray = new T[Count * 2];
                Array.Copy(items, newArray, Count);
                items = newArray;
                firstItemIndex = 0;
                lastItemIndex = Count;
            }

            items[lastItemIndex] = item;
            lastItemIndex = (lastItemIndex + 1) % items.Length;
            Count++;
        }

        public T Dequeue()
        {
            IsEmpty();

            T currItem = items[firstItemIndex];

            items[firstItemIndex] = default;
            firstItemIndex = (firstItemIndex + 1) % items.Length;
            Count--;

            return currItem;
        }

        public T Peek()
        {
            IsEmpty();
            return items[firstItemIndex];
        }

        public T[] ToArray()
        {
            T[] result = new T[Count];

            for (int i = 0; i < Count; i++)
            {
                int index = (firstItemIndex + i) % items.Length;
                result[i] = items[index];
            }

            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                int index = (firstItemIndex + i) % items.Length;
                yield return items[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void IsEmpty()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
