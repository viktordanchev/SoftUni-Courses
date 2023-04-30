using System;
using System.Linq;

namespace _01.DiagonalDifference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            int firstSum = GetFirstDiagonalSum(matrix);
            int secondSum = GetSecondDiagonalSum(matrix);

            Console.WriteLine(Math.Max(firstSum, secondSum) - Math.Min(firstSum, secondSum));
        }

        static int GetSecondDiagonalSum(int[,] matrix)
        {
            int secondSum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = matrix.GetLength(1) - (row + 1); col >= 0; col++)
                {
                    secondSum += matrix[row, col];
                    break;
                }
            }

            return secondSum;
        }

        static int GetFirstDiagonalSum(int[,] matrix)
        {
            int firstSum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                firstSum += matrix[row, row];
            }

            return firstSum;
        }
    }
}