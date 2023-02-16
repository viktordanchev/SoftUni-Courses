using System;
using System.Collections.Generic;

namespace _02.BeaverAtWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] pond = new char[size, size];

            int beaverRow = 0;
            int beaverCol = 0;
            int allBranches = 0;

            for (int row = 0; row < pond.GetLength(0); row++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < pond.GetLength(1); col++)
                {
                    pond[row, col] = data[col][0];

                    if (pond[row, col] == 'B')
                    {
                        beaverRow = row;
                        beaverCol = col;
                        pond[beaverRow, beaverCol] = '-';
                    }

                    if (char.IsLower(pond[row, col]))
                    {
                        allBranches++;
                    }
                }
            }

            List<char> branches = new List<char>();
            int getedBranches = 0;

            string command = Console.ReadLine();
            while (command != "end")
            {
                if (getedBranches == allBranches)
                {
                    break;
                }

                switch (command)
                {
                    case "up":
                        pond[beaverRow, beaverCol] = '-';

                        if (beaverRow - 1 < 0)
                        {
                            if (branches.Count > 0)
                            {
                                branches.RemoveAt(branches.Count - 1);
                            }

                            command = Console.ReadLine();
                            continue;
                        }

                        beaverRow--;

                        if (pond[beaverRow, beaverCol] == 'F' && beaverRow == 0)
                        {
                            pond[beaverRow, beaverCol] = '-';
                            beaverRow = size - 1;
                            pond[beaverRow, beaverCol] = 'B';
                        }
                        else if(pond[beaverRow, beaverCol] == 'F')
                        {
                            pond[beaverRow, beaverCol] = '-';
                            beaverRow = 0;
                            pond[beaverRow, beaverCol] = 'B';
                        }
                        break;
                    case "down":
                        pond[beaverRow, beaverCol] = '-';

                        if (beaverRow + 1> size - 1)
                        {
                            if (branches.Count > 0)
                            {
                                branches.RemoveAt(branches.Count - 1);
                            }

                            command = Console.ReadLine();
                            continue;
                        }

                        beaverRow++;

                        if (pond[beaverRow, beaverCol] == 'F' && beaverRow == size - 1)
                        {
                            pond[beaverRow, beaverCol] = '-';
                            beaverRow = 0;
                            pond[beaverRow, beaverCol] = 'B';
                        }
                        else if (pond[beaverRow, beaverCol] == 'F')
                        {
                            pond[beaverRow, beaverCol] = '-';
                            beaverRow = size - 1;
                            pond[beaverRow, beaverCol] = 'B';
                        }
                        break;
                    case "right":
                        pond[beaverRow, beaverCol] = '-';

                        if (beaverCol + 1 > size - 1)
                        {
                            if (branches.Count > 0)
                            {
                                branches.RemoveAt(branches.Count - 1);
                            }

                            command = Console.ReadLine();
                            continue;
                        }

                        beaverCol++;

                        if (pond[beaverRow, beaverCol] == 'F' && beaverCol == size - 1)
                        {
                            pond[beaverRow, beaverCol] = '-';
                            beaverCol = 0;
                            pond[beaverRow, beaverCol] = 'B';
                        }
                        else if (pond[beaverRow, beaverCol] == 'F')
                        {
                            pond[beaverRow, beaverCol] = '-';
                            beaverCol = size - 1;
                            pond[beaverRow, beaverCol] = 'B';
                        }
                        break;
                    case "left":
                        pond[beaverRow, beaverCol] = '-';

                        if (beaverCol - 1 < 0)
                        {
                            if (branches.Count > 0)
                            {
                                branches.RemoveAt(branches.Count - 1);
                            }
                            
                            command = Console.ReadLine();
                            continue;
                        }

                        beaverCol--;

                        if (pond[beaverRow, beaverCol] == 'F' && beaverCol == 0)
                        {
                            pond[beaverRow, beaverCol] = '-';
                            beaverCol = size - 1;
                            pond[beaverRow, beaverCol] = 'B';
                        }
                        else if (pond[beaverRow, beaverCol] == 'F')
                        {
                            pond[beaverRow, beaverCol] = '-';
                            beaverCol = 0;
                            pond[beaverRow, beaverCol] = 'B';
                        }
                        break;
                }

                if (char.IsLower(pond[beaverRow, beaverCol]))
                {
                    branches.Add(pond[beaverRow, beaverCol]);
                    getedBranches++;
                }

                command = Console.ReadLine();
            }

            pond[beaverRow, beaverCol] = 'B';

            if (allBranches == getedBranches)
            {
                Console.WriteLine($"The Beaver successfully collect {branches.Count} wood branches: {string.Join(", ", branches)}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {allBranches - getedBranches} branches left.");
            }

            PrintPond(pond);
        }

        static void PrintPond(char[,] pond)
        {
            for (int row = 0; row < pond.GetLength(0); row++)
            {
                for (int col = 0; col < pond.GetLength(1); col++)
                {
                    Console.Write(pond[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}