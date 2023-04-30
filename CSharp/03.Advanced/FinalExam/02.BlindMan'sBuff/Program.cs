using System;
using System.Linq;

namespace _02.Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            char[,] playground = new char[rows, cols];

            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < rows; row++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < cols; col++)
                {
                    playground[row, col] = data[col][0];

                    if (playground[row, col] == 'B')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            int touchedOpponentsCount = 0;
            int makedMoves = 0;

            string command = Console.ReadLine();
            while (command != "Finish")
            {
                switch (command)
                {
                    case "up":
                        if (!IsValid(playerRow - 1, playerCol, playground) || playground[playerRow - 1, playerCol] == 'O')
                        {
                            command = Console.ReadLine();
                            continue;
                        }

                        playerRow--;
                        makedMoves++;
                        break;
                    case "down":
                        if (!IsValid(playerRow + 1, playerCol, playground) || playground[playerRow + 1, playerCol] == 'O')
                        {
                            command = Console.ReadLine();
                            continue;
                        }

                        playerRow++;
                        makedMoves++;
                        break;
                    case "right":
                        if (!IsValid(playerRow, playerCol + 1, playground) || playground[playerRow, playerCol + 1] == 'O')
                        {
                            command = Console.ReadLine();
                            continue;
                        }

                        playerCol++;
                        makedMoves++;
                        break;
                    case "left":
                        if (!IsValid(playerRow, playerCol - 1, playground) || playground[playerRow, playerCol - 1] == 'O')
                        {
                            command = Console.ReadLine();
                            continue;
                        }

                        playerCol--;
                        makedMoves++;
                        break;
                }

                if (playground[playerRow, playerCol] == 'P')
                {
                    playground[playerRow, playerCol] = '-';
                    touchedOpponentsCount++;

                    if (touchedOpponentsCount == 3)
                    {
                        break;
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("Game over!");
            Console.WriteLine($"Touched opponents: {touchedOpponentsCount} Moves made: {makedMoves}");
        }

        static bool IsValid(int playerRow, int playerCol, char[,] playground)
        {
            if (playerRow > -1 && playerCol > -1 && playerRow < playground.GetLength(0) && playerCol < playground.GetLength(1))
            {
                return true;
            }

            return false;
        }
    }
}