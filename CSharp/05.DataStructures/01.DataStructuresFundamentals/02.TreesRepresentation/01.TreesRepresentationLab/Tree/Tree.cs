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
            var subtree = GetTree(parentKey);

            if (subtree == null)
                throw new ArgumentNullException();

            subtree.children.Add(child);
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
            var subtree = GetTree(nodeKey);

            if (subtree == null)
                throw new ArgumentNullException();

            if (subtree.parent == null)
                throw new ArgumentException();

            subtree.parent.children.Remove(subtree);
        }

        public void Swap(T firstKey, T secondKey)
        {
            var firstSubtree = GetTree(firstKey);
            var secondSubtree = GetTree(secondKey);

            if (firstSubtree == null || secondSubtree == null)
                throw new ArgumentNullException();

            if (firstSubtree.parent == null || secondSubtree.parent == null)
                throw new ArgumentException();

            var firstSubtreeChildren = firstSubtree.parent.children;
            var secondSubtreeChildren = secondSubtree.parent.children;
            var firstIndex = firstSubtreeChildren.IndexOf(firstSubtree);
            var secondIndex = secondSubtreeChildren.IndexOf(secondSubtree);

            firstSubtreeChildren.RemoveAt(firstIndex);
            firstSubtreeChildren.Insert(firstIndex, secondSubtree);

            secondSubtreeChildren.RemoveAt(secondIndex);
            secondSubtreeChildren.Insert(secondIndex, firstSubtree);
        }

        private Tree<T> GetTree(T key)
        {
            var items = new Queue<Tree<T>>();
            items.Enqueue(this);

            while (items.Count > 0)
            {
                var subtree = items.Dequeue();

                if (subtree.value.Equals(key))
                {
                    return subtree;
                }

                foreach (var currChild in subtree.children)
                {
                    items.Enqueue(currChild);
                }
            }

            return null;
        }
    }
}
