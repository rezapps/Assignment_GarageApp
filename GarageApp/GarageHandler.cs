using GarageApp.Vehicles;

namespace GarageApp
{
    public class GarageHandler : IHandler
    {
        private Garage<Vehicle>? _garage;

        public GarageHandler(int capacity=10)
        {
            _garage = new Garage<Vehicle>(capacity);
        }

        public string GetInfo()
        {
            Console.WriteLine("Welcome to auto garage. Enter 6 to go back to main menu\n or choose your vehicle type by entering:\n 1. Car \n 2. Motorcycle \n 3. Boat \n 4. Bus \n 5. AirPlane");
            string userInput = Console.ReadLine() ?? "1";
            string vehicleType = userInput[..1];
            Console.WriteLine("Enter registration number: ");
            string registrationNumber = Console.ReadLine() ?? " ";
            Console.WriteLine("Enter color: ");
            string color = Console.ReadLine() ?? " ";
            Console.WriteLine("Enter model: ");
            int model;
            model = int.Parse(Console.ReadLine() ?? "2000");
            Console.WriteLine("Enter your vehicle make: ");
            string make = Console.ReadLine() ?? "";

            return $"{vehicleType}, {registrationNumber}, {color}, {model}, {make}";
        }

        public void ParkVehicle()
        {

            string UserInfo = GetInfo();
            string[] vehicleInfo = UserInfo.Split(',');
            string vehicleType = vehicleInfo[0];
            string registrationNumber = vehicleInfo[1];
            string make = vehicleInfo[4];
            string color = vehicleInfo[2];
            int model = int.Parse(vehicleInfo[3]);

            switch (vehicleType)
            {
                case "1":
                    Console.WriteLine("Enter Fuel Type: ");
                    string fuelType = Console.ReadLine() ?? "Bensin";
                    Car car = new(model, make, color, registrationNumber, fuelType);
                    _garage.AddVehicle(car);
                    break;
                case "2":
                    Console.WriteLine("Enter Cylinder Volume: ");
                    int.TryParse(Console.ReadLine() ?? "1000", out int cylinderVolume);
                    Motorcycle motorcycle = new(model, make, color, registrationNumber, cylinderVolume);
                    _garage.AddVehicle(motorcycle);
                    break;
                case "3":
                    Console.WriteLine("Enter boat length: ");
                    double leng;
                    leng = double.Parse(Console.ReadLine() ?? "3.5");
                    Boat boat = new(model, make, color, registrationNumber, leng);
                    _garage.AddVehicle(boat);
                    break;
                case "4":
                    Console.WriteLine("Enter number of seats: ");
                    int.TryParse(Console.ReadLine() ?? "12", out int numberOfSeats);
                    Bus bus = new(model, make, color, registrationNumber, numberOfSeats);
                    _garage.AddVehicle(bus);
                    break;
                case "5":
                    Console.WriteLine("Can not park an airplane");
                    // int.TryParse(Console.ReadLine() ?? "2", out int engines);
                    // Airplane airplane = new(model, make, color, engines);
                    // _garage.AddVehicle(airplane);
                    break;
                case "6":
                    return;
                default:
                    break;
            }
        }

        public void UnParkVehicle()
        {
            var userItem = FindByRegistration();
            try
            {
                if ( userItem is not null && userItem is Vehicle) {
                    _garage.RemoveVehicle(userItem);
                }
                else
                {
                    Console.WriteLine("No vehicle found with that registration number.");
                
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        public void SetCapacity(int capacity)
        {
            Console.WriteLine("soon");
        }

        public void PopulateGarage()
        {
            _garage.AddVehicle(new Bus(2019, "VOLVO", "red", "BUS123", 50));
            _garage.AddVehicle(new Car(2023, "HYUNDAI", "silver", "CAR212", "Diesel"));
            _garage.AddVehicle(new Motorcycle(2020, "HONDA", "black", "MOT111", 650));
            _garage.AddVehicle(new Boat(2024, "TITANIC", "blue", "BOT456", 10.5));
            // Airplan is not going to be added to the garage because it is not a vehicle
            // _garage.AddVehicle(new Airplane(1000, "Airplane Co.", "white", 2));
        }


        public void ListParkedVehicles()
        {
            Console.WriteLine("Parked vehicles:");
            if (_garage != null && _garage._capacity > 0)
            {
                foreach (var vehicle in _garage)
                {
                    if (vehicle != null)
                    {
                        Console.WriteLine($"{vehicle.GetType().Name}: with registration number: {vehicle.Registration}, color: {vehicle.Color}, model: {vehicle.Model}, make: {vehicle.Make}");
                    }
                }
            }
            else
            {
                Console.WriteLine("No vehicles parked.");
            }
            
        }

        public Vehicle FindByRegistration()
        {
            string userInput;
            const string pattern = @"^[A-Z]{3}[0-9]{3}$";

            do
            {
                Console.WriteLine("Enter registration number: ");
                userInput = Console.ReadLine() ?? "";

                if (!System.Text.RegularExpressions.Regex.IsMatch(userInput, pattern))
                {
                    Console.WriteLine("Registration number must be in format: ABC123");
                }
            } while (!System.Text.RegularExpressions.Regex.IsMatch(userInput, pattern));

            // Search the garage after validation
            string registration = userInput.ToUpper(); // Convert to uppercase for case-insensitive search
            return _garage.FirstOrDefault(vehicle1 => vehicle1.Registration.Equals(registration, StringComparison.OrdinalIgnoreCase));


        }


        public void CountEachTypes()
        {
            int busCount = 0;
            int bikeCount = 0;
            int carCount = 0;
            int boatCount = 0;
            if (_garage._capacity > 0)
            {
                foreach (var vehicle in _garage)
                {
                    if (vehicle.GetType() == typeof(Bus))
                    {
                        busCount++;
                    }
                    if (vehicle.GetType() == typeof(Boat))
                    {
                        boatCount++;
                    }
                    if (vehicle.GetType() == typeof(Motorcycle))
                    {
                        bikeCount++;
                    }
                    if (vehicle.GetType() == typeof(Car))
                    {
                        carCount++;
                    }
                }

                Console.WriteLine($"There are {busCount} buses, {bikeCount} motorcycles, {carCount} cars, and {boatCount} boats in the garage.");
            }
        }



        public List<Vehicle> SearchVehicles(Dictionary<string, string> filters)
        {
            List<Vehicle> searchResult = new List<Vehicle>();
            foreach (Vehicle vehicle in _garage) // Iterate over all parked vehicles
            {
                if (MatchFilters(vehicle, filters)) // Check if vehicle matches all filters
                {
                    searchResult.Add(vehicle);
                }
            }
            return searchResult;
        }

        private bool MatchFilters(Vehicle vehicle, Dictionary<string, string> filters)
        {
            foreach (KeyValuePair<string, string> filter in filters)
            {
                string filterValue = filter.Value.ToLower();

                if (filter.Key == "Color" && !vehicle.Color.ToLower().Equals(filterValue))
                {
                    return false;
                }
                else if (filter.Key == "Make" && !vehicle.Make.ToLower().Equals(filterValue))
                {
                    return false;
                }
                else if (filter.Key == "Model" && !vehicle.Model.Equals(int.Parse(filterValue)))
                {
                    return false;
                }

            }
            return true; // All filters matched
        }

    }

}
