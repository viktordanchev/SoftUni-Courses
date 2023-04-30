using System;

namespace _07.PascalTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            long[][] pascal = new long[rows][];

            for (int row = 0; row < rows; row++)
            {
                pascal[row] = new long[row + 1];

                for (int col = 0; col < pascal[row].Length; col++)
                {
                    if (row == 0 || col == 0 || pascal[row].Length - 1 == col)
                    {
                        pascal[row][col] = 1;
                        continue;
                    }

                    pascal[row][col] = pascal[row - 1][col - 1] + pascal[row - 1][col];
                }
            }

            foreach (long[] row in pascal)
            {
                Console.WriteLine(string.Join(' ', row));
            }
        }
    }
}
