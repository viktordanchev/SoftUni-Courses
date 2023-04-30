using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;

namespace _04.ListOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] operation = Console.ReadLine().Split();

            while (operation[0] != "End")
            {
                if (operation[0] == "Add")
                {
                    AddNumberToList(operation, numbers);
                }
                else if (operation[0] == "Insert")
                {
                    int index = int.Parse(operation[2]);

                    if (index >= numbers.Count || index < 0)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        InsertNumber(operation, numbers);
                    }
                }
                else if (operation[0] == "Remove")
                {
                    int index = int.Parse(operation[1]);

                    if (index >= numbers.Count || index < 0)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        RemoveNumberFromList(operation, numbers);
                    }
                }
                else if (operation[0] == "Shift")
                {
                    if (operation[1] == "left")
                    {
                        ShiftLeft(operation, numbers);
                    }
                    else if (operation[1] == "right")
                    {
                        ShiftRight(operation, numbers);
                    }
                }

                operation = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(' ', numbers));
        }

        static List<int> ShiftRight(string[] operation, List<int> numbers)
        {
            int count = int.Parse(operation[2]);

            for (int i = 0; i < count; i++)
            {
                numbers.Insert(0, numbers[numbers.Count - 1]);
                numbers.RemoveAt(numbers.Count-1);
            }

            return numbers;
        }

        static List<int> ShiftLeft(string[] operation, List<int> numbers)
        {
            int count = int.Parse(operation[2]);

            for (int i = 0; i < count; i++)
            {
                numbers.Add(numbers[0]);
                numbers.Remove(numbers[0]);
            }

            return numbers;
        }

        static List<int> RemoveNumberFromList(string[] operation, List<int> numbers)
        {
            int numToRemove = int.Parse(operation[1]);
            numbers.RemoveAt(numToRemove);
            return numbers;
        }

        static List<int> InsertNumber(string[] operation, List<int> numbers)
        {
            int numToInsert = int.Parse(operation[1]);
            int index = int.Parse(operation[2]);
            numbers.Insert(index, numToInsert);
            return numbers;
        }

        static List<int> AddNumberToList(string[] operation, List<int> numbers)
        {
            int numToAdd = int.Parse(operation[1]);
            numbers.Add(numToAdd);
            return numbers;
        }
    }
}
