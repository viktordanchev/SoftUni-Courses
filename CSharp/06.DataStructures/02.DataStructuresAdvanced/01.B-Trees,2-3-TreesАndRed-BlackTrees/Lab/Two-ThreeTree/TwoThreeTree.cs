namespace TwoThreeTree
{
    using System;
    using System.Text;

    public class TwoThreeTree<T> where T : IComparable<T>
    {
        private TreeNode<T> root;

        public void Insert(T element)
        {
            if (root == null)
            {
                root = new TreeNode<T>(element);
                return;
            }

            Insert(root, element);
        }

        private void Insert(TreeNode<T> root, T element)
        {
            if (!root.IsLeaf())
            {
                if (element.CompareTo(root.LeftKey) < 0)
                {
                    Insert(root.LeftChild, element);
                }
                else if (element.CompareTo(root.RightKey) > 0)
                {
                    Insert(root.RightChild, element);
                }
                else
                {
                    Insert(root.MiddleChild, element);
                }

                if (!root.RightChild.IsLeaf() || !root.LeftChild.IsLeaf())
                {
                   this.root = Merge(root);
                }

                return;
            }

            if (root.IsThreeNode())
            {
                Resize(root, element);
            }
            else
            {
                if (root.LeftKey.CompareTo(element) > 0)
                {
                    root.RightKey = root.LeftKey;
                    root.LeftKey = element;
                }
                else
                {
                    root.RightKey = element;
                }
            }
        }

        private void Resize(TreeNode<T> root, T element)
        {
            if (root.LeftKey.CompareTo(element) > 0)
            {
                root.LeftChild = new TreeNode<T>(element);
                root.RightChild = new TreeNode<T>(root.RightKey);
            }
            else if (root.RightKey.CompareTo(element) < 0)
            {
                root.LeftChild = new TreeNode<T>(root.LeftKey);
                root.LeftKey = root.RightKey;
                root.RightChild = new TreeNode<T>(element);
            }
            else
            {
                root.LeftChild = new TreeNode<T>(root.LeftKey);
                root.RightChild = new TreeNode<T>(root.RightKey);
                root.LeftKey = element;
            }

            root.RightKey = default;
        }

        private TreeNode<T> Merge(TreeNode<T> root)
        {
            if (!root.RightChild.IsLeaf())
            {
                if (root.IsThreeNode())
                {
                    var newRoot = new TreeNode<T>(root.RightKey);
                    newRoot.LeftChild = new TreeNode<T>(root.LeftKey);
                    newRoot.LeftChild.LeftChild = root.LeftChild;
                    newRoot.LeftChild.RightChild = root.MiddleChild;
                    newRoot.RightChild = root.RightChild;

                    root = newRoot;
                }
                else
                {
                    root.RightKey = root.RightChild.LeftKey;
                    root.LeftChild = new TreeNode<T>(root.LeftChild.LeftKey);
                    root.MiddleChild = new TreeNode<T>(root.RightChild.LeftChild.LeftKey);
                    root.RightChild = new TreeNode<T>(root.RightChild.RightChild.LeftKey);
                }
            }

            return root;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            RecursivePrint(this.root, sb);
            return sb.ToString();
        }

        private void RecursivePrint(TreeNode<T> node, StringBuilder sb)
        {
            if (node == null)
            {
                return;
            }

            if (node.LeftKey != null)
            {
                sb.Append(node.LeftKey).Append(" ");
            }

            if (node.RightKey != null)
            {
                sb.Append(node.RightKey).Append(Environment.NewLine);
            }
            else
            {
                sb.Append(Environment.NewLine);
            }

            if (node.IsTwoNode())
            {
                RecursivePrint(node.LeftChild, sb);
                RecursivePrint(node.MiddleChild, sb);
            }
            else if (node.IsThreeNode())
            {
                RecursivePrint(node.LeftChild, sb);
                RecursivePrint(node.MiddleChild, sb);
                RecursivePrint(node.RightChild, sb);
            }
        }
    }
}
