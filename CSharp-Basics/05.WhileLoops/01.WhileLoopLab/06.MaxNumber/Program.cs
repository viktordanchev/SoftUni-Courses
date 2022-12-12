using System;

namespace _06.MaxNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string n = Console.ReadLine();
            int maxNum = int.MinValue;

            while (n != "Stop")
            {
                int num = int.Parse(n);
                if (num > maxNum)
                {
                    maxNum = num;
                }

                n = Console.ReadLine();
            }
            Console.WriteLine(maxNum);
        }
    }
}
