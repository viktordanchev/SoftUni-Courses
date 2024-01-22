namespace _05.TopView
{
    using System;
    using System.Collections.Generic;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(T value, BinaryTree<T> left, BinaryTree<T> right)
        {
            this.Value = value;
            this.LeftChild = left;
            this.RightChild = right;
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public List<T> TopView()
        {
            var result = new List<T>();
            var first = new Queue<T>();

            var tree = this;
            while(tree != null)
            {
                result.Add(tree.Value);
                tree = tree.LeftChild;
            }

            tree = RightChild;
            while (tree != null)
            {
                result.Add(tree.Value);
                tree = tree.RightChild;
            }

            return result;
        }
    }
}
