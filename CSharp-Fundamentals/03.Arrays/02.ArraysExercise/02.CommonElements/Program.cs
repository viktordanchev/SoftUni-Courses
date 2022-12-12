using System;
using System.Linq;

namespace _02.CommonElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] firstArr = Console.ReadLine().Split();
            string[] secondArr = Console.ReadLine().Split();

            foreach (string item in secondArr)
            {
                foreach (string item2 in firstArr)
                {
                    if (item == item2)
                    {
                        Console.Write($"{item} ");
                    }
                }
            }
        }
    }
}
