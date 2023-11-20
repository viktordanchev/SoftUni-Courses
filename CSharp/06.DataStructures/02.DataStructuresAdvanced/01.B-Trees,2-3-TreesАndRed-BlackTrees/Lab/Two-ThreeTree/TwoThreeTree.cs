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

            root = Insert(root, element);
        }

        private TreeNode<T> Insert(TreeNode<T> node, T element)
        {
            if (!node.IsLeaf())
            {
                if (element.CompareTo(node.LeftKey) < 0)
                {
                    var newNode = Insert(node.LeftChild, element);

                    return !newNode.IsLeaf() ? MergeNodes(node, newNode) : node;
                }
                else if (element.CompareTo(node.RightKey) < 0 || node.IsTwoNode())
                {
                    var newNode = Insert(node.MiddleChild, element);

                    return !newNode.IsLeaf() ? MergeNodes(node, newNode) : node;
                }
                else
                {
                    var newNode = Insert(node.RightChild, element);

                    return !newNode.IsLeaf() ? MergeNodes(node, newNode) : node;
                }
            }

            return MergeNodes(node, new TreeNode<T>(element));
        }

        private TreeNode<T> MergeNodes(TreeNode<T> node1, TreeNode<T> node2)
        {
            TreeNode<T> newNode = null;

            if (node1.IsLeaf() && node2.IsLeaf())
            { 
                if (node1.LeftKey.CompareTo(node2.LeftKey) > 0)
                {
                    newNode = new TreeNode<T>(node1.LeftKey);
                    newNode.LeftChild = node2;
                    newNode.MiddleChild = new TreeNode<T>(node1.RightKey);
                }
                else if (node1.RightKey.CompareTo(node2.LeftKey) < 0)
                {
                    newNode = new TreeNode<T>(node1.RightKey);
                    newNode.LeftChild = node1;
                    newNode.MiddleChild = new TreeNode<T>(node2.LeftKey);
                    node1.RightKey = default;
                }
                else
                {
                    newNode = new TreeNode<T>(node2.LeftKey);
                    newNode.LeftChild = node1;
                    newNode.MiddleChild = new TreeNode<T>(node1.RightKey);
                    node1.RightKey = default;
                }
            }
            else 
            {
                if (node1.LeftKey.CompareTo(node2.LeftKey) < 0)
                {
                    newNode = new TreeNode<T>(node1.LeftKey);
                    newNode.RightKey = node2.LeftKey;
                    newNode.LeftChild = node1.LeftChild;
                    newNode.MiddleChild = new TreeNode<T>(node2.LeftChild.LeftKey);
                    newNode.RightChild = new TreeNode<T>(node2.MiddleChild.LeftKey);
                }
                else if (node1.LeftKey.CompareTo(node2.LeftKey) > 0)
                {
                    newNode = new TreeNode<T>(node2.LeftKey);
                    newNode.RightKey = node1.LeftKey;
                    newNode.LeftChild = node2.LeftChild;
                    newNode.MiddleChild = new TreeNode<T>(node2.MiddleChild.LeftKey);
                    newNode.RightChild = new TreeNode<T>(node1.MiddleChild.LeftKey);
                }
            }

            return newNode;
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
