using System;

namespace _01.Warrior_sQuest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string skill = Console.ReadLine();

            string input = Console.ReadLine();
            while (input != "For Azeroth")
            {
                string[] data = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = data[0];

                if (command == "Target")
                    command = data[0] + " " + data[1];

                switch (command)
                {
                    case "GladiatorStance":
                        skill = skill.ToUpper();

                        Console.WriteLine(skill);
                        break;
                    case "DefensiveStance":
                        skill = skill.ToLower();

                        Console.WriteLine(skill);
                        break;
                    case "Dispel":
                        int index = int.Parse(data[1]);
                        string letter = data[2];

                        if (index >= 0 && index <= skill.Length - 1)
                        {
                            skill = skill.Remove(index, 1);
                            skill = skill.Insert(index, letter);
                            Console.WriteLine("Success!");
                        }
                        else
                        {
                            Console.WriteLine("Dispel too weak.");
                        }
                        break;
                    case "Target Change":
                        string first = data[2];
                        string second = data[3];

                        skill = skill.Replace(first, second);

                        Console.WriteLine(skill);
                        break;
                    case "Target Remove":
                        string substring = data[2];
                        int originalLenght = skill.Length;

                        skill = skill.Replace(substring, string.Empty);

                        if (originalLenght > skill.Length)
                            Console.WriteLine(skill);
                        break;
                    default:
                        Console.WriteLine("Command doesn't exist!");
                        break;
                }

                input = Console.ReadLine();
            }
        }
    }
}
