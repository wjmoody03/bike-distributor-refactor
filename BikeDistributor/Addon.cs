using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeDistributor
{
    
    public static class Addons
    {
        public static Addon AeroWheels
        {
            get
            {
                return new Addon() { Price = 100, Description = "Aero Wheels" };
            }
        }
        public static Addon PowerTap
        {
            get
            {
                return new Addon() { Price = 750, Description = "Power Tap" };
            }
        }
        public static Addon ElectronicShifters
        {
            get
            {
                return new Addon() { Price = 500, Description = "Electronic Shifters" };
            }
        }
        public static Addon DiscBrakes
        {
            get
            {
                return new Addon() { Price = 150, Description = "Disk Brakes" };
            }
        }
    }

    public class Addon
    {
        public int Price { get; set; }
        public string Description { get; set; }
    }
}
