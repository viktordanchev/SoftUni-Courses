using System;
using System.Linq;

namespace _05.AppliedArithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int[]> add = arr => arr.Select(n => n + 1).ToArray();
            Func<int[], int[]> multiply = arr => arr.Select(n => n * 2).ToArray();
            Func<int[], int[]> subtract = arr => arr.Select(n => n - 1).ToArray();
            Action<int[]> print = n => Console.WriteLine(string.Join(' ', n)); 
            
            int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            string command = Console.ReadLine();
            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        numbers = add(numbers);
                        break;
                    case "multiply":
                        numbers = multiply(numbers);
                        break;
                    case "subtract":
                        numbers = subtract(numbers);
                        break;
                    case "print":
                        print(numbers);
                        break;
                }

                command = Console.ReadLine();
            }
        }
    }
}