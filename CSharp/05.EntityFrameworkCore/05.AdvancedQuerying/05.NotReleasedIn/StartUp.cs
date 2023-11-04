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

            var input = int.Parse(Console.ReadLine());
            var output = GetBooksNotReleasedIn(db, input);

            Console.WriteLine(output);
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            var result = new StringBuilder();

            foreach (var b in books)
            {
                result.AppendLine(b);
            }

            return result.ToString().Trim();
        }
    }
}


