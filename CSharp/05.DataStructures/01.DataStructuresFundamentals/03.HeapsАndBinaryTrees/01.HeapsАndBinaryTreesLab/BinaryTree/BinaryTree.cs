namespace _01.BinaryTree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

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
            var result = new StringBuilder();
            var tree = new Stack<IAbstractBinaryTree<T>>();

            tree.Push(this);

            while (tree.Count > 0)
            {
                var node = tree.Pop();

                result.AppendLine($"{Repeat(indent, " ")}{node.Value}");

                if (node.RightChild != null)
                {
                    tree.Push(node.RightChild);
                }

                if (node.LeftChild != null)
                {
                    tree.Push(node.LeftChild);
                }

                indent += 2;
            }

            return result.ToString();
        }

        public void ForEachInOrder(Action<T> action)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IAbstractBinaryTree<T>> InOrder()
        {
            var result = new List<IAbstractBinaryTree<T>>();
            var tree = new Stack<IAbstractBinaryTree<T>>();

            tree.Push(this);

            while (tree.Count > 0)
            {
                var node = tree.Peek();

                if (node.LeftChild != null)
                {
                    tree.Push(node.LeftChild);
                    continue;
                }

                result.Add(tree.Pop());

                if (tree.Count == 0)
                    break;

                node = tree.Pop();
                result.Add(node);

                if (node.RightChild != null)
                    tree.Push(node.RightChild);
            }

            return result;
        }

        public IEnumerable<IAbstractBinaryTree<T>> PostOrder()
        {
            var result = new Stack<IAbstractBinaryTree<T>>();
            var tree = new Stack<IAbstractBinaryTree<T>>();

            tree.Push(this);

            while (tree.Count > 0)
            {
                var node = tree.Pop();
                result.Push(node);

                if (node.LeftChild != null)
                    tree.Push(node.LeftChild);

                if (node.RightChild != null)
                    tree.Push(node.RightChild);
            }

            return result;
        }

        public IEnumerable<IAbstractBinaryTree<T>> PreOrder()
        {
            var result = new List<IAbstractBinaryTree<T>>();
            var tree = new Stack<IAbstractBinaryTree<T>>();

            tree.Push(this);

            while (tree.Count > 0)
            {
                var node = tree.Pop();

                result.Add(node);

                if (node.RightChild != null)
                    tree.Push(node.RightChild);

                if (node.LeftChild != null)
                    tree.Push(node.LeftChild);
            }

            return result;
        }

        private string Repeat(int count, string str)
        {
            var output = new StringBuilder();

            for (int i = 0; i < count; i++)
            {
                output.Append(str);
            }

            return output.ToString();
        }
    }
}
