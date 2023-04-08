using System;
using System.Runtime.Intrinsics.Arm;

namespace _01.TheImitationGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string input = Console.ReadLine();
            while (input != "Decode")
            {
                string[] data = input.Split('|', StringSplitOptions.RemoveEmptyEntries);
                string command = data[0];

                switch (command)
                {
                    case "Move":
                        int numberOfLetters = int.Parse(data[1]);
                        message = Move(message, numberOfLetters);
                        break;
                    case "Insert":
                        int index = int.Parse(data[1]);
                        string value = data[2];
                        message = message.Insert(index, value);
                        break;
                    case "ChangeAll":
                        string substring = data[1];
                        string replacement = data[2];
                        message = message.Replace(substring, replacement);
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"The decrypted message is: {message}");
        }

        static string Move(string message, int numberOfLetters)
        {
            string rem = message.Substring(0, numberOfLetters);
            message = message.Remove(0, numberOfLetters);
            message = message.Insert(message.Length, rem);

            return message;
        }
    }
}
