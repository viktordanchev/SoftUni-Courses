using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    public class Tests
    {
        private Gym gym;
        private Athlete athlete;
        private string name;
        private int capacity;


        [SetUp]
        public void Setup()
        {
            name = "Pulse";
            capacity = 10;
            gym = new Gym(name, capacity);
            athlete = new Athlete("Ivan");
        }

        [Test]
        public void Constructor_MakeNewGymProperly()
        {
            name = "Vidal";
            capacity = 15;
            gym = new Gym(name, capacity);

            Assert.AreEqual(name, gym.Name);
            Assert.AreEqual(capacity, gym.Capacity);
            Assert.AreEqual(0, gym.Count);
        }
        
        [Test]
        public void NameProperty_IfIsNullOrEmptyShouldThrowException()
        {
            name = string.Empty;

            Assert.Throws<ArgumentNullException>(() => gym = new Gym(name, capacity));
            Assert.Throws<ArgumentNullException>(() => gym = new Gym(null, capacity));
        }
        
        [Test]
        public void CapacityProperty_IfIsBelow0ShouldThrowException()
        {
            capacity = -10;

            Assert.Throws<ArgumentException>(() => gym = new Gym(name, capacity));
        }
        
        [Test]
        public void AddAthlete_IncreaseGymCount()
        {
            gym.AddAthlete(athlete);

            Assert.AreEqual(1, gym.Count);
        }
        
        [Test]
        public void AddAthlete_IfGymIsFullShouldThrowException()
        {
            capacity = 1;
            gym = new Gym(name, capacity);

            gym.AddAthlete(athlete);

            Assert.Throws<InvalidOperationException>(() => gym.AddAthlete(athlete));
        }
        
        [Test]
        public void RemoveAthlete_DecreaseGymCount()
        {
            gym.AddAthlete(athlete);
            gym.RemoveAthlete("Ivan");

            Assert.AreEqual(0, gym.Count);
        }
        
        [Test]
        public void RemoveAthlete_IfTryToRemoveNonExistingAthleteShouldThrowException()
        {
            gym.AddAthlete(athlete);

            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("Simeon"));
        }
        
        [Test]
        public void InjureAthlete_ReturnInjuredAthlete()
        {
            gym.AddAthlete(athlete);

            Assert.AreEqual(athlete, gym.InjureAthlete("Ivan"));
        }
        
        [Test]
        public void InjureAthlete_IfTryToInjureNonExistingAthleteShouldThrowException()
        {
            gym.AddAthlete(athlete);

            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete("Simeon"));
        }
        
        [Test]
        public void ReportAthlete_ReturnGymInfo()
        {
            string text = "Active athletes at Pulse: Ivan";

            gym.AddAthlete(athlete);

            Assert.AreEqual(text, gym.Report());
        } 
    }
}