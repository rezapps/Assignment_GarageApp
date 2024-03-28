using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApp.Vehicles
{
    internal class Boat(int model, string make, string color, string registration, double length) : Vehicle(model, wheels: 0, make, color, registration)
    {
        public double Length { get; set; } = length;

        public override string GetDetails()
        {
            return base.GetDetails() + $", Length: {Length}";
        }
    }
}
