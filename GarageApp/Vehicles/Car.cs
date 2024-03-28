using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApp.Vehicles
{
    internal class Car(int model, string make, string color, string registration, string fueltype) : Vehicle(model, wheels: 4, make, color, registration)
    {
        public string FuelType { get; set; } = fueltype;

        public override string GetDetails()
        {
            return base.GetDetails() + $", Fuel Type: {FuelType}";
        }
    }
}
