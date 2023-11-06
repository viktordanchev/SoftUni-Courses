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

            var output = CountCopiesByAuthor(db);

            Console.WriteLine(output);
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                .Select(a => new
                {
                    FullName = a.FirstName + " " + a.LastName,
                    BooksCount = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.BooksCount)
                .ToList();

            var result = new StringBuilder();

            foreach (var a in authors)
            {
                result.AppendLine($"{a.FullName} - {a.BooksCount}");
            }

            return result.ToString().Trim();
        }
    }
}

