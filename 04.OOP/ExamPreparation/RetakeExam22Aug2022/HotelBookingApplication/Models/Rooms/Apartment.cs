namespace BookingApp.Models.Rooms
{
    public class Apartment : Room
    {
        private const int BedCapacityValue = 6;

        public Apartment() 
            : base(BedCapacityValue)
        {
        }
    }
}
