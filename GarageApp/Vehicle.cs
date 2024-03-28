using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApp
{
    public class Vehicle(int model, int wheels, string make, string color, string registration) : IVehicle
    {
        // setter can be private but getter should be public
        public int Model { get; set; } = model;
        public int Wheels { get; set;  } = wheels;
        public string Make { get; set; } = make;
        public string Color { get; set; } = color;
        public string Registration { get; set; } = registration;

        public virtual string GetDetails()
        {
            return $"Vehicle Details: Model: {Model}, Wheels: {Wheels}, Make: {Make}, Color: {Color}, Registration: {Registration}";

        }
    }
}
