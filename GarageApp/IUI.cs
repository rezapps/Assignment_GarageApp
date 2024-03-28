using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApp
{
    public interface IUI
    {
        void ListParked();
        void Park();
        void UnPark();
        void TypesCounts();
        void FindByRegNumber();
        List<Vehicle> SearchBySpecs(Dictionary<string, string> filters);
    }

}
