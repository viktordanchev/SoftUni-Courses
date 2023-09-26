namespace _01.BinaryTree
{
    using System;
    using System.Collections.Generic;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
    {
        public BinaryTree(T element, IAbstractBinaryTree<T> left, IAbstractBinaryTree<T> right)
        {
            Value = element;
            LeftChild = left;
            RightChild = right;
        }

        public T Value { get; }

        public IAbstractBinaryTree<T> LeftChild { get; }

        public IAbstractBinaryTree<T> RightChild { get; }

        public string AsIndentedPreOrder(int indent)
        {
            throw new NotImplementedException();
        }

        public void ForEachInOrder(Action<T> action)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IAbstractBinaryTree<T>> InOrder()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IAbstractBinaryTree<T>> PostOrder()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> PreOrder()
        {
            var result = new Queue<T>();
            var tree = new Stack<IAbstractBinaryTree<T>>();

            tree.Push(this);

            while (tree.Count > 0)
            {
                var currTree = tree.Peek();
                result.Enqueue(currTree.Value);

                if (currTree.LeftChild != null)
                    tree.Push(currTree.LeftChild);
                else if (currTree.RightChild != null)
                    tree.Push(currTree.RightChild);
                else
                {
                    tree.Pop();
                    tree.Push(currTree.RightChild);
                }
            }

            return result;
        }
    }
}
