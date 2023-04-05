using NavalVessels.Models.Contracts;
using System;
using System.Linq;
using System.Text;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        private const double SubmarineArmorThickness = 200;

        public Submarine(string name, double mainWeaponCaliber, double speed) 
            : base(name, mainWeaponCaliber, speed, SubmarineArmorThickness)
        {
        }

        public bool SubmergeMode { get; private set; }

        public void ToggleSubmergeMode()
        {
            if (SubmergeMode)
            {
                SubmergeMode = false;

                MainWeaponCaliber -= 40;
                Speed += 4;
            }
            else
            {
                SubmergeMode = true;

                MainWeaponCaliber += 40;
                Speed -= 4;
            }
        }

        public override void RepairVessel()
        {
            if (ArmorThickness < 0)
                ArmorThickness = SubmarineArmorThickness;
        }

        public override string ToString()
        {
            string vesselToString = base.ToString();
            
            if (SubmergeMode)
                vesselToString += Environment.NewLine + " *Submerge mode: ON";
            else
                vesselToString += Environment.NewLine + " *Submerge mode: OFF";

            return vesselToString;
        }
    }
}
