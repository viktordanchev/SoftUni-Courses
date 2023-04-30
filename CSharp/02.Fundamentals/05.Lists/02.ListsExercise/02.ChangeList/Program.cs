using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ChangeList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] command = Console.ReadLine().Split();

            while (command[0] != "end")
            {
                if (command[0] == "Delete")
                {
                    DeleteCurrNumInList(command, numbers);
                }
                else if (command[0] == "Insert")
                {
                    InsertCurrNumInList(command, numbers);
                }

                command= Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(' ', numbers));
        }

        static List<int> InsertCurrNumInList(string[] command, List<int> numbers)
        {
            int element = int.Parse(command[1]);
            int position = int.Parse(command[2]);
            numbers.Insert(position, element);

            return numbers;
        }

        static List<int> DeleteCurrNumInList(string[] command, List<int> numbers)
        {
            int element = int.Parse(command[1]);

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == element)
                {
                    numbers.RemoveAt(i);
                    i--;
                }
            }

            return numbers;
        }
    }
}
