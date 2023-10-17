namespace _02.BinarySearchTree
{
    using System;

    public class BinarySearchTree<T> : IBinarySearchTree<T>
        where T : IComparable<T>
    {
        private class Node
        {
            public Node(T value)
            {
                Value = value;
            }

            public T Value { get; private set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
        }

        private Node root;

        public BinarySearchTree() { }

        private BinarySearchTree(Node node)
        {
            PreOrderCopy(node);
        }

        public bool Contains(T element)
        {
            return FindNode(element) != null;
        }

        public void EachInOrder(Action<T> action)
        {
            EachInOrder(action, root);
        }

        public void Insert(T element)
        {
            root = Insert(element, root);
        }

        public IBinarySearchTree<T> Search(T element)
        {
            var node = FindNode(element);

            if(node == null)
            {
                return null;
            }

            return new BinarySearchTree<T>(node);
        }

        private void PreOrderCopy(Node node)
        {
            if(node == null)
            {
                return;
            }

            Insert(node.Value);
            PreOrderCopy(node.Left);
            PreOrderCopy(node.Right);
        }

        private Node FindNode(T element)
        {
            var node = root;

            while (node != null)
            {
                if (element.CompareTo(node.Value) < 0)
                {
                    node = node.Left;
                }
                else if (element.CompareTo(node.Value) > 0)
                {
                    node = node.Right;
                }
                else
                {
                    break;
                }
            }

            return node;
        }

        private Node Insert(T element, Node node)
        {
            if (node == null)
            {
                node = new Node(element);
            }
            else if (element.CompareTo(node.Value) < 0)
            {
                node.Left = Insert(element, node.Left);
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                node.Right = Insert(element, node.Right);
            }

            return node;
        }

        private void EachInOrder(Action<T> action, Node node)
        {
            if (node == null)
            {
                return;
            }

            this.EachInOrder(action, node.Left);

            action(node.Value);

            this.EachInOrder(action, node.Right);
        }
    }
}
