namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http.Headers;
    using System.Reflection;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DefaultCapacity = 4;

        private T[] items;

        public ReversedList()
            : this(DefaultCapacity) { }

        public ReversedList(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            this.items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                ValidateIndex(index);
                return items[Count - 1 - index];
            }
            set
            {
                ValidateIndex(index);
                items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            if (items.Length == Count)
                items = Grow();

            items[Count++] = item;
        }

        public bool Contains(T item)
        {
            if (Count == 0)
                return false;

            return items.Contains(item);
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[Count - 1 - i].Equals(item))
                    return i;
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            ValidateIndex(index);

            if (items.Length == Count)
                items = Grow();

            index = Count - index;
            for (int i = Count - 1; i >= index; i--)
            {
                items[i + 1] = items[i];
            }

            items[index] = item;
            Count++;
        }

        public bool Remove(T item)
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                if (items[i].Equals(item))
                {
                    RemoveAtCurrentIndex(i);
                    Count--;
                    return true;
                }
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index);

            index = Count - 1 - index;
            RemoveAtCurrentIndex(index);
            Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException(nameof(index));
        }

        private T[] Grow()
        {
            T[] copy = new T[items.Length * 2];
            Array.Copy(items, copy, items.Length);
            return copy;
        }

        private void RemoveAtCurrentIndex(int index)
        {
            ValidateIndex(index);

            int currIndex = 0;
            items = items.Where(i => currIndex++ != index).ToArray();
        }
    }
}