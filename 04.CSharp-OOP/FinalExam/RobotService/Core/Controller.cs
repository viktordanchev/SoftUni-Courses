using RobotService.Core.Contracts;
using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories;
using RobotService.Utilities.Messages;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private SupplementRepository supplements;
        private RobotRepository robots;
        private List<string> validRobotTypes = new List<string>() { "DomesticAssistant", "IndustrialAssistant" };
        private List<string> validSupplementTypes = new List<string>() { "SpecializedArm", "LaserRadar" };

        public Controller()
        {
            supplements = new SupplementRepository();
            robots = new RobotRepository();
        }

        public string CreateRobot(string model, string typeName)
        {
            if (!validRobotTypes.Any(t => t == typeName))
                return string.Format(OutputMessages.RobotCannotBeCreated, typeName);

            IRobot robot = null;

            switch (typeName)
            {
                case "DomesticAssistant":
                    robot = new DomesticAssistant(model);
                    break;
                case "IndustrialAssistant":
                    robot = new IndustrialAssistant(model);
                    break;
            }

            robots.AddNew(robot);
            return string.Format(OutputMessages.RobotCreatedSuccessfully, typeName, model);
        }

        public string CreateSupplement(string typeName)
        {
            if (!validSupplementTypes.Any(t => t == typeName))
                return string.Format(OutputMessages.SupplementCannotBeCreated, typeName);

            ISupplement supplement = null;

            switch (typeName)
            {
                case "SpecializedArm":
                    supplement = new SpecializedArm();
                    break;
                case "LaserRadar":
                    supplement = new LaserRadar();
                    break;
            }

            supplements.AddNew(supplement);
            return string.Format(OutputMessages.SupplementCreatedSuccessfully, typeName);
        }

        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
        {
            List<IRobot> robots = new List<IRobot>();

            foreach (var currRobot in this.robots.Models())
            {
                if (currRobot.InterfaceStandards.Any(i => i == intefaceStandard))
                    robots.Add(currRobot);
            }

            if (robots.Count == 0)
                return string.Format(OutputMessages.UnableToPerform, intefaceStandard);

            robots = robots.OrderByDescending(r => r.BatteryLevel).ToList();

            int sum = robots.Sum(r => r.BatteryLevel);

            if (sum < totalPowerNeeded)
                return string.Format(OutputMessages.MorePowerNeeded, serviceName, totalPowerNeeded - sum);

            int count = 0;

            foreach (IRobot robot in robots)
            {
                if (robot.BatteryLevel >= totalPowerNeeded)
                {
                    robot.ExecuteService(totalPowerNeeded);
                    count++;
                    break;
                }

                totalPowerNeeded -= robot.BatteryLevel;
                robot.ExecuteService(robot.BatteryLevel);
                count++;
            }

            return string.Format(OutputMessages.PerformedSuccessfully, serviceName, count);
        }

        public string Report()
        {
            List<IRobot> robots = this.robots.Models()
                .OrderByDescending(r => r.BatteryLevel)
                .ThenBy(r => r.BatteryCapacity)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var robot in robots)
            {
                sb.AppendLine(robot.ToString());
            }

            return sb.ToString().Trim();
        }

        public string RobotRecovery(string model, int minutes)
        {
            List<IRobot> robots = this.robots.Models().Where(r => r.Model == model).ToList();

            int count = 0;

            foreach (var robot in robots)
            {
                if (robot.BatteryLevel < robot.BatteryCapacity / 2)
                {
                    robot.Eating(minutes);
                    count++;
                }
            }

            return string.Format(OutputMessages.RobotsFed, count);
        }

        public string UpgradeRobot(string model, string supplementTypeName)
        {
            ISupplement supplement = supplements.Models().First(t => t.GetType().Name == supplementTypeName);

            int supplementInterfaceValue = supplement.InterfaceStandard;

            List<IRobot> robots = new List<IRobot>();

            foreach (var currRobot in this.robots.Models())
            {
                if (currRobot.InterfaceStandards.Any(i => i == supplementInterfaceValue))
                    continue;

                robots.Add(currRobot);
            }

            robots = robots.Where(r => r.Model == model).ToList();    

            if (robots.Count == 0)
                return string.Format(OutputMessages.AllModelsUpgraded, model);

            IRobot robot = robots.First();

            robot.InstallSupplement(supplement);
            supplements.RemoveByName(supplementTypeName);
            return string.Format(OutputMessages.UpgradeSuccessful, model, supplementTypeName);
        }
    }
}
