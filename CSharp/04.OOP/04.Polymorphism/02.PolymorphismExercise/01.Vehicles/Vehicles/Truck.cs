namespace Vehicles.Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
            FuelConsumption += 1.6;
        }

        public override void Refuel(double liters)
        {
            FuelQuantity += liters * 0.95;
        }
    }
}
