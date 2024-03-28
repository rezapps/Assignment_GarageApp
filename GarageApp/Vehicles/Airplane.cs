using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApp.Vehicles
{
    internal class Airplane(int model, string make, string color, int numberOfEngines) : Vehicle(model, wheels: 3, make, color, registration: "No Registration Number")
    {
        public int NumberOfEngines { get; set; } = numberOfEngines;

        public override string GetDetails()
        {
            return base.GetDetails() + $", Number of engines: {NumberOfEngines}";
        }
    }
}
