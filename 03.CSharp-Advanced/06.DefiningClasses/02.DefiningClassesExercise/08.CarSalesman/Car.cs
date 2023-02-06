using System;
using System.Diagnostics;

namespace _08.CarSalesman
{
    public class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            string weight = Weight == 0 ? "n/a" : Weight.ToString();
            string color = Color == null ? "n/a" : Color; 

            string result =
                $"{Model}:{Environment.NewLine}" +
                $"  {Engine}{Environment.NewLine}" +
                $"  Weight: {weight}{Environment.NewLine}" +
                $"  Color: {color}";

            return result;
        }
    }
}