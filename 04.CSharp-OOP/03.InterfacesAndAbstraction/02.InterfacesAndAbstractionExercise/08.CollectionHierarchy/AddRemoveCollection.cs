using CollectionHierarchy.Interfaces;
using System.Collections.Generic;

namespace CollectionHierarchy
{
    public class AddRemoveCollection<T> : IAddable<T>, IRemoveable<T>
    {
        private List<T> list;

        public AddRemoveCollection()
        {
            list = new List<T>();
        }

        public int Add(T item)
        {
            list.Insert(0, item);

            return 0;
        }

        public T Remove()
        {
            T item = list[list.Count - 1];

            list.RemoveAt(list.Count - 1);

            return item;
        }
    }
}
