namespace BookShop
{
    using Data;
    using Initializer;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);
            
            var input = Console.ReadLine();
            var output = GetBooksReleasedBefore(db, input);
            
            Console.WriteLine(output);
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate < DateTime.Parse(date))
                .OrderByDescending(b => b.ReleaseDate)
                .ToList();

            var result = new StringBuilder();

            foreach (var b in books)
            {
                result.AppendLine($"{b.Title} - {b.EditionType} - ${b.Price:F2}");
            }

            return result.ToString().Trim();
        }
    }
}


