namespace MusicHub
{
    using System.Text;
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
            var songs = context.Songs
                .Include(s => s.SongPerformers)
                .Where(s => (s.Duration.Hours + s.Duration.Minutes) * 60 + s.Duration.Seconds > duration)
                .OrderBy(s => s.Name)
                .ThenBy(s => s.Writer.Name);

            var result = new StringBuilder();
            var songNumber = 1;

            foreach (var s in songs)
            {
                result.AppendLine($"-Song #{songNumber++}");
                result.AppendLine($"---SongName: {s.Name}");
                result.AppendLine($"---Writer: {s.Writer.Name}");

                if(s.SongPerformers.Count > 0)
                {
                    var performers = s.SongPerformers
                        .OrderBy(sp => sp.Performer.FirstName)
                        .ThenBy(sp => sp.Performer.LastName);

                    foreach (var p in performers)
                    {
                        var fullName = p.Performer.FirstName + " " + p.Performer.LastName;

                        result.AppendLine($"---Performer: {fullName}");
                    }
                }

                result.AppendLine($"---AlbumProducer: {s.Album.Producer.Name}");
                result.AppendLine($"---Duration: {s.Duration.ToString("c")}");
            }

            return result.ToString().Trim();
        }
    }
}
