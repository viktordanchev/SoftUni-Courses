namespace NeedForSpeed
{
    public class Vehicle
    {
        private double defaultFuelConsumption = 1.25;

        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }

        public double DefaultFuelConsumption { get { return defaultFuelConsumption; } set { defaultFuelConsumption = value; } }
        public virtual double FuelConsumption { get { return DefaultFuelConsumption; } set { DefaultFuelConsumption = value; } }
        public double Fuel { get; set; }
        public int HorsePower { get; set; }

        public virtual void Drive(double kilometers)
        {
            Fuel -= kilometers * FuelConsumption;
        }
    }
}