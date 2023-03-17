using System;
using System.Collections.Generic;
using System.Linq;

namespace Cards
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Card> deck = new();

            string[] cardsInfo = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < cardsInfo.Length; i++)
            {
                string[] cardInfo = cardsInfo[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string face = cardInfo[0];
                string suit = cardInfo[1];

                try
                {
                    Card card = new(face, suit);
                    deck.Add(card);
                }
                catch (ArgumentException ex)
                { 
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(string.Join(' ', deck));
        }
    }

    class Card
    {
        private string face;
        private string suit;

        public Card(string face, string suit)
        {
            Face = face;
            Suit = suit;
        }

        private string Face 
        { 
            get => face;
            set
            {
                List<string> validFaces = new() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

                if (!validFaces.Any(f => f == value))
                {
                    throw new ArgumentException("Invalid card!");
                }

                face = value;
            }
        }
        private string Suit
        {
            get => suit;
            set
            {
                List<string> validSuits = new() { "S", "H", "D", "C" };

                if (!validSuits.Any(s => s == value))
                {
                    throw new ArgumentException("Invalid card!");
                }

                switch (value)
                {
                    case "S":
                        suit = "\u2660";
                        break;
                    case "H":
                        suit = "\u2665";
                        break;
                    case "D":
                        suit = "\u2666";
                        break;
                    case "C":
                        suit = "\u2663";
                        break;
                }
            }
        }

        public override string ToString()
        => $"[{Face}{Suit}]";
    }
}
