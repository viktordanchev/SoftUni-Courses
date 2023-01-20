using System;
using System.Linq;

namespace _02.SquaresInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                char[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = data[col];
                }
            }

            int count = GetCount(matrix, rows, cols);
            
            Console.WriteLine(count);
        }

        static int GetCount(char[,] matrix, int rows, int cols)
        {
            int count = 0;

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    char currChar = matrix[row, col];

                    if (matrix[row, col] == currChar && matrix[row, col + 1] == currChar && 
                        matrix[row + 1, col] == currChar && matrix[row + 1, col + 1] == currChar)
                    {
                        count += 1;
                    }
                }
            }

            return count;
        }
    }
}