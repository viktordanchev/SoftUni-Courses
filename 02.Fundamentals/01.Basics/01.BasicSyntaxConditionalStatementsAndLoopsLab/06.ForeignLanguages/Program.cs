using System;

namespace _06.ForeignLanguages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string countryName = Console.ReadLine();

            if (countryName == "England" || countryName == "USA")
            {
                Console.WriteLine("English");
            }
            else if (countryName == "Spain" || countryName == "Argentina" || countryName == "Mexico")
            {
                Console.WriteLine("Spanish");
            }
            else
            {
                Console.WriteLine("unknown");
            }
        }
    }
}
