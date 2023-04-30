namespace VehiclesExtension.Vehicles
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            FuelConsumption += 1.4;
        }

        public void DriveEmpty(double distance)
        {
            FuelConsumption -= 1.4;
            Drive(distance);
        }
    }
}
