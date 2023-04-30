using System;
using System.Diagnostics.SymbolStore;

namespace _02.WallDestroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] wall = new char[size, size];

            int vankoRow = 0;
            int vankoCol = 0;

            for (int row = 0; row < wall.GetLength(0); row++)
            {
                string data = Console.ReadLine();

                for (int col = 0; col < wall.GetLength(1); col++)
                {
                    wall[row, col] = data[col];

                    if (wall[row, col] == 'V')
                    {
                        wall[row, col] = '*';
                        vankoRow = row;
                        vankoCol = col;
                    }
                }
            }

            int countOfHoles = 1;
            int countOfRods = 0;
            bool isElectrocuted = false;

            string command = Console.ReadLine();
            while (command != "End")
            {
                switch (command)
                {
                    case "up":
                        if (vankoRow - 1 >= 0)
                        {
                            vankoRow--;

                            if (wall[vankoRow, vankoCol] == 'R')
                            {
                                countOfRods++;
                                vankoRow++;
                                Console.WriteLine("Vanko hit a rod!");

                                command = Console.ReadLine();
                                continue;
                            }
                        }
                        else
                        {
                            command = Console.ReadLine();
                            continue;
                        }
                        break;
                    case "down":
                        if (vankoRow + 1 <= size - 1)
                        {
                            vankoRow++;

                            if (wall[vankoRow, vankoCol] == 'R')
                            {
                                countOfRods++;
                                vankoRow--;
                                Console.WriteLine("Vanko hit a rod!");

                                command = Console.ReadLine();
                                continue;
                            }
                        }
                        else
                        {
                            command = Console.ReadLine();
                            continue;
                        }
                        break;
                    case "right":
                        if (vankoCol + 1 <= size - 1)
                        {
                            vankoCol++;

                            if (wall[vankoRow, vankoCol] == 'R')
                            {
                                countOfRods++;
                                vankoCol--;
                                Console.WriteLine("Vanko hit a rod!");

                                command = Console.ReadLine();
                                continue;
                            }
                        }
                        else
                        {
                            command = Console.ReadLine();
                            continue;
                        }
                        break;
                    case "left":
                        if (vankoCol - 1 >= 0)
                        {
                            vankoCol--;

                            if (wall[vankoRow, vankoCol] == 'R')
                            {
                                countOfRods++;
                                vankoCol++;
                                Console.WriteLine("Vanko hit a rod!");

                                command = Console.ReadLine();
                                continue;
                            }
                        }
                        else
                        {
                            command = Console.ReadLine();
                            continue;
                        }
                        break;
                }

                if (wall[vankoRow, vankoCol] == 'C')
                {
                    countOfHoles++;
                    wall[vankoRow, vankoCol] = 'E';
                    isElectrocuted = true;
                    Console.WriteLine($"Vanko got electrocuted, but he managed to make {countOfHoles} hole(s).");
                    break;
                }

                if (wall[vankoRow, vankoCol] == '*')
                {
                    Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol}]!");
                }
                else
                {
                    wall[vankoRow, vankoCol] = '*';
                    countOfHoles++;
                }

                command = Console.ReadLine();
            }

            if (!isElectrocuted)
            {
                Console.WriteLine($"Vanko managed to make {countOfHoles} hole(s) and he hit only {countOfRods} rod(s).");
                wall[vankoRow, vankoCol] = 'V';
            }

            PrintTheWall(wall);
        }

        static void PrintTheWall(char[,] matrix)
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