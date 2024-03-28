namespace GarageApp
{
    public class Menu(GarageHandler _garageHandler) : IUI
    {
        public void DisplayMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Garage App. Choose one of the following:");
                Console.WriteLine("1. List Parked Vehicles");
                Console.WriteLine("2. Park a vehicle");
                Console.WriteLine("3. Unparka a vehicle");
                Console.WriteLine("4. List all vehicles by type");
                Console.WriteLine("5. Search a vehicle by registration number");
                Console.WriteLine("6. Exit");


                string input = Console.ReadLine() ?? "6";
                int menuOption ;

                if (int.TryParse(input.Substring(0, 1), out menuOption) && menuOption > 0 && menuOption < 7)
                {
                    switch (menuOption)
                    {
                        case 1:
                            ListParked();
                            break;
                        case 2:
                            Park();
                            break;
                        case 3:
                            UnPark();
                            break;
                        case 4:
                            TypesCounts();
                            break;
                        case 5:
                            FindByRegNumber();
                            break;
                        case 6:
                            return;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(true);
            }
        }

        
        public void ListParked()
        {
            _garageHandler.ListParkedVehicles();
        }

        public void Park()
        {
            _garageHandler.ParkVehicle();
        }

        public void UnPark()
        {
            _garageHandler.UnParkVehicle();
        }

        public void TypesCounts()
        {
             _garageHandler.CountEachTypes();
        }

        public void FindByRegNumber()
        {
            var foundVehicle = _garageHandler.FindByRegistration();
            Console.WriteLine($"Found vehicle: {foundVehicle.Registration}, color: {foundVehicle.Color}, model: {foundVehicle.Model}, make: {foundVehicle.Make}");
        }

        public List<Vehicle> SearchBySpecs(Dictionary<string, string> filters)
        {
            return _garageHandler.SearchVehicles(filters);
        }
    }
}
