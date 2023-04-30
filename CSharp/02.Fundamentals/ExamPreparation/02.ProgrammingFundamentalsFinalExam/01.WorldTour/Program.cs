using System;

namespace _01.WorldTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stops = Console.ReadLine();

            string input = Console.ReadLine();

            while (input != "Travel")
            {
                string[] data = input.Split(':', StringSplitOptions.RemoveEmptyEntries);
                string command = data[0];

                switch (command)
                {
                    case "Add Stop":
                        int index = int.Parse(data[1]);
                        string word = data[2];
                        if (index >= 0 && index <= stops.Length - 1)
                            stops = stops.Insert(index, word);
                        break;
                    case "Remove Stop":
                        int startIndex = int.Parse(data[1]);
                        int endIndex = int.Parse(data[2]);
                        if (startIndex >= 0 && endIndex < stops.Length)
                            stops = stops.Remove(startIndex, endIndex - startIndex + 1);
                        break;
                    case "Switch":
                        string oldString = data[1];
                        string newString = data[2];
                        stops = stops.Replace(oldString, newString);
                        break;
                }

                Console.WriteLine(stops);

                input = Console.ReadLine();
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
        }
    }
}
