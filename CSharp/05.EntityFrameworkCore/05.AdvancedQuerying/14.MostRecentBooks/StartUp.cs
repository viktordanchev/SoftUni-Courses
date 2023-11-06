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

            var output = GetMostRecentBooks(db);

            Console.WriteLine(output);
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    c.Name,
                    Books = c.CategoryBooks
                    .Select(b => new
                    {
                        Title = b.Book.Title,
                        Year = b.Book.ReleaseDate.Value.Year
                    })
                    .OrderByDescending(b => b.Year)
                    .Take(3)
                    .ToList()
                })
                .ToList();

            var result = new StringBuilder();
            
            foreach (var c in categories)
            {
                result.AppendLine($"--{c.Name}");

                if(c.Books.Count > 0)
                {
                    foreach (var b in c.Books)
                    {
                        result.AppendLine($"{b.Title} ({b.Year})");
                    }
                }
            }

            return result.ToString().Trim();
        }
    }
}

