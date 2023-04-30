namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        public Coffee(string name, double caffeine)
            : base(name, 3.50m, 50)
        {
            Caffeine = caffeine;
        }

        public double Caffeine { get; private set; }
    }
}