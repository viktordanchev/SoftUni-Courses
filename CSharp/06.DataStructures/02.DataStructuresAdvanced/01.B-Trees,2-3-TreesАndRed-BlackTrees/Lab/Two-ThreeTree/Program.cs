using System;

namespace TwoThreeTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tree = new TwoThreeTree<string>();
            //tree.Insert("A");
            //tree.Insert("D");
            //tree.Insert("E");
            //tree.Insert("G");
            //tree.Insert("B");
            //tree.Insert("F");
            //tree.Insert("N");
            //tree.Insert("S");
            tree.Insert("F");
            tree.Insert("C");
            tree.Insert("G");
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
