using System;

namespace _05.Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string reversed = "";

            for (int i = username.Length - 1; i >= 0; i--)
            {
                reversed += username[i];
            }

            for (int j = 1; j <= 4; j++)
            {
                string input = Console.ReadLine();

                if (input != reversed && j < 4)
                {
                    Console.WriteLine("Incorrect password. Try again.");
                }
                else if (input == reversed)
                {
                    Console.WriteLine($"User {username} logged in.");
                    break;
                }

                if (j == 4)
                {
                    Console.WriteLine($"User {username} blocked!");
                }
            }
        }
    }
}
