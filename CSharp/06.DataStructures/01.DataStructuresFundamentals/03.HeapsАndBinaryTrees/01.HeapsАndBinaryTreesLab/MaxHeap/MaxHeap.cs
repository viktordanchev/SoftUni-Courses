namespace _03.MaxHeap
{
    using System;

    public class MaxHeap<T> : IAbstractHeap<T> where T : IComparable<T>
    {
        private T[] items;

        public MaxHeap()
        {
            items = new T[4];
        }

        public int Size { get; private set; }

        public void Add(T element)
        {
            if (Size == items.Length)
            {
                items = Resize();
            }

            items[Size] = element;
            HeapifyUp(Size++);
        }

        public T ExtractMax()
        {
            if (Size == 0)
            {
                throw new InvalidOperationException();
            }

            T result = items[0];

            for (int i = 0; i < Size; i++)
            {
                Swap(i, i + 1);
            }

            return result;
        }

        public T Peek()
        {
            if (Size == 0)
            {
                throw new InvalidOperationException();
            }

            return items[0];
        }

        private T[] Resize()
        {
            T[] array = new T[items.Length * 2];
            Array.Copy(items, array, items.Length);

            return array;
        }

        private void HeapifyUp(int index)
        {
            int parentIndex = (index - 1) / 2;
            while (index > 0 && items[index].CompareTo(items[parentIndex]) > 0)
            {
                Swap(index, parentIndex);
                index = parentIndex;
                parentIndex = (index - 1) / 2;
            }
        }

        private void Swap(int firstIndex,  int secondIndex)
        {
            var temp = items[firstIndex];
            items[firstIndex] = items[secondIndex];
            items[secondIndex] = temp;
        }
    }
}
