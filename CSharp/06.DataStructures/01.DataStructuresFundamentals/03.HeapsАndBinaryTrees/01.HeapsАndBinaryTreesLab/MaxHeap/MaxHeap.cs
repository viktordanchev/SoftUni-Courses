namespace _03.MaxHeap
{
    using System;
    using System.Reflection;

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

            Swap(0, --Size);
            T result = items[Size];
            items[Size] = default;

            HeapifyDown(0);
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

        private void HeapifyDown(int index)
        {
            int parentIndex = (index - 1) / 2;
            int biggerChild = GetBiggerChildIndex(parentIndex);

            while (items[parentIndex].CompareTo(items[biggerChild]) < 0)
            {
                Swap(parentIndex, biggerChild);
                parentIndex = biggerChild;

                if (parentIndex == Size)
                {
                    biggerChild = GetBiggerChildIndex(parentIndex);
                }
            }
        }

        private int GetBiggerChildIndex(int index)
        {
            int leftChildIndex = (2 * index) + 1;
            int rightChildIndex = (2 * index) + 2;

            if (items[leftChildIndex].CompareTo(items[rightChildIndex]) > 0)
            {
                return leftChildIndex;
            }

            return rightChildIndex;
        }

        private void Swap(int firstIndex, int secondIndex)
        {
            var temp = items[firstIndex];
            items[firstIndex] = items[secondIndex];
            items[secondIndex] = temp;
        }
    }
}
