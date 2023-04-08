using RobotService.Models.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models
{
    public abstract class Robot : IRobot
    {
        private string model;
        private int batteryCapacity;
        private int batteryLevel;
        private List<int> interfaceStandards;

        protected Robot(string model, int batteryCapacity, int conversionCapacityIndex)
        {
            Model = model;
            BatteryCapacity = batteryCapacity;
            ConvertionCapacityIndex = conversionCapacityIndex;
            BatteryLevel = BatteryCapacity;
            interfaceStandards = new List<int>();
        }

        public string Model
        {
            get { return model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.ModelNullOrWhitespace);

                model = value;
            }
        }

        public int BatteryCapacity
        {
            get { return batteryCapacity; }
            private set
            {
                if (value < 0)
                    throw new ArgumentException(ExceptionMessages.BatteryCapacityBelowZero);

                batteryCapacity = value;
            }
        }

        public int BatteryLevel
        {
            get { return batteryLevel; }
            private set { batteryLevel = value; }
        }

        public int ConvertionCapacityIndex { get; private set; }

        public IReadOnlyCollection<int> InterfaceStandards 
        { 
            get { return interfaceStandards.AsReadOnly(); } 
        }

        public void Eating(int minutes)
        {
            int producedEnergy = 0;

            producedEnergy += ConvertionCapacityIndex * minutes;

            if (BatteryLevel + producedEnergy > BatteryCapacity)
                BatteryLevel = BatteryCapacity;

            BatteryLevel += producedEnergy;
        }

        public bool ExecuteService(int consumedEnergy)
        {
            if (BatteryLevel >= consumedEnergy)
            {
                BatteryLevel -= consumedEnergy;
                return true;
            }
            
            return false;
        }

        public void InstallSupplement(ISupplement supplement)
        {
            interfaceStandards.Add(supplement.InterfaceStandard);

            BatteryCapacity -= supplement.BatteryUsage;
            BatteryLevel -= supplement.BatteryUsage;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{GetType().Name} {Model}:");
            sb.AppendLine($"--Maximum battery capacity: {BatteryCapacity}");
            sb.AppendLine($"--Current battery level: {BatteryLevel}");
            sb.Append($"--Supplements installed: ");

            if (InterfaceStandards.Count == 0)
                sb.AppendLine("none");
            else
                sb.AppendJoin(' ', InterfaceStandards);

            return sb.ToString().Trim();
        }
    }
}
