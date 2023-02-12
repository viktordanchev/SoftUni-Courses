using System;

namespace _02.HelpAMole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] playingField = new char[size, size];

            int moleRow = 0;
            int moleCol = 0;

            for (int row = 0; row < playingField.GetLength(0); row++)
            {
                string data = Console.ReadLine();

                for (int col = 0; col < playingField.GetLength(1); col++)
                {
                    playingField[row, col] = data[col];

                    if (playingField[row, col] == 'M')
                    {
                        moleRow = row;
                        moleCol = col;
                    }
                }
            }

            int points = 0;
            playingField[moleRow, moleCol] = '-';

            string command = Console.ReadLine();
            while (command != "End" && points < 25)
            { 
                switch (command)
                {
                    case "up":
                        if (moleRow - 1 < 0)
                        {
                            Console.WriteLine("Don't try to escape the playing field!");
                            command = Console.ReadLine();
                            continue;
                        }

                        moleRow--;
                        break;
                    case "down":
                        if (moleRow + 1 > size - 1)
                        {
                            Console.WriteLine("Don't try to escape the playing field!");
                            command = Console.ReadLine();
                            continue;
                        }

                        moleRow++;
                        break;
                    case "right":
                        if (moleCol + 1 > size - 1)
                        {
                            Console.WriteLine("Don't try to escape the playing field!");
                            command = Console.ReadLine();
                            continue;
                        }

                        moleCol++;
                        break;
                    case "left":
                        if (moleCol - 1 < 0)
                        {
                            Console.WriteLine("Don't try to escape the playing field!");
                            command = Console.ReadLine();
                            continue;
                        }

                        moleCol--;
                        break;
                }

                if (char.IsDigit(playingField[moleRow, moleCol]))
                {
                    points += int.Parse(playingField[moleRow, moleCol].ToString());
                    playingField[moleRow, moleCol] = '-';
                }

                if (playingField[moleRow, moleCol] == 'S')
                {
                    playingField[moleRow, moleCol] = '-';

                    for (int row = 0; row < playingField.GetLength(0); row++)
                    {
                        for (int col = 0; col < playingField.GetLength(1); col++)
                        {
                            if (playingField[row, col] == 'S')
                            {
                                playingField[row, col] = '-';
                                moleRow = row;
                                moleCol = col;
                                points -= 3;
                                break;
                            }
                        }
                    }
                }

                command = Console.ReadLine();
            }

            playingField[moleRow, moleCol] = 'M';

            if (points >= 25)
            {
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {points} points.");
            }
            else
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {points} points.");
            }

            PrintPlayingField(playingField);
        }

        static void PrintPlayingField(char[,] playingField)
        {
            for (int row = 0; row < playingField.GetLength(0); row++)
            {
                for (int col = 0; col < playingField.GetLength(1); col++)
                {
                    Console.Write(playingField[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}