using System;

namespace _02.NavyBattle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] battlefield = new char[size, size];

            int submarineRow = 0;
            int submarineCol = 0;

            for (int row = 0; row < size; row++)
            {
                string data = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    battlefield[row, col] = data[col];

                    if (data[col] == 'S')
                    {
                        submarineRow = row;
                        submarineCol = col;
                    }
                }
            }

            string command = Console.ReadLine();
            int submarineDamage = 0;
            int destroyedCruisers = 0;

            while (true)
            {
                battlefield[submarineRow, submarineCol] = '-';

                if (submarineDamage > 2)
                {
                    Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{submarineRow}, {submarineCol}]!");
                    battlefield[submarineRow, submarineCol] = 'S';
                    break;
                }
                else if (destroyedCruisers == 3)
                {
                    Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
                    battlefield[submarineRow, submarineCol] = 'S';
                    break;
                }

                if (command == "up")
                {
                    submarineRow--;
                }
                else if (command == "down")
                {
                    submarineRow++;
                }
                else if (command == "right")
                {
                    submarineCol++;
                }
                else if (command == "left")
                {
                    submarineCol--;
                }

                if (battlefield[submarineRow, submarineCol] == '*')
                {
                    submarineDamage++;
                    battlefield[submarineRow, submarineCol] = '-';
                }
                else if (battlefield[submarineRow, submarineCol] == 'C')
                {
                    destroyedCruisers++;
                    battlefield[submarineRow, submarineCol] = '-';
                }

                command = Console.ReadLine();
            }

            PrintBattlefield(battlefield);
        }

        static void PrintBattlefield(char[,] battlefield)
        {
            for (int row = 0; row < battlefield.GetLength(0); row++)
            {
                for (int col = 0; col < battlefield.GetLength(1); col++)
                {
                    Console.Write(battlefield[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}