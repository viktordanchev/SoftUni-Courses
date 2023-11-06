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
            var output = GetBookTitlesContaining(db, input);
            
            Console.WriteLine(output);
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            var result = new StringBuilder();

            foreach (var book in books)
            {
                result.AppendLine(book);
            }

            return result.ToString().Trim();
        }
    }
}


