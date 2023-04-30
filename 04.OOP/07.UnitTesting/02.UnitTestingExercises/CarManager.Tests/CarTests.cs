using NUnit.Framework;
using System;

namespace CarManager.Tests
{
    public class Tests
    {
        private Car car;
        private string make;
        private string model;
        private double fuelConsumption;
        private double fuelCapacity;
        private double fuelToRefuel;

        [SetUp]
        public void Setup()
        {
            make = "Volkswagen";
            model = "Golf";
            fuelConsumption = 1;
            fuelCapacity = 70;
            fuelToRefuel = 10;
            car = new Car(make, model, fuelConsumption, fuelCapacity);
        }

        [Test]
        public void Constructor_MakeNewCar()
        {
            Assert.AreEqual(0, car.FuelAmount);
            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
        }

        [Test]
        public void IfMakeIsNullOrEmptyShouldThrowsException()
        {
            make = string.Empty;

            Assert.Throws<ArgumentException>(() => car = new(make, model, fuelConsumption, fuelCapacity));
            Assert.Throws<ArgumentException>(() => car = new(null, model, fuelConsumption, fuelCapacity));
        }
        
        [Test]
        public void IfModelIsNullOrEmptyShouldThrowsException()
        {
            model = string.Empty;

            Assert.Throws<ArgumentException>(() => car = new(make, model, fuelConsumption, fuelCapacity));
            Assert.Throws<ArgumentException>(() => car = new(make, null, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void IfFuelConsumptionIsEqualOrBelowZeroShouldThrowsException()
        {
            fuelConsumption = -1.5;

            Assert.Throws<ArgumentException>(() => car = new(make, model, fuelConsumption, fuelCapacity));
            Assert.Throws<ArgumentException>(() => car = new(make, model, 0, fuelCapacity));
        }

        [Test]
        public void IfFuelCapacityIsEqualOrBelowZeroShouldThrowsException()
        {
            fuelCapacity = -2;

            Assert.Throws<ArgumentException>(() => car = new(make, model, fuelConsumption, fuelCapacity));
            Assert.Throws<ArgumentException>(() => car = new(make, model, fuelConsumption, 0));
        }

        [Test]
        public void RefuelMethod_IfFuelToRefuelIsEqualOrBelowZeroShouldThrowsException()
        {
            fuelToRefuel = -5.7;

            Assert.Throws<ArgumentException>(() => car.Refuel(fuelToRefuel));
            Assert.Throws<ArgumentException>(() => car.Refuel(0));
        }

        [Test]
        public void RefuelMethod_ShouldRefuelCar()
        {
            car.Refuel(fuelToRefuel);

            Assert.AreEqual(fuelToRefuel, car.FuelAmount);
        }

        [Test]
        public void RefuelMethod_FuelAmuountBecomesEqualToFuelCapacity()
        {
            fuelToRefuel = 100;

            car.Refuel(fuelToRefuel);

            Assert.AreEqual(fuelCapacity, car.FuelAmount);
        }

        [Test]
        public void DriveMethod_IfFuelNeededIsMoreThanFuelAmount()
        {
            double distance = 2000;

            car.Refuel(fuelToRefuel);

            Assert.Throws<InvalidOperationException>(() => car.Drive(distance));
        }

        [Test]
        public void DriveMethod_FuelAmountShouldBeDecreased()
        {
            double distance = 200;

            car.Refuel(fuelToRefuel);
            car.Drive(distance);

            Assert.AreEqual(fuelToRefuel - 2, car.FuelAmount);
        }
    }
}