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

            var output = GetGoldenBooks(db);

            Console.WriteLine(output);
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books
                .Select(b => new
                {
                    b.BookId,
                    b.Title,
                    b.Copies,
                    EditionType = b.EditionType.ToString()
                })
                .ToList()
                .Where(b => b.EditionType == "Gold" && b.Copies < 5000)
                .OrderBy(b => b.BookId);

            var result = new StringBuilder();

            foreach (var b in books)
            {
                result.AppendLine(b.Title);
            }

            return result.ToString().Trim();
        }
    }
}


