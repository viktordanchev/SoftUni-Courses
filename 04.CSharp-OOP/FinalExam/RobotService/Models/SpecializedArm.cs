namespace RobotService.Models
{
    public class SpecializedArm : Supplement
    {
        private const int SpecializedArmInterfaceStandard = 10045;
        private const int SpecializedArmBatteryUsage = 10000;

        public SpecializedArm() 
            : base(SpecializedArmInterfaceStandard, SpecializedArmBatteryUsage)
        {
        }
    }
}
