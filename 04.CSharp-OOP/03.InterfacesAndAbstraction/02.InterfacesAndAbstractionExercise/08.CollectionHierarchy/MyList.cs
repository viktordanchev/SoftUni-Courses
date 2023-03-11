using CollectionHierarchy.Interfaces;
using System.Collections.Generic;

namespace CollectionHierarchy
{
    public class MyList<T> : IAddable<T>, IRemoveable<T>
    {
        private List<T> list;

        public MyList()
        {
            list = new List<T>();
        }

        public int Used => list.Count;

        public int Add(T item)
        {
            list.Insert(0, item);

            return 0;
        }

        public T Remove()
        {
            T item = list[0];

            list.RemoveAt(0);

            return item;
        }
    }
}
