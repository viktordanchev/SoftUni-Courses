using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HouseParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());
            string[] operation = Console.ReadLine().Split();
            List<string> guestList = new List<string>();


            for (int i = 0; i < counter; i++)
            {
                if (operation.Length == 3)
                {
                    AddPersonToGuestList(operation, guestList);
                }
                else
                {
                    RemovePersonFromGuestList(operation, guestList);
                }

                if (i == counter - 1)
                {
                    break;
                }

                operation = Console.ReadLine().Split();
            }

            foreach (string name in guestList)
            {
                Console.WriteLine(name);
            }
            
        }

        static List<string> RemovePersonFromGuestList(string[] operation, List<string> guestList)
        {
            int counter = 0;

            foreach (string name in guestList)
            {
                if (name == operation[0])
                {
                    counter++;
                }
            }

            if (counter == 0)
            {
                Console.WriteLine($"{operation[0]} is not in the list!");
            }
            else
            {
                guestList.Remove(operation[0]);
            }

            return guestList;
        }

        static List<string> AddPersonToGuestList(string[] operation, List<string> guestList)
        {
            foreach (string name in guestList)
            {
                if (name == operation[0])
                {
                    Console.WriteLine($"{operation[0]} is already in the list!");
                    return guestList;
                }
            }

            guestList.Add(operation[0]);
            return guestList;
        }
    }
}
