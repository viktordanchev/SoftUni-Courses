using System.Collections.Generic;

namespace BoxOfT
{
    public class Box<T>
    {
        private int count;
        private List<T> list;

        public Box()
        {
            list = new List<T>();
        }

        public int Count { get { return count; } }

        public void Add(T element)
        {
            count++;
            list.Add(element);
        }

        public T Remove()
        {
            count--;
            T elementToRemove = list[list.Count - 1];
            list.Remove(elementToRemove);

            return elementToRemove;
        }
    }
}