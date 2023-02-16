using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        public Net(string material, int capacity)
        {
            Material = material;
            Capacity = capacity;
            Fish = new List<Fish>();
        }

        public List<Fish> Fish { get; set; }
        public int Count { get { return Fish.Count; } }
        public string Material { get; set; }
        public int Capacity { get; set; }

        public string AddFish(Fish fish)
        {
            if (string.IsNullOrWhiteSpace(fish.FishType))
            {
                return "Invalid fish.";
            }

            if (fish.Length <= 0 || fish.Weight <= 0)
            {
                return "Invalid fish.";
            }

            if (Count + 1 <= Capacity)
            {
                Fish.Add(fish);
                return $"Successfully added {fish.FishType} to the fishing net.";
            }

            return "Fishing net is full.";
        }

        public bool ReleaseFish(double weight)
        {
            foreach (var fish in Fish)
            {
                if (fish.Weight == weight)
                {
                    Fish.Remove(fish);
                    return true;
                }
            }

            return false;
        }

        public Fish GetFish(string fishType)
        {
            foreach (var fish in Fish)
            {
                if (fish.FishType == fishType)
                {
                    return fish;
                }
            }

            return null;
        }

        public Fish GetBiggestFish()
        {
            double length = double.MinValue;
            Fish longestFish = null;

            foreach (var fish in Fish)
            {
                if (fish.Length > length)
                {
                    length = fish.Length;
                    longestFish = fish;
                }
            }

            return longestFish;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Into the {Material}:");

            Fish = Fish.OrderByDescending(l => l.Length).ToList();

            foreach (var fish in Fish)
            {
                sb.AppendLine(fish.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}