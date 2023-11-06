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
            var output = GetAuthorNamesEndingIn(db, input);
            
            Console.WriteLine(output);
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new
                {
                    FullName = a.FirstName + " " + a.LastName
                })
                .OrderBy(a => a.FullName)
                .ToList();

            var result = new StringBuilder();

            foreach (var a in authors)
            {
                result.AppendLine(a.FullName);
            }

            return result.ToString().Trim();
        }
    }
}


