using RobotService.Models.Contracts;

namespace RobotService.Models.Supplements
{
    public abstract class Supplement : ISupplement
    {
        protected Supplement(int interfaceStandard, int batteryUsage)
        {
            InterfaceStandard = interfaceStandard;
            BatteryUsage = batteryUsage;
        }

        public int InterfaceStandard { get; private set; }

        public int BatteryUsage { get; private set; }
    }
}
