using Newtonsoft.Json;

namespace CarDealer.DTOs.Import
{
    public class CarDTO
    {
        public CarDTO()
        {
            PartsId = new List<int>();
        }

        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;

        public long TraveledDistance { get; set; }

        public ICollection<int> PartsId { get; set; }
    }
}
