using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageApp
{
    public static class MakeGarage
    {
        public static void DisplayMainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose one option to start your garage:");
                Console.WriteLine("1. Create new Garage with Default Capacity of 10 spots ");
                Console.WriteLine("2. Create a Garage with Custom Capacity");
                Console.WriteLine("0. Exit");

                string input = Console.ReadLine()!.Trim();

                switch (input)
                {
                    case "1":
                        BuildGarage();
                        break;
                    case "2":
                        CustomGarage();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid number.");
                        Console.ReadKey();
                        break;
                }
                Console.WriteLine("2. Navigate to Menu");
                Console.WriteLine("0. Exit");
            }
        }


        public static void BuildGarage()
        {
            GarageHandler handler = new GarageHandler();
            handler.PopulateGarage();
            Menu menu = new(handler);
            menu.DisplayMenu();
            Console.WriteLine("Garage Created and has 10 spots.");
        }

        public static void CustomGarage()
        {
            Console.WriteLine("How many spots should your Garage have? 5-100");
            int.TryParse(Console.ReadLine(), out int spots);
            GarageHandler handler = new GarageHandler(spots);
            handler.PopulateGarage();
            Menu menu = new(handler);
            menu.DisplayMenu();
            Console.WriteLine($"Your Garage with {spots} spots is build");
        }

    }
}
