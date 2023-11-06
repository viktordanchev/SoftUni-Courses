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
            var categories = context.BooksCategories
                .Select(bc => new
                {
                    CategoryName = bc.Category.Name,
                    Sum = bc.Book.Price * bc.Book.Copies
                })
                .GroupBy(c => new
                {
                    Category = c.CategoryName,
                    SumC = c.Sum
                })
                .OrderByDescending(c => c.Key.SumC)
                .OrderBy(c => c.Key.Category)
                .ToList();

            var result = new StringBuilder();

            foreach (var c in categories)
            {
                result.AppendLine($"{c.Key.Category} ${c.Key.SumC:F2}");
            }

            return result.ToString().Trim();
        }
    }
}

