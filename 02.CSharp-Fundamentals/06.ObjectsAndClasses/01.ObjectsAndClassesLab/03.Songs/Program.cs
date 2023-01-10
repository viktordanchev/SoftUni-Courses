using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace _03.Songs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfSongs = int.Parse(Console.ReadLine());
            List<Song> songs = new List<Song>();

            for (int i = 0; i < numberOfSongs; i++)
            {
                string[] data = Console.ReadLine().Split('_');

                Song song = new Song();

                song.TypeList = data[0];
                song.Name = data[1];
                song.Time = data[2];

                songs.Add(song);
            }

            string typeList = Console.ReadLine();
            PrintAllSongsFromCurrType(typeList, songs);
        }

        static void PrintAllSongsFromCurrType(string typeList, List<Song> songs)
        {
            if (typeList == "all")
            {
                foreach (Song song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                foreach (Song song in songs)
                {
                    if (song.TypeList == typeList)
                    {
                        Console.WriteLine(song.Name);
                    }
                }
            }
        }
    }

    class Song
    {
        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
    }
}
