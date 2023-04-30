using System;
using System.Linq;

namespace _03.MaximalSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray(); ;

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            int sum = 0;
            int biggestSum = 0;
            int biggestRows = 0;
            int biggestCols = 0;
            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    sum = 0;

                    sum += matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
                           + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
                           + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (sum > biggestSum)
                    {
                        biggestSum = sum;
                        biggestRows = row;
                        biggestCols = col;
                    }
                }
            }

            PrintResult(matrix, biggestSum, biggestRows, biggestCols);
        }

        static void PrintResult(int[,] matrix, int biggestSum, int biggestRows, int biggestCols)
        {
            Console.WriteLine($"Sum = {biggestSum}");

            Console.WriteLine($"{matrix[biggestRows, biggestCols]} {matrix[biggestRows, biggestCols + 1]} {matrix[biggestRows, biggestCols + 2]}");
            Console.WriteLine($"{matrix[biggestRows + 1, biggestCols]} {matrix[biggestRows + 1, biggestCols + 1]} {matrix[biggestRows + 1, biggestCols + 2]}");
            Console.WriteLine($"{matrix[biggestRows + 2, biggestCols]} {matrix[biggestRows + 2, biggestCols + 1]} {matrix[biggestRows + 2, biggestCols + 2]}");
        }
    }
}