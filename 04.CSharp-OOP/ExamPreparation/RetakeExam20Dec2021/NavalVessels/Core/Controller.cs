using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using NavalVessels.Utilities.Messages;
using System.Collections.Generic;
using System.Linq;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        private VesselRepository vesselRepository;
        private ICollection<ICaptain> captains;
        private List<string> validVesselTypes = new List<string>() { "Battleship", "Submarine" };

        public Controller()
        {
            vesselRepository = new VesselRepository();
            captains = new List<ICaptain>();
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            ICaptain captain = captains.FirstOrDefault(c => c.FullName == selectedCaptainName);
            IVessel vessel = vesselRepository.FindByName(selectedVesselName);

            if (captain == null)
                return string.Format(OutputMessages.CaptainNotFound, selectedCaptainName);

            if (vessel == null)
                return string.Format(OutputMessages.VesselNotFound, selectedVesselName);

            if (vessel.Captain != null)
                return string.Format(OutputMessages.VesselOccupied, selectedVesselName);

            captain.AddVessel(vessel);
            vessel.Captain = captain;
            return string.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel attacker = vesselRepository.FindByName(attackingVesselName);
            IVessel defender = vesselRepository.FindByName(defendingVesselName);

            if (attacker == null)
                return string.Format(OutputMessages.VesselNotFound, attackingVesselName);

            if (defender == null)
                return string.Format(OutputMessages.VesselNotFound, defendingVesselName);

            if (attacker.ArmorThickness == 0)
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);

            if (defender.ArmorThickness == 0)
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);

            attacker.Attack(defender);
            attacker.Captain.IncreaseCombatExperience();
            defender.Captain.IncreaseCombatExperience();

            return string.Format(OutputMessages.SuccessfullyAttackVessel, defendingVesselName, attackingVesselName, defender.ArmorThickness);
        }

        public string CaptainReport(string captainFullName)
        {
            ICaptain captain = captains.FirstOrDefault(c => c.FullName == captainFullName);

            return captain.Report();
        }

        public string HireCaptain(string fullName)
        {
            ICaptain captain = captains.FirstOrDefault(c => c.FullName == fullName);

            if (captain != null)
                return string.Format(OutputMessages.CaptainIsAlreadyHired, fullName);

            captain = new Captain(fullName);

            captains.Add(captain);
            return string.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            IVessel vessel = vesselRepository.FindByName(name);

            if (vessel != null)
                return string.Format(OutputMessages.VesselIsAlreadyManufactured, vesselType, name);

            if (!validVesselTypes.Any(t => t == vesselType))
                return string.Format(OutputMessages.InvalidVesselType);

            switch (vesselType)
            {
                case "Battleship":
                    vessel = new Battleship(name, mainWeaponCaliber, speed);
                    break;
                case "Submarine":
                    vessel = new Submarine(name, mainWeaponCaliber, speed);
                    break;
            }

            vesselRepository.Add(vessel);
            return string.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
        }

        public string ServiceVessel(string vesselName)
        {
            IVessel vessel = vesselRepository.FindByName(vesselName);

            if (vessel == null)
                return string.Format(OutputMessages.VesselNotFound, vesselName);

            vessel.RepairVessel();
            return string.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
        }

        public string ToggleSpecialMode(string vesselName)
        {
            IVessel vessel = vesselRepository.FindByName(vesselName);

            if (vessel == null)
                return string.Format(OutputMessages.VesselNotFound, vesselName);

            if (vessel.GetType().Name == "Battleship")
            {
                Battleship battleship = vessel as Battleship;

                battleship.ToggleSonarMode();

                return string.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
            }

            Submarine submarine = vessel as Submarine;

            submarine.ToggleSubmergeMode();

            return string.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);
        }

        public string VesselReport(string vesselName)
        {
            IVessel vessel = vesselRepository.FindByName(vesselName);

            return vessel.ToString();
        }
    }
}
