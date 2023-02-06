using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonTrainer
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "Tournament")
            {
                string trainerName = input[0];
                string pokemonName = input[1];
                string pokemonElement = input[2];
                int pokemonHealth = int.Parse(input[3]);

                Pokemon pokemon = new Pokemon();
                pokemon.Name = pokemonName;
                pokemon.Element = pokemonElement;
                pokemon.Health = pokemonHealth;

                if (trainers.Count == 0)
                {
                    Trainer trainer = new Trainer();
                    trainer.Name = trainerName;
                    trainer.CollectionOfPokemons.Add(pokemon);

                    trainers.Add(trainer);

                    input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    continue;
                }

                bool isExisit = false;
                foreach (var currTrainer in trainers)
                {
                    if (currTrainer.Name == trainerName)
                    {
                        currTrainer.CollectionOfPokemons.Add(pokemon);
                        isExisit = true;
                        break;
                    }
                }

                if (!isExisit)
                {
                    Trainer trainer = new Trainer();
                    trainer.Name = trainerName;
                    trainer.CollectionOfPokemons.Add(pokemon);

                    trainers.Add(trainer);
                }

                input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                bool doesItHave;

                switch (command)
                {
                    case "Fire":
                        foreach (var trainer in trainers)
                        {
                            doesItHave = false;

                            foreach (var pokemon in trainer.CollectionOfPokemons)
                            {
                                if (pokemon.Element == "Fire")
                                {
                                    doesItHave = true;
                                }
                            }

                            if (doesItHave)
                            {
                                trainer.NumberOfBadges++;
                                continue;
                            }

                            foreach (var pokemon in trainer.CollectionOfPokemons)
                            {
                                if (pokemon.Health - 10 <= 0)
                                {
                                    trainer.CollectionOfPokemons.Remove(pokemon);
                                    break;
                                }

                                pokemon.Health -= 10;
                            }
                        }
                        break;
                    case "Water":
                        foreach (var trainer in trainers)
                        {
                            doesItHave = false;

                            foreach (var pokemon in trainer.CollectionOfPokemons)
                            {
                                if (pokemon.Element == "Water")
                                {
                                    doesItHave = true;
                                }
                            }

                            if (doesItHave)
                            {
                                trainer.NumberOfBadges++;
                                continue;
                            }

                            foreach (var pokemon in trainer.CollectionOfPokemons)
                            {
                                if (pokemon.Health - 10 <= 0)
                                {
                                    trainer.CollectionOfPokemons.Remove(pokemon);
                                    break;
                                }

                                pokemon.Health -= 10;
                            }
                        }
                        break;
                    case "Electricity":
                        foreach (var trainer in trainers)
                        {
                            doesItHave = false;

                            foreach (var pokemon in trainer.CollectionOfPokemons)
                            {
                                if (pokemon.Element == "Electricity")
                                {
                                    doesItHave = true;
                                }
                            }

                            if (doesItHave)
                            {
                                trainer.NumberOfBadges++;
                                continue;
                            }

                            foreach (var pokemon in trainer.CollectionOfPokemons)
                            {
                                if (pokemon.Health - 10 <= 0)
                                {
                                    trainer.CollectionOfPokemons.Remove(pokemon);
                                    break;
                                }

                                pokemon.Health -= 10;
                            }
                        }
                        break;
                }

                command = Console.ReadLine();
            }

            foreach (var trainer in trainers.OrderByDescending(t => t.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.CollectionOfPokemons.Count}");
            }
        }
    }
}