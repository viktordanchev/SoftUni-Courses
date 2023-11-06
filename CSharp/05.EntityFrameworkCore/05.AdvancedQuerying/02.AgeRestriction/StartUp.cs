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
            var output = GetBooksByAgeRestriction(db, input);
            
            Console.WriteLine(output);
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var books = context.Books
                .Select(b => new {
                    b.Title,
                    AgeRestriction = b.AgeRestriction.ToString().ToLower()
                })
                .ToList()
                .Where(b => b.AgeRestriction == command.ToLower())
                .OrderBy(b => b.Title);

            var result = new StringBuilder();

            foreach (var b in books) 
            {
                result.AppendLine(b.Title);
            }

            return result.ToString().Trim();
        }
    }
}


