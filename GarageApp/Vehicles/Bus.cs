using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApp.Vehicles
{
    internal class Bus(int model, string make, string color, string registration, int numberOfSeats) : Vehicle(model, wheels: 8, make, color, registration)
    {
        public int NumberOfSeats { get; set; } = numberOfSeats;
        public override string GetDetails()
        {
            return base.GetDetails() + $", Number of seats: {NumberOfSeats}";
        }
    }
}
