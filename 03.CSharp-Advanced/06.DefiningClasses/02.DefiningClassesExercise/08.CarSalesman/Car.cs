namespace _08.CarSalesman
{
    public class Car
    {
        public Car()
        {
            Model = string.Empty;
            Engine = null;
            Weight= 0;
            Color = string.Empty;
        }

        public Car(string model, Engine engine)
        : this()
        {
            Model = model;
            Engine = engine;
        }

        public Car(string model, Engine engine, int weight) 
        : this(model, engine)
        {
            Weight = weight;
        }

        public Car(string model, Engine engine, int weight, string color)
        : this(model, engine, weight)
        {
            Color = color;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }
    }
}
