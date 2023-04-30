using Newtonsoft.Json.Serialization;
using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    public class Tests
    {
        private Garage garage;
        private Car car;
        private string name;
        private int mechanicsAvailable;

        [SetUp]
        public void Setup()
        {
            name = "PriPesho";
            mechanicsAvailable = 3;
            garage = new Garage(name, mechanicsAvailable);
            car = new Car("BMW", 2);
        }

        [Test]
        public void Constructor_MakeNewGarageProperly()
        {
            name = "PriPesho3";
            mechanicsAvailable = 4;
            garage = new Garage(name, mechanicsAvailable);

            Assert.AreEqual(name, garage.Name);
            Assert.AreEqual(mechanicsAvailable, garage.MechanicsAvailable);
        }

        [Test]
        public void NameProperty_IfIsNullOrEmptyShouldThrowException()
        {
            name = string.Empty;

            Assert.Throws<ArgumentNullException>(() => garage = new Garage(name, mechanicsAvailable));
            Assert.Throws<ArgumentNullException>(() => garage = new Garage(null, mechanicsAvailable));
        }

        [Test]
        public void mechanicsAvailableProperty_IfIsBelowOrEqualTo0ShouldThrowException()
        {
            mechanicsAvailable = -1;

            Assert.Throws<ArgumentException>(() => garage = new Garage(name, mechanicsAvailable));
            Assert.Throws<ArgumentException>(() => garage = new Garage(name, mechanicsAvailable + 1));
        }

        [Test]
        public void AddCarMethod_IncreaseCountOfCarsInside()
        {
            garage.AddCar(car);

            Assert.AreEqual(1, garage.CarsInGarage);
        }

        [Test]
        public void AddCarMethod_IfTryToAddMoreCarsThanAvailableMechanicsShouldThrowException()
        {
            mechanicsAvailable = 1;
            garage = new Garage(name, mechanicsAvailable);
            garage.AddCar(car);

            Assert.Throws<InvalidOperationException>(() => garage.AddCar(car));
        }

        [Test]
        public void FixCarMethod_MakeCarNumberOfIssuesTo0()
        {
            garage.AddCar(car);
            garage.FixCar(car.CarModel);

            Assert.AreEqual(0, car.NumberOfIssues);
        }
        
        [Test]
        public void FixCarMethod_IfCarIsNullShouldThrowException()
        {
            garage.AddCar(car);

            Assert.Throws<InvalidOperationException>(() => garage.FixCar("Audi"));
        }
        
        [Test]
        public void RemoveFixedCarMethod_IfCarIsNullShouldThrowException()
        {
            garage.AddCar(car);
            garage.FixCar(car.CarModel);

            Assert.AreEqual(1, garage.RemoveFixedCar());
        }
        
        [Test]
        public void RemoveFixedCarMethod_IfThereAreNoCarsToBeRemovedShouldThrowException()
        {
            garage.AddCar(car);

            Assert.Throws<InvalidOperationException>(() => garage.RemoveFixedCar());
        }
        
        [Test]
        public void ReportMethod_ReturnStringGarageReport()
        {
            garage.AddCar(car);

            Assert.AreEqual($"There are 1 which are not fixed: {car.CarModel}.", garage.Report());
        }
    }
}