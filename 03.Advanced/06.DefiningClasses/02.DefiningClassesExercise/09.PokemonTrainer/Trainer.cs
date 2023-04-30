using System.Collections.Generic;

namespace _09.PokemonTrainer
{
    public class Trainer
    {
        public string Name { get; set; }
        public int NumberOfBadges { get; set; }
        public List<Pokemon> CollectionOfPokemons { get; set; }

        public Trainer()
        {
            CollectionOfPokemons = new List<Pokemon>();
        }
    }
}
