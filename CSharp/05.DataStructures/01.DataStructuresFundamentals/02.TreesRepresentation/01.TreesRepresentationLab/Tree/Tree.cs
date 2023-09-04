namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private T value;
        private Tree<T> parent;
        private List<Tree<T>> children;

        public Tree(T value)
        {
            this.value = value;
            children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                child.parent = this;
                this.children.Add(child);
            }
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> OrderBfs()
        {
            var result = new List<T>();
            var items = new Queue<Tree<T>>();

            items.Enqueue(this);
            while (items.Count > 0)
            {
                var currItem = items.Dequeue();
                result.Add(currItem.value);

                foreach (var child in currItem.children)
                {
                    items.Enqueue(child);
                }
            }

            return result;
        }

        public IEnumerable<T> OrderDfs()
        {
            var result = new Stack<T>();
            var items = new Stack<Tree<T>>();

            items.Push(this);
            while (items.Count > 0)
            {
                var currItem = items.Pop();

                foreach (var child in currItem.children)
                {
                    items.Push(child);
                }

                result.Push(currItem.value);
            }

            return result;
        }

        public void RemoveNode(T nodeKey)
        {
            throw new NotImplementedException();
        }

        public void Swap(T firstKey, T secondKey)
        {
            throw new NotImplementedException();
        }
    }
}
