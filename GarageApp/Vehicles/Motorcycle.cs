using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApp.Vehicles
{
    internal class Motorcycle(int model, string make, string color, string registration, int cylinderVolume) : Vehicle(model, wheels: 2, make, color, registration)
    {
        public int CylinderVolume { get; set; } = cylinderVolume;

        public override string GetDetails()
        {
            return base.GetDetails() + $", Cylinder Volume: {CylinderVolume}";
        }
    }
}
