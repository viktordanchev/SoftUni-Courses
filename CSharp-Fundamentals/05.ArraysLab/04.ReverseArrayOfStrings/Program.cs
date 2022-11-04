using System;
using System.Linq;

namespace _04.ReverseArrayOfStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] elements = Console.ReadLine().Split();
            string[] reversedElements = new string[elements.Length];
            
            for (int i = 0; i < elements.Length; i++)
            {
                for (int j = reversedElements.Length - 1; j >= 0; j--)
                {
                    reversedElements[i] = elements[j];
                    i++;
                }
            }

            Console.WriteLine(string.Join(" ", reversedElements));
        }
    }
}
