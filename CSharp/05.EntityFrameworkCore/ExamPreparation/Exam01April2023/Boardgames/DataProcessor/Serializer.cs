namespace Boardgames.DataProcessor
{
    using Boardgames.Data;
    using Boardgames.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {
            var creators = context.Creators
                .Where(c => c.Boardgames.Count > 0)
                .Select(c => new CreatorDto()
                {
                    BoardgamesCount = c.Boardgames.Count,
                    CreatorName = string.Concat(c.FirstName, " ", c.LastName),
                    Boardgames = c.Boardgames
                    .Select(b => new BoardgameDto()
                    {
                        BoardgameName = b.Name,
                        BoardgameYearPublished = b.YearPublished
                    })
                    .OrderBy(b => b.BoardgameName)   
                    .ToArray()
                })
                .OrderByDescending(c => c.Boardgames.Length)
                .ThenBy(c => c.CreatorName)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(CreatorDto[]), new XmlRootAttribute("Creators"));
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            XmlWriterSettings settings = new()
            {
                Indent = true
            };

            StringBuilder sb = new();
            using var stringWriter = new StringWriter(sb);
            using var xmlWriter = XmlWriter.Create(stringWriter, settings);

            xmlSerializer.Serialize(xmlWriter, creators, namespaces);
            return sb.ToString().TrimEnd();
        }

        public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
        {
            var sellers = context.Sellers
                .Where(s => s.BoardgamesSellers
                .Any(b => b.Boardgame.YearPublished >= year && b.Boardgame.Rating <= rating))
                .Select(s => new
                {
                    s.Name,
                    s.Website,
                    Boardgames = s.BoardgamesSellers
                    .Where(b => b.Boardgame.YearPublished >= year && b.Boardgame.Rating <= rating)
                    .Select(bs => new
                    {
                        bs.Boardgame.Name,
                        bs.Boardgame.Rating,
                        bs.Boardgame.Mechanics,
                        Category = bs.Boardgame.CategoryType.ToString(),
                    })
                    .OrderByDescending(b => b.Rating)
                    .ToArray()
                })
                .OrderByDescending(s => s.Boardgames.Length)
                .ThenBy(s => s.Name)
                .Take(5)
                .ToArray();

            var sellersJson = JsonConvert.SerializeObject(sellers, Newtonsoft.Json.Formatting.Indented);

            return sellersJson;
        }
    }
}