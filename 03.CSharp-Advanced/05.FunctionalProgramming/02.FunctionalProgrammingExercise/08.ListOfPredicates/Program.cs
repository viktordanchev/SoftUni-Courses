using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.ListOfPredicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();

            Func<int, List<int>> makeList = arrayLength =>
            {
                for (int i = 1; i <= arrayLength; i++)
                {
                    numbers.Add(i);
                }

                return numbers;
            };

            Func<List<int>, int[], List<int>> check = (numbers, dividers) => 
            {
                int validChecks = 0;

                for (int i = 0; i < numbers.Count; i++)
                {
                    for (int j = 0; j < dividers.Length; j++)
                    {
                        if (numbers[i] % dividers[j] == 0)
                        {
                            validChecks++;
                        }
                    }

                    if (validChecks != dividers.Length)
                    {
                        numbers.Remove(numbers[i]);
                        i--;
                    }

                    validChecks = 0;
                }

                return numbers;
            };

            int arrayLength = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            makeList(arrayLength);

            check(numbers, dividers);

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}