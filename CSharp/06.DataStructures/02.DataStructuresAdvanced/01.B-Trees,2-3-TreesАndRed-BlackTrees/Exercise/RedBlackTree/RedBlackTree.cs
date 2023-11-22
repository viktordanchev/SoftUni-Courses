namespace _01.RedBlackTree
{
    using System;

    public class RedBlackTree<T> where T : IComparable
    {
        public class Node
        {
            public Node(T value)
            {
                this.Value = value;
            }

            public T Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
        }

        public Node root;

        public RedBlackTree()
        {

        }

        public void EachInOrder(Action<T> action)
        {
            throw new NotImplementedException();
        }

        public RedBlackTree<T> Search(T element)
        {
            throw new NotImplementedException();
        }

        public void Insert(T value)
        {
            throw new NotImplementedException();
        } 

        public void Delete(T key)
        {
            throw new NotImplementedException();
        }

        public void DeleteMin()
        {
            throw new NotImplementedException();
        }

        public void DeleteMax()
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }
    }
}