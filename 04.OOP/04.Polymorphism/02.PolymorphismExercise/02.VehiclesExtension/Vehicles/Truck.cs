namespace VehiclesExtension.Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            FuelConsumption += 1.6;
        }

        public override void Refuel(double liters)
        {
            base.Refuel(liters);
            FuelQuantity += liters * 0.95;
        }
    }
}
