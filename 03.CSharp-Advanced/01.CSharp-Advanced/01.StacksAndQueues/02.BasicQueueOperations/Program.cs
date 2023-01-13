using System;

namespace _02.BasicQueueOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int sum = 0;
            int num = 0;

            foreach (char chr in input)
            {
                sum += int.Parse(chr.ToString());
            }

            Console.WriteLine(sum);
        }
    }
}
