using System;

namespace _04.VacationBooksList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPagesInABook = int.Parse(Console.ReadLine());
            int pagesReadPerHour = int.Parse(Console.ReadLine());
            int daysToReadABook = int.Parse(Console.ReadLine());

            int readAllBook = numberOfPagesInABook / pagesReadPerHour;
            int numberOfHours = readAllBook / daysToReadABook;

            Console.WriteLine(numberOfHours);
        }
    }
}
