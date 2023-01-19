using System;
using System.Linq;

namespace _03.PrimaryDiagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = nums[col];
                }
            }

            int sum = 0;
            for (int row = 0; row < size; row++)
            {
                for (int col = row; col < size; col++)
                {
                    sum += matrix[row, col];
                    break;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
