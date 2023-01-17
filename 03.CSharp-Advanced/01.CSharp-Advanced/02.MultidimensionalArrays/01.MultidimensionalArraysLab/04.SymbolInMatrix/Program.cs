using System;
using System.Linq;

namespace _04.SymbolInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            string[,] matrix = new string[size, 1];

            for (int i = 0; i < size; i++)
            {
                string chars = Console.ReadLine();

                matrix[i, 0] = chars;
            }

            char symbol = char.Parse(Console.ReadLine());

            int row = 0;
            int col = 0;
            foreach (string currRow in matrix)
            {
                foreach (char chr in currRow)
                {
                    if (chr == symbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }

                    col++;
                }

                col = 0;
                row++;
            }

            Console.WriteLine($"{symbol} does not occur in the matrix");
        }
    }
}