using System;
using System.Threading.Channels;

namespace _02.CharacterMultiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] stringArray = Console.ReadLine().Split();
            char[] firstArray = stringArray[0].ToCharArray();
            char[] secondArray = stringArray[1].ToCharArray();

            int sum = GetSum(firstArray, secondArray);

            Console.WriteLine(sum);
        }

        static int GetSum(char[] firstArray, char[] secondArray)
        {
            int sum = 0;
            char[] smallerArray;
            char[] bigerArray;

            if (firstArray.Length > secondArray.Length)
            {
                smallerArray = secondArray;
                bigerArray = firstArray;
            }
            else 
            {
                smallerArray = firstArray;
                bigerArray = secondArray;
            }
            
            for (int i = 0; i < Math.Max(firstArray.Length, secondArray.Length); i++)
            {
                if (i >= smallerArray.Length)
                {
                    sum += bigerArray[i];
                    continue;
                }

                sum += firstArray[i] * secondArray[i];
            }

            return sum;
        }
    }
}