using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            string input = Console.ReadLine();
            while (input != "Travel")
            {
                string[] data = input.Split(':', StringSplitOptions.RemoveEmptyEntries);
                string command = data[0];

                switch (command)
                {
                    case "Add Stop":
                        int index = int.Parse(data[1]);
                        string value = data[2];
                        word = word.Insert(index, value);
                        break;
                    case "Remove Stop":
                        int startIndex = int.Parse(data[1]);
                        int endIndex = int.Parse(data[2]);
                        if (startIndex > 0 && endIndex <= word.Length)
                        {
                            word = word.Remove(startIndex, endIndex - startIndex + 1);
                        }
                        break;
                    case "Switch":
                        string oldString = data[1];
                        string newString = data[2];
                        word = word.Replace(oldString, newString);
                        break;
                }

                Console.WriteLine(word);
                input = Console.ReadLine();
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {word}");
        }
    }
}
