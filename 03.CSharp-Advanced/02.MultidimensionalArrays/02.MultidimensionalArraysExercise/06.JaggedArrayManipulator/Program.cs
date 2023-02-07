using System;
using System.Linq;

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

            string[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            while (data[0] != "End")
            {
                string command = data[0];
                int row = int.Parse(data[1]);
                int col = int.Parse(data[2]);
                int value = int.Parse(data[3]);

                if (row < 0 || row >= jaggedArray.Length || col < 0 || jaggedArray[row].Length - 1 < col)
                {
                    data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
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

                data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            Print(jaggedArray);
        }

        static void Print(int[][] jaggedArray)
        {
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                Console.WriteLine(string.Join(" ", jaggedArray[row]));
            }
        }

        static void CheckArrayForEqualRowsLength(int[][] jaggedArray)
        {
            for (int row = 0; row < jaggedArray.Length - 1; row++)
            {
                for (int col = 0; col < Math.Max(jaggedArray[row].Length, jaggedArray[row + 1].Length); col++)
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