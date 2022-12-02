using System;
using System.Linq;

namespace _03.ZigZagArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int[] evenArray = new int[count];
            int[] oddArray = new int[count];

            for (int i = 0; i < count; i++)
            {
                int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (i % 2 == 0)
                {
                    evenArray[i] = numbers[0];
                    oddArray[i] = numbers[1];
                }
                else
                {
                    evenArray[i] = numbers[1];
                    oddArray[i] = numbers[0];
                }
            }

            Console.WriteLine(string.Join(' ', evenArray));
            Console.WriteLine(string.Join(' ', oddArray));
        }
    }
}
