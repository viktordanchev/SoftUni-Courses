namespace _02.LowestCommonAncestor
{
    using System;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(
            T value,
            BinaryTree<T> leftChild,
            BinaryTree<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
            if (leftChild != null)
            {
                this.LeftChild.Parent = this;
            }

            if (rightChild != null)
            {
                this.RightChild.Parent = this;
            }
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public BinaryTree<T> Parent { get; set; }

        public T FindLowestCommonAncestor(T first, T second)
        {
            var currTree = LeftChild.Parent;

            if(!Contains(currTree, first) || !Contains(currTree, second))
            {
                throw new InvalidOperationException();
            }

            while (Contains(currTree, first) && Contains(currTree, second))
            {
                if (Contains(currTree.LeftChild, first) && Contains(currTree.LeftChild, second))
                {
                    currTree = currTree.LeftChild;
                }
                else if (Contains(currTree.RightChild, first) && Contains(currTree.RightChild, second))
                {
                    currTree = currTree.RightChild;
                }
                else
                {
                    break;
                }
            }

            return currTree.Value;
        }

        private bool Contains(BinaryTree<T> tree, T element)
        {
            while (tree != null)
            {
                if (tree.Value.CompareTo(element) > 0)
                {
                    tree = tree.LeftChild;
                }
                else if (tree.Value.CompareTo(element) < 0)
                {
                    tree = tree.RightChild;
                }
                else
                {
                    break;
                }
            }

            return tree != null;
        }
    }
}
