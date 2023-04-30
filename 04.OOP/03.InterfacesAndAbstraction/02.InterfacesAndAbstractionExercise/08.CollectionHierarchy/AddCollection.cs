using CollectionHierarchy.Interfaces;
using System.Collections.Generic;

namespace CollectionHierarchy
{
    public class AddCollection<T> : IAddable<T>
    {
        private List<T> list;

        public AddCollection()
        {
            list = new List<T>();
        }

        public int Add(T item) 
        { 
            list.Add(item);

            return list.Count - 1;
        }
    }
}
