using NUnit.Framework;
using System.Diagnostics;
using System.Reflection;

namespace RobotFactory.Tests
{
    public class FactoryTests
    {
        private Factory factory;
        private Robot robot;
        private Supplement supplement;
        private string name;
        private int capacity;

        [SetUp]
        public void Setup()
        {
            name = "LEGO";
            capacity = 100;
            factory = new Factory(name, capacity);
            robot = new Robot("R2-D2", 1000, 5);
            supplement = new Supplement("LaserRadar", 5);
        }

        [Test]
        public void Constructor_MakeNewFactoryProperly()
        {
            name = "LEGO";
            capacity = 100;
            factory = new Factory(name, capacity);

            Assert.AreEqual(name, factory.Name);
            Assert.AreEqual(capacity, factory.Capacity);
            Assert.AreEqual(0, factory.Robots.Count);
            Assert.AreEqual(0, factory.Supplements.Count);
        }

        [Test]
        public void ProduceRobotMethod_IncreaseRobotsCountBy1()
        {
            string text = $"Produced --> {robot}";

            Assert.AreEqual(text, factory.ProduceRobot("R2-D2", 1000, 5));
            Assert.AreEqual(1, factory.Robots.Count);
        }

        [Test]
        public void ProduceRobotMethod_IfFactoryCapacityIsEqualToRobotsCount()
        {
            string text = "The factory is unable to produce more robots for this production day!";

            capacity = 1;
            factory = new Factory(name, capacity);

            factory.ProduceRobot("R2-D2", 1000, 5);

            Assert.AreEqual(text, factory.ProduceRobot("R2-D2", 1000, 5));
        }

        [Test]
        public void ProduceSupplementMethod_IncreaseSupplementsCountBy1()
        {
            string info = $"Supplement: LaserRadar IS: 5";

            Assert.AreEqual(info, factory.ProduceSupplement("LaserRadar", 5));
            Assert.AreEqual(1, factory.Supplements.Count);

        }

        [Test]
        public void UpgradeRobotMethod_AddSupplementToRobot()
        {
            Assert.AreEqual(true, factory.UpgradeRobot(robot, supplement));
            Assert.AreEqual(supplement.Name, robot.Supplements[0].Name);
            Assert.AreEqual(supplement.InterfaceStandard, robot.Supplements[0].InterfaceStandard);
        }
        
        [Test]
        public void UpgradeRobotMethod_IfRobotHaveThisSupplement()
        {
            factory.UpgradeRobot(robot, supplement);

            Assert.AreEqual(false, factory.UpgradeRobot(robot, supplement));
        }
        
        [Test]
        public void UpgradeRobotMethod_IfRobotInterfaceStandardIsDifferentFromSupplementInterfaceStandard()
        {
            robot = robot = new Robot("R2-D2", 1000, 5);
            supplement = new Supplement("LaserRadar", 1);

            Assert.AreEqual(false, factory.UpgradeRobot(robot, supplement));
        }
        
        [Test]
        public void SellRobotMethod_ReturnSelledRobotInfo()
        {
            string info = $"Robot model: R2-D2 IS: 5, Price: 1000.00";

            factory.ProduceRobot("R2-D2", 1000, 5);

            Assert.AreEqual(info, factory.SellRobot(1000).ToString());
        }
        
        [Test]
        public void SellRobotMethod_ReturnNull()
        {
            factory.ProduceRobot("R2-D2", 1000, 5);

            Assert.AreEqual(null, factory.SellRobot(100));
        }
    }
}
