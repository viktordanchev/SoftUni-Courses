using System;
using System.Text;


namespace CarManufacturer
{
    internal class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
      
        public string Make
        {
            get { return make; }
            set { make = value; }
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set { fuelQuantity = value; }
        }
        public double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }

        public void Drive(double distance)
        {
            if (fuelQuantity - distance * fuelConsumption >= 0)
            {
                fuelQuantity -= distance * fuelConsumption;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            StringBuilder car = new StringBuilder();

            car.AppendLine($"Make: {Make}");
            car.AppendLine($"Model: {Model}");
            car.AppendLine($"Year: {Year}");
            car.AppendLine($"Fuel: {FuelQuantity:f2}");

            return car.ToString().Trim();
        }
    }
}