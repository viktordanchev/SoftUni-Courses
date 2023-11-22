namespace _01.Two_Three
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

                    return newNode != node.LeftChild ? MergeNodes(node, newNode) : node;
                }
                else if (element.CompareTo(node.RightKey) < 0 || node.IsTwoNode())
                {
                    var newNode = Insert(node.MiddleChild, element);

                    return newNode != node.MiddleChild ? MergeNodes(node, newNode) : node;
                }
                else
                {
                    var newNode = Insert(node.RightChild, element);

                    return newNode != node.RightChild ? MergeNodes(node, newNode) : node;
                }
            }

            return MergeNodes(node, new TreeNode<T>(element));
        }

        private TreeNode<T> MergeNodes(TreeNode<T> current, TreeNode<T> node)
        {
            if (current.IsTwoNode())
            {
                if (current.LeftKey.CompareTo(node.LeftKey) < 0)
                {
                    current.RightKey = node.LeftKey;
                    current.MiddleChild = node.LeftChild;
                    current.RightChild = node.MiddleChild;
                }
                else
                {
                    current.RightKey = current.LeftKey;
                    current.RightChild = current.MiddleChild;
                    current.MiddleChild = node.MiddleChild;
                    current.LeftChild = node.LeftChild;
                    current.LeftKey = node.LeftKey;
                }

                return current;
            }
            else if (node.LeftKey.CompareTo(current.LeftKey) < 0)
            {
                var newNode = new TreeNode<T>(current.LeftKey)
                {
                    LeftChild = node,
                    MiddleChild = current
                };

                current.LeftChild = current.MiddleChild;
                current.MiddleChild = current.RightChild;
                current.LeftKey = current.RightKey;
                current.RightKey = default;
                current.RightChild = null;

                return newNode;
            }
            else if (node.LeftKey.CompareTo(current.RightKey) < 0)
            {
                node.MiddleChild = new TreeNode<T>(current.RightKey)
                {
                    LeftChild = node.MiddleChild,
                    MiddleChild = current.RightChild
                };

                node.LeftChild = current;
                current.RightKey = default;
                current.RightChild = null;

                return node;
            }
            else
            {
                var newNode = new TreeNode<T>(current.RightKey)
                {
                    LeftChild = current,
                    MiddleChild = node
                };

                node.LeftChild = current.RightChild;
                current.RightKey = default;
                current.RightChild = null;

                return newNode;
            }
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
