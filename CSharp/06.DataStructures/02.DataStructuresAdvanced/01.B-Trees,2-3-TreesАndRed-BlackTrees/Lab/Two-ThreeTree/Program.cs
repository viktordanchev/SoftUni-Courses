using System;

namespace TwoThreeTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tree = new TwoThreeTree<string>();
            tree.Insert("F");
            tree.Insert("G");
            tree.Insert("C");
            tree.Insert("A");
            tree.Insert("B");
            tree.Insert("D");
            tree.Insert("E");
            tree.Insert("K");
            tree.Insert("I");
            tree.Insert("G");
            tree.Insert("H");
            tree.Insert("J");
            tree.Insert("K");

            Console.WriteLine(tree.ToString());
        }
    }
}
