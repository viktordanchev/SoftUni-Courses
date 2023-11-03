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

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs
                .Include(s => s.SongPerformers)
                .ToList()
                .Where(s => s.Duration.TotalSeconds > duration)
                .OrderBy(s => s.Name)
                .ThenBy(s => s.Writer.Name);

            var result = new StringBuilder();
            var songNumber = 1;

            foreach (var s in songs)
            {
                result.AppendLine($"-Song #{songNumber++}");
                result.AppendLine($"---SongName: {s.Name}");
                result.AppendLine($"---Writer: {s.Writer.Name}");

                if (s.SongPerformers.Count > 0)
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
