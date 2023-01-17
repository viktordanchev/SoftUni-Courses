using System;
using System.Linq;

namespace _05.SquareWithMaximumSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] nums = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = nums[col];
                }
            }

            int sum = 0;
            int biggestSum = 0;
            int[,] biggestMatrix = new int[2, 2];
            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    sum += matrix[row, col];
                    sum += matrix[row, col + 1];
                    sum += matrix[row + 1, col];
                    sum += matrix[row + 1, col + 1];

                    if (sum > biggestSum)
                    {
                        biggestSum = sum;
                        biggestMatrix[0,0] = matrix[row, col];
                        biggestMatrix[0,1] = matrix[row, col + 1];
                        biggestMatrix[1,0] = matrix[row + 1, col];
                        biggestMatrix[1,1] = matrix[row + 1 , col + 1];
                    }

                    sum = 0;
                }
            }

            PrintResult(biggestSum, biggestMatrix);
        }

        static void PrintResult(int biggestSum, int[,] biggestMatrix)
        {
            for (int row = 0; row < biggestMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < biggestMatrix.GetLength(1); col++)
                {
                    Console.Write($"{biggestMatrix[row, col]} ");
                }

                Console.WriteLine();
            }

            Console.WriteLine(biggestSum);
        }
    }
}
