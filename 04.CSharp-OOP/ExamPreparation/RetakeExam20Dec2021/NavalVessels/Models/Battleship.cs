using NavalVessels.Models.Contracts;
using System;
using System.Security.Cryptography.X509Certificates;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        private const double BattleshipArmorThickness = 300;

        public Battleship(string name, double mainWeaponCaliber, double speed) 
            : base(name, mainWeaponCaliber, speed, BattleshipArmorThickness)
        {
        }

        public bool SonarMode { get; private set; }

        public void ToggleSonarMode()
        {
            if (SonarMode)
            {
                SonarMode = false;

                MainWeaponCaliber -= 40;
                Speed += 5;
            }
            else
            {
                SonarMode = true;

                MainWeaponCaliber += 40;
                Speed -= 5;
            }
        }

        public override void RepairVessel()
        {
            if (ArmorThickness < BattleshipArmorThickness)
                ArmorThickness = BattleshipArmorThickness;
        }

        public override string ToString()
        {
            string vesselToString = base.ToString();

            if (SonarMode)
                vesselToString += Environment.NewLine + " *Sonar mode: ON";
            else
                vesselToString += Environment.NewLine + " *Sonar mode: OFF";

            return vesselToString;
        }
    }
}
