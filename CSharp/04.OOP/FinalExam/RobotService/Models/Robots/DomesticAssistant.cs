namespace RobotService.Models.Robots
{
    public class DomesticAssistant : Robot
    {
        private const int DomesticAssistantBatteryCapacity = 20000;
        private const int DomesticAssistantConversionCapacityIndex = 2000;

        public DomesticAssistant(string model)
            : base(model, DomesticAssistantBatteryCapacity, DomesticAssistantConversionCapacityIndex)
        {
        }
    }
}
