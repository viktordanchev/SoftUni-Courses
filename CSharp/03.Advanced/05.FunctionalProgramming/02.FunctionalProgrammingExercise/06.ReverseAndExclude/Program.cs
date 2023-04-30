using System;
using System.Linq;

namespace _06.ReverseAndExclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int currNumber = int.Parse(Console.ReadLine());

            Func<int[], int[]> reversArray = arr => ReverseArray(arr);
            Predicate<int> isDivisibleByTwo = n => n % currNumber == 0;

            numbers = reversArray(numbers);

            foreach (var number in numbers)
            {
                if (isDivisibleByTwo(number))
                {
                    continue;
                }

                Console.Write($"{number} ");
            }
        }

        static int[] ReverseArray(int[] numbers)
        {
            int lastNum = 0;

            for (int i = 0; i < numbers.Length / 2; i++)
            {
                lastNum = numbers[numbers.Length - (i + 1)];

                numbers[numbers.Length - (i + 1)] = numbers[i];
                numbers[i] = lastNum;
            }

            return numbers;
        }
    }
}