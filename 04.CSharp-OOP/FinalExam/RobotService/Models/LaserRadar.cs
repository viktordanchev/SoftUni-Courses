namespace RobotService.Models
{
    public class LaserRadar : Supplement
    {
        private const int LaserRadarInterfaceStandard = 20082;
        private const int LaserRadarBatteryUsage = 5000;

        public LaserRadar() 
            : base(LaserRadarInterfaceStandard, LaserRadarBatteryUsage)
        {
        }
    }
}
