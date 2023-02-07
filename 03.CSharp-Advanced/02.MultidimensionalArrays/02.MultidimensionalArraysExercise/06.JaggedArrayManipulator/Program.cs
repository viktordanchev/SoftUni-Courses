using System;
using System.Linq;
using System.Threading;

namespace _06.JaggedArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jaggedArray = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                jaggedArray[row] = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }

            CheckArrayForEqualRowsLength(jaggedArray);
        }

        static void CheckArrayForEqualRowsLength(int[][] jaggedArray)
        {
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
                    {
                        jaggedArray[row][col] *= 2;
                        jaggedArray[row + 1][col] *= 2;
                    }
                    else
                    {
                        if (jaggedArray[row].Length > col)
                        {
                            jaggedArray[row][col] /= 2;
                        }

                        if (jaggedArray[row + 1].Length > col)
                        {
                            jaggedArray[row + 1][col] /= 2;
                        }
                    }
                }
            }
        }
    }
}
