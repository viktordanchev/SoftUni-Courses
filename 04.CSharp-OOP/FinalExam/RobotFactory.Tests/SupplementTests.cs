using NUnit.Framework;
using System.Diagnostics;
using System.Reflection;

namespace RobotFactory.Tests
{
    public class SupplementTests
    {
        private Supplement supplement;
        private string name;
        private int interfaceStandard;

        [SetUp]
        public void Setup()
        {
            name = "LaserRadar";
            interfaceStandard = 5;
            supplement = new Supplement(name, interfaceStandard);
        }

        [Test]
        public void Constructor_MakeNewRobotProperly()
        {
            name = "LaserRadar";
            interfaceStandard = 5;
            supplement = new Supplement(name, interfaceStandard);

            Assert.AreEqual(name, supplement.Name);
            Assert.AreEqual(interfaceStandard, supplement.InterfaceStandard);
        }

        [Test]
        public void ToStringMethod_ReturnSupplementInfo()
        {
            string info = $"Supplement: {name} IS: {interfaceStandard}";

            Assert.AreEqual(info, supplement.ToString());
        }
    }
}