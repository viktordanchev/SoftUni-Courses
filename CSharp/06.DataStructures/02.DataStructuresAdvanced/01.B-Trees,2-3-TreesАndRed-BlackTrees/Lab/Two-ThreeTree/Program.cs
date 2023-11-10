using System;

namespace TwoThreeTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tree = new TwoThreeTree<string>();
            tree.Insert("B");
            tree.Insert("A");
            tree.Insert("C");
            tree.Insert("Y");
            tree.Insert("L");
            tree.Insert("Z");
            tree.Insert("O");
            tree.Insert("V");
            tree.Insert("S");
            tree.Insert("N");
            Console.WriteLine(tree.ToString());
        }
    }
}
