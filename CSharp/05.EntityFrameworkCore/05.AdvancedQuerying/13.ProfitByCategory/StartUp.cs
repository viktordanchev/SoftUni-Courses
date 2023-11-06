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

            var output = GetTotalProfitByCategory(db);

            Console.WriteLine(output);
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories
                .GroupBy(c => new
                {
                    c.Name,
                    Sum = c.CategoryBooks.Sum(b => b.Book.Price * b.Book.Copies)
                })
                .Select(c => new
                {
                    c.Key.Name,
                    c.Key.Sum
                })
                .ToList()
                .OrderByDescending(c => c.Sum)
                .ThenBy(c => c.Name);

            var result = new StringBuilder();

            foreach (var c in categories)
            {
                result.AppendLine($"{c.Name} ${c.Sum:F2}");
            }

            return result.ToString().Trim();
        }
    }
}

