namespace MusicHub
{
    using System;
    using System.Text;
    using _01.MusicHubDatabase.Data.Models;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            Console.WriteLine(ExportAlbumsInfo(context, 9));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Albums
                .Where(a => a.ProducerId == producerId)
                .ToList()
                .Select(a => new
                {
                    a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy"),
                    Producer = a.Producer.Name,
                    Songs = a.Songs
                    .OrderByDescending(s => s.Name)
                    .ThenBy(s => s.Writer.Name),
                    a.Price
                })
                .OrderByDescending(a => a.Price);

            var result = new StringBuilder();
            var songNumber = 1;

            foreach (var a in albums)
            {
                result.AppendLine($"-AlbumName: {a.Name}");
                result.AppendLine($"-ReleaseDate: {a.ReleaseDate}");
                result.AppendLine($"-ProducerName: {a.Producer}");
                result.AppendLine($"-Songs:");


                foreach (var s in a.Songs)
                {
                    result.AppendLine($"---#{songNumber++}");
                    result.AppendLine($"---SongName: {s.Name}");
                    result.AppendLine($"---Price: {s.Price:F2}");
                    result.AppendLine($"---Writer: {s.Writer.Name}");
                }

                songNumber = 1;
                result.AppendLine($"-AlbumPrice: {a.Price:F2}");
            }

            return result.ToString().Trim();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            throw new NotImplementedException();
        }
    }
}
