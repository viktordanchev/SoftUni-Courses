using System;

namespace TwoThreeTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tree = new TwoThreeTree<string>();
            tree.Insert("B");
            tree.Insert("C");
            tree.Insert("A");
            tree.Insert("Y");
            tree.Insert("L");
            tree.Insert("Z");
            tree.Insert("O");
            Console.WriteLine(tree.ToString());
        }
    }
}
