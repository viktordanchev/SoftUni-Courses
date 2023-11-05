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
            var output = GetBooksByCategory(db, input);

            Console.WriteLine(output);
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            var books = context.BooksCategories
                .Where(bc => categories.Contains(bc.Category.Name.ToLower()))
                .Select(bc => bc.Book.Title)
                .OrderBy(b => b)
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
