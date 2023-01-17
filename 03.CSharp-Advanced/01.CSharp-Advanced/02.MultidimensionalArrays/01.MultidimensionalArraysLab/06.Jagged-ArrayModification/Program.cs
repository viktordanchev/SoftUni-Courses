using System;
using System.Linq;

namespace _06.Jagged_ArrayModification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jaggedArray = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                jaggedArray[row] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }

            string[] input = Console.ReadLine().Split();

            while (input[0] != "END")
            {
                string command = input[0];
                int row = int.Parse(input[1]);
                int col = int.Parse(input[2]);
                int value = int.Parse(input[3]);

                if (row < 0 || col < 0)
                {
                    Console.WriteLine("Invalid coordinates");
                    input = Console.ReadLine().Split();
                    continue;
                }
                
                if (row > jaggedArray.Length - 1  || col > jaggedArray[row].Length - 1)
                {
                    Console.WriteLine("Invalid coordinates");
                    input = Console.ReadLine().Split();
                    continue;
                }

                switch (command)
                {
                    case "Add":
                        jaggedArray[row][col] += value;
                        break;
                    case "Subtract":
                        jaggedArray[row][col] -= value;
                        break;
                }

                input = Console.ReadLine().Split();
            }

            foreach (int[] row in jaggedArray)
            {
                Console.WriteLine(string.Join(' ', row));
            }
        }
    }
}
