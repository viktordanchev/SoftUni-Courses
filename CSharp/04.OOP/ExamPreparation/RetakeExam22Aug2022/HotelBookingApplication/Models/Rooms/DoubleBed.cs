namespace BookingApp.Models.Rooms
{
    public class DoubleBed : Room
    {
        private const int BedCapacityValue = 2;

        public DoubleBed() 
            : base(BedCapacityValue)
        {
        }
    }
}
