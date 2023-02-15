using System;

namespace _02.TruffleHunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] forest = new char[size, size];

            for (int row = 0; row < forest.GetLength(0); row++)
            {
                string[] rowData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < forest.GetLength(1); col++)
                {
                    forest[row, col] = rowData[col][0];
                }
            }

            int blackTrufflesCount = 0;
            int summerTrufflesCount = 0;
            int whiteTrufflesCount = 0;
            int wildBoarAtes = 0;

            string data = Console.ReadLine();
            while (data != "Stop the hunt")
            {
                string[] tokens = data.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];

                switch (command)
                {
                    case "Collect":
                        int currRow = int.Parse(tokens[1]);
                        int currCol = int.Parse(tokens[2]);

                        if (currRow < 0 || currRow > size - 1 || currCol < 0 || currCol > size - 1)
                        {
                            data = Console.ReadLine();
                            continue;
                        }

                        if (forest[currRow, currCol] == 'B')
                        {
                            blackTrufflesCount++;
                            forest[currRow, currCol] = '-';
                        }
                        else if (forest[currRow, currCol] == 'S')
                        {
                            summerTrufflesCount++;
                            forest[currRow, currCol] = '-';
                        }
                        else if (forest[currRow, currCol] == 'W')
                        {
                            whiteTrufflesCount++;
                            forest[currRow, currCol] = '-';
                        }
                        break;
                    case "Wild_Boar":
                        currRow = int.Parse(tokens[1]);
                        currCol = int.Parse(tokens[2]);
                        string direction = tokens[3];

                        switch (direction)
                        {
                            case "up":
                                while (currRow >= 0)
                                {
                                    if (forest[currRow, currCol] != '-')
                                    {
                                        wildBoarAtes++;
                                        forest[currRow, currCol] = '-';
                                    }

                                    currRow -= 2;
                                }
                                break;
                            case "down":
                                while (currRow <= size - 1)
                                {
                                    if (forest[currRow, currCol] != '-')
                                    {
                                        wildBoarAtes++;
                                        forest[currRow, currCol] = '-';
                                    }

                                    currRow += 2;
                                }
                                break;
                            case "right":
                                while (currCol <= size - 1)
                                {
                                    if (forest[currRow, currCol] != '-')
                                    {
                                        wildBoarAtes++;
                                        forest[currRow, currCol] = '-';
                                    }

                                    currCol += 2;
                                }
                                break;
                            case "left":
                                while (currCol >= 0)
                                {
                                    if (forest[currRow, currCol] != '-')
                                    {
                                        wildBoarAtes++;
                                        forest[currRow, currCol] = '-';
                                    }

                                    currCol -= 2;
                                }
                                break;
                        }
                        break;
                }

                data = Console.ReadLine();
            }

            Console.WriteLine($"Peter manages to harvest {blackTrufflesCount} black, {summerTrufflesCount} summer, and {whiteTrufflesCount} white truffles.");
            Console.WriteLine($"The wild boar has eaten {wildBoarAtes} truffles.");

            PrintForest(forest);
        }

        static void PrintForest(char[,] forest)
        {
            for (int row = 0; row < forest.GetLength(0); row++)
            {
                for (int col = 0; col < forest.GetLength(1); col++)
                {
                    Console.Write(forest[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}