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
            var output = GetBooksByAuthor(db, input);

            Console.WriteLine(output);
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    b.Title,
                    FullName = b.Author.FirstName + " " + b.Author.LastName
                })
                .ToList();

            var result = new StringBuilder();

            foreach (var b in books)
            {
                result.AppendLine($"{b.Title} ({b.FullName})");
            }

            return result.ToString().Trim();
        }
    }
}

