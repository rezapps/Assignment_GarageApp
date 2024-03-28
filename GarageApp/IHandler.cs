using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApp
{
    internal interface IHandler
    {
        void ListParkedVehicles();

        void CountEachTypes();

        void ParkVehicle();

        void UnParkVehicle();

        void SetCapacity(int capacity);

        void PopulateGarage();

        Vehicle FindByRegistration();

        List<Vehicle> SearchVehicles(Dictionary<string, string> filters);
    }

}
