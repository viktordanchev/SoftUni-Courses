using System;
using System.Linq;

namespace _01.Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfWagons = int.Parse(Console.ReadLine());
            int[] arr = new int[numberOfWagons];
            int sum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                int numberOfPeoples = int.Parse(Console.ReadLine());

                arr[i] = numberOfPeoples;
                sum += numberOfPeoples;
            }

            Console.WriteLine(string.Join(" ", arr));
            Console.WriteLine(sum);
        }
    }
}
