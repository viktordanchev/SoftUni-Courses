using System;
using System.Linq;
using System.Numerics;

namespace _05.SnakeMosives
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];

            char[,] matrix = new char[rows, cols];

            string text = Console.ReadLine();

            int index = 0;
            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (index == text.Length)
                        {
                            index = 0;
                        }

                        matrix[row, col] = text[index];

                        index++;
                    }
                }
                else
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        if (index == text.Length)
                        {
                            index = 0;
                        }

                        matrix[row, col] = text[index];

                        index++;
                    }
                }
            }

            PrintResult(matrix, rows, cols);
        }

        static void PrintResult(char[,] matrix, int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}