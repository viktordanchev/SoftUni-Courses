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

            AsIndentedPreOrder(result, this, indent);

            return result.ToString();
        }

        public void ForEachInOrder(Action<T> action)
        {
            if (this.LeftChild != null)
            {
                this.LeftChild.ForEachInOrder(action);
            }

            action(this.Value);

            if (this.RightChild != null)
            {
                this.RightChild.ForEachInOrder(action);
            }
        }

        public IEnumerable<IAbstractBinaryTree<T>> InOrder()
        {
            var list = new List<IAbstractBinaryTree<T>>();

            if(this.LeftChild != null)
            {
                list.AddRange(this.LeftChild.InOrder());
            }

            list.Add(this);

            if (this.RightChild != null)
            {
                list.AddRange(this.RightChild.InOrder());
            }

            return list;
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

        private void AsIndentedPreOrder(StringBuilder currString, IAbstractBinaryTree<T> node, int indent)
        {
            currString.AppendLine($"{Repeat(indent, " ")}{node.Value}");

            if (node.LeftChild != null)
            {
                AsIndentedPreOrder(currString, node.LeftChild, indent + 2);
            }

            if (node.RightChild != null)
            {
                AsIndentedPreOrder(currString, node.RightChild, indent + 2);
            }
        }
    }
}
