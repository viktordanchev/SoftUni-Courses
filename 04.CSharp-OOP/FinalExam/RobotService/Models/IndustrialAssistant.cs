namespace RobotService.Models
{
    public class IndustrialAssistant : Robot
    {
        private const int IndustrialAssistantBatteryCapacity = 40000;
        private const int IndustrialAssistantConversionCapacityIndex = 5000;


        public IndustrialAssistant(string model) 
            : base(model, IndustrialAssistantBatteryCapacity, IndustrialAssistantConversionCapacityIndex)
        {
        }
    }
}
