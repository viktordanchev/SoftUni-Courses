namespace _07.RawData
{
    public class Car
    {
        public Car(string model, Engine enigne, Cargo cargo, Tire[] tires)
        {
            Model = model;
            Engine = enigne;
            Cargo = cargo;
            Tires = tires;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tire[] Tires { get; set; }

    }
}
