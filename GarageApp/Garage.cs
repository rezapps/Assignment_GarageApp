using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApp
{
    internal class Garage<T> : IEnumerable<T> where T : IVehicle
    {
        public T[] _vehicles;
        public readonly int _capacity;
        public int _currentCount;

        public Garage(int capacity)
        {
            _capacity = capacity;
            _vehicles = new T[capacity];
            _currentCount = 0;
        }

        public int Capacity => _capacity;

        public void AddVehicle(T vehicle)
        {
            if (_currentCount < _capacity)
            {
                _vehicles[_currentCount] = vehicle; // Use currentCount for index
                _currentCount++;
                Console.WriteLine($"Your vehicle with registration {vehicle.Registration} is Parked!");
            }
            else
            {
                Console.WriteLine("No Empty spot left!");
            }
        }


        public void RemoveVehicle(T item)
        {
            Dictionary<string, Vehicle> vehicles = new();

            string regNumber = "ABC123";
            // intellisense recommens using discard "_" to ignore the return value
            if (vehicles.Remove(regNumber, out _))
            {
                Console.WriteLine("Successfully removed vehicle with registration {0}.", regNumber);
                _currentCount--;
            }
            else
            {
                Console.WriteLine("No vehicle found with registration number {0}.", regNumber);
            }
        }


        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _currentCount; i++)
            {
                yield return _vehicles[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }

}
