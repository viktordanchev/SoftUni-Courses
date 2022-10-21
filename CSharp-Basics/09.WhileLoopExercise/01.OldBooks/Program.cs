using System;

namespace _01.OldBooks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string book = Console.ReadLine();
            int counter = 0;

            while (true)
            {
                string search = Console.ReadLine();

                if (search == book)
                {
                    Console.WriteLine($"You checked {counter} books and found it.");
                    break;
                }

                if (search == "No More Books")
                {
                    Console.WriteLine("The book you search is not here!");
                    Console.WriteLine($"You checked {counter} books.");
                    break;
                }
                counter++;
            }
        }
    }
}
