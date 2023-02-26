using System;

namespace _05.MovieRatings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countMovies = int.Parse(Console.ReadLine());

            double maxRating = double.MinValue;
            double minRating = double.MaxValue;
            double allRating = 0;

            string filmMax = "";
            string filmMin = "";

            for (int i = 1; i <= countMovies; i++)
            {
                string movie = Console.ReadLine();
                double rating = double.Parse(Console.ReadLine());

                if (rating > maxRating)
                {
                    maxRating = rating;
                    filmMax = movie;
                }

                if (rating < minRating)
                {
                    minRating = rating;
                    filmMin = movie;
                }

                allRating += rating;
            }

            Console.WriteLine($"{filmMax} is with highest rating: {maxRating:f1}");
            Console.WriteLine($"{filmMin} is with lowest rating: {minRating:f1}");
            Console.WriteLine($"Average rating: {allRating / countMovies:f1}");
        }
    }
}
