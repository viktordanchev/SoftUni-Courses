namespace CarDealer.DTOs.Import
{
    public class CustomerDTO
    {
        public string Name { get; set; } = null!;

        public DateTime BirthDate { get; set; }

        public bool IsYoungDriver { get; set; }
    }
}
