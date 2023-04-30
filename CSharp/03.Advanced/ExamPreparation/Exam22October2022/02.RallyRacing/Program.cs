using System;

namespace _02.RallyRacing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];

            int carNum = int.Parse(Console.ReadLine());

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = data[col][0];
                }
            }

            int carRow = 0;
            int carCol = 0;
            int passedKm = 0;
            bool hasHeFinished = false;

            string command = Console.ReadLine();
            while (command != "End")
            {
                if (matrix[carRow, carCol] == 'T')
                {
                    matrix[carRow, carCol] = '.';

                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            if (matrix[row, col] == 'T')
                            {
                                passedKm += 30;
                                matrix[row, col] = '.';
                                carRow = row;
                                carCol = col;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    passedKm += 10;
                }

                switch (command)
                {
                    case "up":
                        carRow--;
                        break;
                    case "down":
                        carRow++;
                        break;
                    case "right":
                        carCol++;
                        break;
                    case "left":
                        carCol--;
                        break;
                }

                if (matrix[carRow, carCol] == 'F')
                {
                    hasHeFinished = true;
                    matrix[carRow, carCol] = 'C';
                    Console.WriteLine($"Racing car {carNum} finished the stage!");
                    break;
                }

                command = Console.ReadLine();
            }

            matrix[carRow, carCol] = 'C';

            if (!hasHeFinished)
            {
                Console.WriteLine($"Racing car {carNum} DNF.");
            }

            Console.WriteLine($"Distance covered {passedKm} km.");
            PrintMatrix(matrix);
        }

        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}