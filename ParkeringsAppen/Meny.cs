using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ParkeringsAppen.Vehicle;
using static ParkeringsAppen.Vehicle;

namespace ParkeringsAppen
{
    internal class Meny
    {
        public void ShowMeny()
        {
            ParkingLot parkingLot = new ParkingLot();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Välkommen till ParkeringSöder!\n");
                Console.WriteLine("1. Parkera ett slumpmässigt fordon");
                Console.WriteLine("2. Visa alla parkerade fordon");
                Console.WriteLine("3. Parkeringsvakt - Kontrollera överträdande fordon");
                Console.WriteLine("4. Parkeringschef - Visa statistik");
                Console.WriteLine("5. Checka ut fordon");
                Console.WriteLine("6. Avsluta");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.Clear();
                    switch (choice)
                    {
                        case 1:
                            Vehicle vehicle = Vehicle.GenerateRandomVehicle();
                            CollectVehicleInfo(vehicle);

                            Console.Write("Ange parkeringstid i sekunder: ");
                            if (int.TryParse(Console.ReadLine(), out int duration))
                            {
                                parkingLot.ParkVehicle(vehicle, duration);
                            }
                            else
                            {
                                Console.WriteLine("Ogiltig tid. Ange ett heltal.");
                            }
                            break;

                        case 2:
                            parkingLot.ShowParkedVehicles();
                            break;

                        case 3:
                            parkingLot.CheckForExpiredVehicles();
                            break;

                        case 4:
                            parkingLot.ShowStatistics();
                            break;

                        case 5:
                            Console.Write("Ange registreringsnummer för utcheckning: ");
                            string lPlate = Console.ReadLine();
                            parkingLot.CheckoutVehicle(lPlate);
                            break;

                        case 6:
                            Console.WriteLine("Tack för att du använde ParkeringSöder. Hej då!");
                            return;

                        default:
                            Console.WriteLine("Ogiltigt val. Försök igen.");
                            break;
                    }
                    Console.WriteLine("\nTryck på valfri tangent för att återgå till menyn...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Ogiltig inmatning. Ange ett heltal.");
                }
            }
        }

        private void CollectVehicleInfo(Vehicle vehicle)
        {
            if (vehicle is Car car)
            {
                Console.Write("BIL incheckad: Är bilen elektrisk? (ja/nej): ");
                car.Electric = Console.ReadLine()?.ToLower() == "ja";
            }
            else if (vehicle is MC mc)
            {
                Console.Write("MC incheckad: Ange motorcykelns märke: ");
                mc.Brand = Console.ReadLine();
            }
            else if (vehicle is Bus bus)
            {
                Console.Write("BUSS incheckad: Ange antalet passagerare: ");
                if (int.TryParse(Console.ReadLine(), out int passengers))
                {
                    bus.Passengers = passengers;
                }
                else
                {
                    Console.WriteLine("Ogiltigt antal passagerare.");
                }
            }
        }
    }

}

