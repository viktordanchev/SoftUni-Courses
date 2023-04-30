using NUnit.Framework;

namespace RobotFactory.Tests
{
    public class RobotTests
    {
        private Robot robot;
        private string model;
        private double price;
        private int interfaceStandard;

        [SetUp]
        public void Setup()
        {
            model = "R2-D2";
            price = 1000;
            interfaceStandard = 5;
            robot = new Robot(model, price, interfaceStandard);
        }

        [Test]
        public void Constructor_MakeNewRobotProperly()
        {
            model = "R2-D2";
            price = 1000;
            interfaceStandard = 5;
            robot = new Robot(model, price, interfaceStandard);

            Assert.AreEqual(model, robot.Model);
            Assert.AreEqual(price, robot.Price);
            Assert.AreEqual(interfaceStandard, robot.InterfaceStandard);
            Assert.AreEqual(0, robot.Supplements.Count);
        }
        
        [Test]
        public void ToStringMethod_ReturnRobotInfo()
        {
            string info = $"Robot model: {model} IS: {interfaceStandard}, Price: {price:f2}";

            Assert.AreEqual(info, robot.ToString());
        }
    }
}