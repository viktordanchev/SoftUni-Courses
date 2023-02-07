using System;
using System.Runtime.CompilerServices;

namespace _07.KnightGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] board = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                string data = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    board[row, col] = data[col];
                }
            }

            if (size < 3)
            {
                Console.WriteLine(0);
                return;
            }

            int knightsRemoved = 0;

            while (true)
            {
                int countMostAttacking = 0;
                int rowMostAttacking = 0;
                int colMostAttacking = 0;

                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        if (board[row, col] == 'K')
                        {
                            int attackedKnights = Attacking(board, row, col, size);

                            if (countMostAttacking < attackedKnights)
                            {
                                countMostAttacking = attackedKnights;
                                rowMostAttacking = row;
                                colMostAttacking = col;
                            }
                        }
                    }
                }

                if (countMostAttacking == 0)
                {
                    break;
                }
                else
                {
                    board[rowMostAttacking, colMostAttacking] = '0';
                    knightsRemoved++;
                }
            }

            Console.WriteLine(knightsRemoved);
        }

        static int Attacking(char[,] board, int row, int col, int size)
        {
            int count = 0;

            if (row + 2 <= size - 1 && col + 1 <= size - 1 && board[row + 2, col + 1] == 'K')
            {
                count++;
            }
            if (row + 2 <= size - 1 && col - 1 >= 0 && board[row + 2, col - 1] == 'K')
            {
                count++;
            }
            if (row - 2 >= 0 && col + 1 <= size - 1 && board[row - 2, col + 1] == 'K')
            {
                count++;
            }
            if (row - 2 >= 0 && col - 1 >= 0 && board[row - 2, col - 1] == 'K')
            {
                count++;
            }
            if (row + 1 <= size - 1 && col + 2 <= size - 1 && board[row + 1, col + 2] == 'K')
            {
                count++;
            }
            if (row + 1 <= size - 1 && col - 2 >= 0 && board[row + 1, col - 2] == 'K')
            {
                count++;
            }
            if (row - 1 >= 0 && col + 2 <= size - 1 && board[row - 1, col + 2] == 'K')
            {
                count++;
            }
            if (row - 1 >= 0 && col - 2 >= 0 && board[row - 1, col - 2] == 'K')
            {
                count++;
            }

            return count;
        }
    }
}