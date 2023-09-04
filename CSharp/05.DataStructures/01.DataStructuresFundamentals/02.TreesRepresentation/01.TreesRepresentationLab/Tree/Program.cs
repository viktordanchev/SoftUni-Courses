using System;

namespace Tree
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var tree = new Tree<int>(1, 
                           new Tree<int>(2),
                           new Tree<int>(3),
                           new Tree<int>(4, 
                               new Tree<int>(5))
                           );

            var tree2 = new Tree<int>(1);

            Console.WriteLine(string.Join(", ", tree.OrderDfs()));
        }
    }
}
