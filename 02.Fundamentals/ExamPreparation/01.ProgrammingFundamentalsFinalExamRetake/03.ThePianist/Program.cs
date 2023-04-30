using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ThePianist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Piece> pieces = new List<Piece>();
            int numberOfPieces = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPieces; i++)
            {
                string[] data = Console.ReadLine()
                    .Split('|', StringSplitOptions.RemoveEmptyEntries);

                string theme = data[0];
                string composer = data[1];
                string key = data[2];

                pieces.Add(new Piece(theme, composer, key));
            }

            string input = Console.ReadLine();

            while (input != "Stop")
            {
                string[] data = input.Split('|', StringSplitOptions.RemoveEmptyEntries);
                string command = data[0];
                string theme = data[1];

                switch (command)
                {
                    case "Add":
                        string composer = data[2];
                        string key = data[3];

                        if (pieces.Any(p => p.Theme == theme))
                        {
                            Console.WriteLine($"{theme} is already in the collection!");
                            input = Console.ReadLine();
                            continue;
                        }

                        pieces.Add(new Piece(theme, composer, key));
                        Console.WriteLine($"{theme} by {composer} in {key} added to the collection!");
                        break;
                    case "Remove":
                        var piece = pieces.FirstOrDefault(p => p.Theme == theme);

                        if (piece == null)
                        {
                            Console.WriteLine($"Invalid operation! {theme} does not exist in the collection.");
                            input = Console.ReadLine(); 
                            continue;
                        }

                        pieces.Remove(piece);
                        Console.WriteLine($"Successfully removed {theme}!");
                        break;
                    case "ChangeKey":
                        string newKey = data[2];

                        piece = pieces.FirstOrDefault(p => p.Theme == theme);

                        if (piece == null)
                        {
                            Console.WriteLine($"Invalid operation! {theme} does not exist in the collection.");
                            input = Console.ReadLine();
                            continue;
                        }

                        piece.Key = newKey;
                        Console.WriteLine($"Changed the key of {theme} to {newKey}!");
                        break;
                }

                input = Console.ReadLine();
            }

            foreach (var piece in pieces)
            {
                Console.WriteLine(piece);
            }
        }
    }

    class Piece
    {
        public Piece(string theme, string composer, string key)
        {
            Key = key;
            Composer = composer;
            Theme = theme;
        }

        public string Key { get; set; }
        public string Composer { get; set; }
        public string Theme { get; set; }

        public override string ToString()
            => $"{Theme} -> Composer: {Composer}, Key: {Key}";
    }
}