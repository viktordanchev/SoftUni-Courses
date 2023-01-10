using System;

namespace _01.AdvertisementMessage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                string currPhrase = ReturnPhrase();
                string currEvent = ReturnEvent();
                string currAuthor = ReturnAuthor();
                string currCity = ReturnCity();

                Console.WriteLine($"{currPhrase} {currEvent} {currAuthor} – {currCity}.");
            }
        }

        static string ReturnCity()
        {
            string[] cities = { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            Random random = new Random();
            int randomIndex = random.Next(0, cities.Length);

            return cities[randomIndex];
        }

        static string ReturnAuthor()
        {
            string[] authors = { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };

            Random random = new Random();
            int randomIndex = random.Next(0, authors.Length);

            return authors[randomIndex];
        }

        static string ReturnEvent()
        {
            string[] events = {"Now I feel good.", "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.", "I feel great!"};

            Random random = new Random();
            int randomIndex = random.Next(0, events.Length);

            return events[randomIndex];
        }

        static string ReturnPhrase()
        {
            string[] phrases = {"Excellent product.", "Such a great product.", "I always use that product.",
                "Best product of its category.", "Exceptional product.", "I can't live without this product."};

            Random random = new Random();
            int randomIndex = random.Next(0, phrases.Length);

            return phrases[randomIndex];
        }
    }
}
