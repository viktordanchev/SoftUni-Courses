using System;

namespace _07.MinNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string n = Console.ReadLine();
            int minNum = int.MaxValue;

            while (n != "Stop")
            {
                int num = int.Parse(n);
                if (num < minNum)
                {
                    minNum = num;
                }

                n = Console.ReadLine();
            }
            Console.WriteLine(minNum);
        }
    }
}
