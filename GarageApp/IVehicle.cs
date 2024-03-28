using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApp
{
    internal interface IVehicle
    {
        int Model { get; }
        int Wheels { get; }
        string? Make { get; }
        string? Color { get; }
        string? Registration { get; }
        string GetDetails();
    }
}
