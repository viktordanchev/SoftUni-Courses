using System;
using System.Collections.Generic;

namespace _03.MinHeap
{
    public class MinHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        protected List<T> elements;

        public MinHeap()
        {
            this.elements = new List<T>();
        }

        public int Count { get { return elements.Count; } }

        public void Add(T element)
        {
            elements.Add(element);
            HeapifyUp(Count - 1);
        }

        public T ExtractMin()
        {
            if (elements.Count == 0)
            {
                throw new InvalidOperationException();
            }

            Swap(0, Count - 1);
            T result = elements[Count - 1];
            elements.RemoveAt(Count - 1);

            if (elements.Count > 1)
            {
                HeapifyDown(0);
            }

            return result;
        }

        public T Peek()
        {
            if (elements.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return elements[0];
        }

        private void HeapifyUp(int index)
        {
            int parentIndex = (index - 1) / 2;
            while (index > 0 && elements[index].CompareTo(elements[parentIndex]) < 0)
            {
                Swap(index, parentIndex);
                index = parentIndex;
                parentIndex = (index - 1) / 2;
            }
        }

        private void HeapifyDown(int index)
        {
            int smallerChild = GetSmallerChildIndex(index);

            while (elements[index].CompareTo(elements[smallerChild]) > 0)
            {
                Swap(index, smallerChild);
                index = smallerChild;

                if (index != Count - 1)
                {
                    smallerChild = GetSmallerChildIndex(index);
                }
            }
        }

        private void Swap(int firstIndex, int secondIndex)
        {
            var temp = elements[firstIndex];
            elements[firstIndex] = elements[secondIndex];
            elements[secondIndex] = temp;
        }

        private int GetSmallerChildIndex(int index)
        {
            int leftChildIndex = (2 * index) + 1;
            int rightChildIndex = (2 * index) + 2;

            if (Count == 2)
            {
                return leftChildIndex;
            }
            else if(rightChildIndex == Count - 1)
            {
                return leftChildIndex;
            }
            else if (rightChildIndex > Count - 1)
            {
                return index;
            }

            if (elements[leftChildIndex].CompareTo(elements[rightChildIndex]) < 0)
            {
                return leftChildIndex;
            }

            return rightChildIndex;
        }
    }
}
