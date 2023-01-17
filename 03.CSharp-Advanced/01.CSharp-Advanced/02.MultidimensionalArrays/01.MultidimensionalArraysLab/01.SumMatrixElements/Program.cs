using System;
using System.Linq;

namespace _01.SumMatrixElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];
            
            int[,] matrix = new int[rows, cols];
            
            int sum = 0;
            for (int row = 0; row < rows; row++)
            {
                int[] nums = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = nums[col];
                    sum += nums[col];
                }
            }
            
            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);
        }
    }
}