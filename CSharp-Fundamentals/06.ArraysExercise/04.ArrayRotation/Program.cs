using System;
using System.Linq;
using System.Reflection;

namespace _04.ArrayRotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rotations = int.Parse(Console.ReadLine());
            int[] numbersToMove = new int[rotations];

            if (rotations > numbers.Length)
            {
                rotations = rotations - numbers.Length;
            }

            for (int i = 0; i < rotations; i++)
            {
                numbersToMove[i] = numbers[i];
            }

            for (int i = 0; i < rotations; i++)
            {
                int currNumber = numbersToMove[i];

                for (int index = 0; index < numbers.Length; index++)
                {
                    if (index == numbers.Length-1)
                    {
                        numbers[numbers.Length - 1] = currNumber;
                        break;
                    }

                    numbers[index] = numbers[index + 1];
                }   
            }

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
