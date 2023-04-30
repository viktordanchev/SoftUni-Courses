using System.Collections.Generic;
using System.Text;

namespace ShoeStore
{
    public class ShoeStore
    {
        public ShoeStore(string name, int storageCapacity)
        {
            Name = name;
            StorageCapacity = storageCapacity;
            Shoes = new List<Shoe>();
        }

        public string Name { get; set; }
        public int StorageCapacity { get; set; }
        public List<Shoe> Shoes { get; set; }
        public int Count { get { return Shoes.Count; } }

        public string AddShoe(Shoe shoe)
        {
            if (Shoes.Count == StorageCapacity)
            {
                return "No more space in the storage room.";
            }

            Shoes.Add(shoe);
            return $"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.";
        }

        public int RemoveShoes(string material)
        {
            int removed = 0;

            for (int i = 0; i < Shoes.Count; i++)
            {
                if (Shoes[i].Material == material)
                {
                    Shoes.RemoveAt(i--);
                    removed++;
                }
            }

            return removed;
        }

        public List<Shoe> GetShoesByType(string type)
        {
            List<Shoe> shoes = new List<Shoe>();

            foreach (var currShoes in Shoes)
            {
                if (type.ToLower() == currShoes.Type.ToLower())
                {
                    shoes.Add(currShoes);
                }
            }

            return shoes;
        }

        public Shoe GetShoeBySize(double size)
        {
            foreach (var shoes in Shoes)
            {
                if (size == shoes.Size)
                {
                    return shoes;
                }
            }

            return null;
        }

        public string StockList(double size, string type)
        {
            StringBuilder sb = new StringBuilder();
            List<Shoe> matched = new();

            foreach (var shoes in Shoes)
            {
                if (shoes.Type == type && shoes.Size == size)
                {
                    matched.Add(shoes);
                }
            }

            if (matched.Count == 0)
            {
                return "No matches found!";
            }

            sb.AppendLine($"Stock list for size {size} - {type} shoes:");

            foreach (var shoes in matched)
            {
                sb.AppendLine(shoes.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}