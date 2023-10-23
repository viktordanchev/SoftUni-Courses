using _05.TopView;
using System;

namespace TopView
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var binaryTree =
            new BinaryTree<int>(1,
                    new BinaryTree<int>(2,
                            new BinaryTree<int>(4, null, null),
                            new BinaryTree<int>(5, null, null)),
                    new BinaryTree<int>(3,
                            new BinaryTree<int>(6, null, null),
                            new BinaryTree<int>(7, null, null)));

            Console.WriteLine(string.Join(", ", binaryTree.TopView()));
        }
    }
}
