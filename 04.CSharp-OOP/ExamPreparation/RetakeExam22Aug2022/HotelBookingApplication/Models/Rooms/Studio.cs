namespace BookingApp.Models.Rooms
{
    public class Studio : Room
    {
        private const int BedCapacityValue = 4;

        public Studio() 
            : base(BedCapacityValue)
        {
        }
    }
}
