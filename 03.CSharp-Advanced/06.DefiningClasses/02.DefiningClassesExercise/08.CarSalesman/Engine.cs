namespace _08.CarSalesman
{
    public class Engine
    {
        public Engine()
        {
            Model = null;
            Power = 0;
            Displacement = 0;
            Efficiency = null;
        }

        public Engine(string model, int power)
        : this()
        {
            Model = model;
            Power = power;
        }

        public Engine(string model, int power, int displacement)
        : this(model, power)
        {
            Displacement = displacement;
        }

        public Engine(string model, int power, int displacement, string efficiency)
        : this(model, power, displacement)
        {
            Efficiency = efficiency;
        }

        public string Model { get; set; }
        public int Power { get; set; }
        public int Displacement { get; set; }
        public string Efficiency { get; set; }
    }
}