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

            var output = GetBooksByPrice(db);

            Console.WriteLine(output);
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .ToList();

            var result = new StringBuilder();

            foreach (var b in books)
            {
                result.AppendLine($"{b.Title} - ${b.Price:F2}");
            }

            return result.ToString().Trim();
        }
    }
}


