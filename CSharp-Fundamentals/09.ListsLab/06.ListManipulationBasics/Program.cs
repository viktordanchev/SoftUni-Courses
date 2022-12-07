using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ListManipulationBasics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> result = new List<int>();
            string[] command = Console.ReadLine().Split();

            while (command[0] != "end")
            {
                if (command[0] == "Add")
                {
                    result = AddNumberToList(command, numbers);
                }
                else if (command[0] == "Remove")
                {
                    result = RemoveNumberFromList(command, numbers);
                }
                else if (command[0] == "RemoveAt")
                {
                    result = RemoveNumberArAGivenIndex(command, numbers);
                }
                else if (command[0] == "Insert")
                {
                    result = InsertNumber(command, numbers);
                }

                command = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(' ', result));
        }

        static List<int> InsertNumber(string[] command, List<int> numbers)
        {
            int numToInsert = int.Parse(command[1]);
            int index = int.Parse(command[2]);
            numbers.Insert(index, numToInsert);
            return numbers;
        }

        static List<int> RemoveNumberArAGivenIndex(string[] command, List<int> numbers)
        {
            int numToRemove = int.Parse(command[1]);
            numbers.RemoveAt(numToRemove);
            return numbers;
        }
    

        static List<int> RemoveNumberFromList(string[] command, List<int> numbers)
        {
            int numToRemove = int.Parse(command[1]);
            numbers.Remove(numToRemove);
            return numbers;
        }

        static List<int> AddNumberToList(string[] command, List<int> numbers)
        {
            int numToAdd = int.Parse(command[1]);
            numbers.Add(numToAdd);
            return numbers;
        }
    }
}
