using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.ListManipulationAdvanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> result = new List<int>();
            string[] command = Console.ReadLine().Split();
            int counterForChanges = 0;

            while (command[0] != "end")
            {
                if (command[0] == "Add")
                {
                    result = AddNumberToList(command, numbers);
                    counterForChanges++;
                }
                else if (command[0] == "Remove")
                {
                    result = RemoveNumberFromList(command, numbers);
                    counterForChanges++;
                }
                else if (command[0] == "RemoveAt")
                {
                    result = RemoveNumberAtAGivenIndex(command, numbers);
                    counterForChanges++;
                }
                else if (command[0] == "Insert")
                {
                    result = InsertNumber(command, numbers);
                    counterForChanges++;
                }
                else if (command[0] == "Contains")
                {
                    bool isListContainsNum = CheckIfListContainsCurrNum(command, numbers);

                    if (isListContainsNum)
                    {
                        Console.WriteLine("Yes");
                    }
                    else
                    {
                        Console.WriteLine("No such number");
                    }
                }
                else if (command[0] == "PrintEven")
                {
                    List<int> evenNumbers = PrintOnlyEvenNums(numbers);
                    Console.WriteLine(string.Join(' ', evenNumbers));
                }
                else if (command[0] == "PrintOdd")
                {
                    List<int> oddNumbers = PrintOnlyOddNums(numbers);
                    Console.WriteLine(string.Join(' ', oddNumbers));
                }
                else if (command[0] == "GetSum")
                {
                    int sum = GetSumOfAllNumbers(numbers);
                    Console.WriteLine(sum);
                }
                else if (command[0] == "Filter")
                {
                    List<int> filtredList = GetFiltred(command, numbers);
                    Console.WriteLine(string.Join(' ', filtredList));
                }

                command = Console.ReadLine().Split();
            }

            if (counterForChanges >= 1)
            {
                Console.WriteLine(string.Join(' ', result));
            }
        }

        static List<int> InsertNumber(string[] command, List<int> numbers)
        {
            int numToInsert = int.Parse(command[1]);
            int index = int.Parse(command[2]);
            numbers.Insert(index, numToInsert);
            return numbers;
        }

        static List<int> RemoveNumberAtAGivenIndex(string[] command, List<int> numbers)
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

        static List<int> GetFiltred(string[] command, List<int> numbers)
        {
            List<int> filtredNums = new List<int>();
            int numberToFilter = int.Parse(command[2]);

            switch (command[1])
            {
                case "<":
                    foreach (int number in numbers)
                    {
                        if (number < numberToFilter)
                        {
                            filtredNums.Add(number);
                        }
                    }
                    break;
                case ">":
                    foreach (int number in numbers)
                    {
                        if (number > numberToFilter)
                        {
                            filtredNums.Add(number);
                        }
                    }
                    break;
                case ">=":
                    foreach (int number in numbers)
                    {
                        if (number >= numberToFilter)
                        {
                            filtredNums.Add(number);
                        }
                    }
                    break;
                case "<=":
                    foreach (int number in numbers)
                    {
                        if (number <= numberToFilter)
                        {
                            filtredNums.Add(number);
                        }
                    }
                    break;

            }

            return filtredNums;
        }

        static int GetSumOfAllNumbers(List<int> numbers)
        {
            int sum = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];
            }

            return sum;
        }

        static List<int> PrintOnlyOddNums(List<int> numbers)
        {
            List<int> oddNumbers = new List<int>();

            foreach (int number in numbers)
            {
                if (number % 2 == 1)
                {
                    oddNumbers.Add(number);
                }
            }

            return oddNumbers;
        }

        static List<int> PrintOnlyEvenNums(List<int> numbers)
        {
            List<int> evenNumbers = new List<int>();

            foreach (int number in numbers)
            {
                if (number % 2 == 0)
                {
                    evenNumbers.Add(number);
                }
            }

            return evenNumbers;
        }

        static bool CheckIfListContainsCurrNum(string[] command, List<int> numbers)
        {
            int numToCheck = int.Parse(command[1]);
            foreach (int number in numbers)
            {
                if (number == numToCheck)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
