namespace CarManufacturer
{
    public class Engine
    {
        private int horsePower;
        private double cubicCapacity;

        public Engine(int horsePower, double cubicCapacity)
        {
            HorsePower = horsePower;
            CubicCapacity = cubicCapacity;
        }

        public double CubicCapacity { get { return cubicCapacity; } set { cubicCapacity = value; } }
        public int HorsePower { get { return horsePower; } set { horsePower = value; } }
    }
}