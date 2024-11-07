using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ParkeringsAppen.Vehicles.Vehicle;
using static ParkeringsAppen.Vehicles;

namespace ParkeringsAppen
{
    // Intern klass Meny ansvarar för att visa en meny och hantera användarens val för parkering
    internal class Meny
    {
        // Metod för att visa menyn och hantera användarens val
        internal void ShowMeny()
        {
            
            // Oändlig loop för att hålla menyn uppe tills användaren avslutar
            while (true)
            {
                // Rensar konsolen för att visa menyn
                Console.Clear();
                Console.WriteLine("Välkommen till ParkeringSöder!");
                Console.WriteLine("1.Parkera ett slumpmässigt fordon");
                Console.WriteLine("2.Visa alla parkerade fordon");
                Console.WriteLine("3.Parkeringsvakt - Kontrollera överträdande fordon");
                Console.WriteLine("4.Parkeringschef - Visa statistik");
                Console.WriteLine("5.Checka ut fordon");
                Console.WriteLine("6.Avsluta");
                
                int choice;
                // Försöker läsa användarens val och konvertera det till ett heltal
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.Clear();
                    // Switch-sats för att hantera användarens val
                    switch (choice)
                    {
                        case 1:
                            //Generera ett slumpmässigt fordon och samlar in ytterligare information om fordonet
                           Vehicle vehicle = Vehicle.GenerateRandomVehicle();
                           CollectVehicleInfo(vehicle);

                            // Frågar efter parkeringstid i sekunder och försöker läsa in det
                            Console.Write("Ange parkeringstid i sekunder: ");
                            if(int.TryParse(Console.ReadLine(), out int duration))
                            {
                                //Parkerar fordonet med angiven tid 
                                
                            }
                            else
                            {
                                Console.WriteLine("Ogiltig tid. Ange ett heltal");
                            }
                            break;
                        case 2:
                           
                            break;
                        case 3:
                           
                            break;
                        case 4:
                            
                            break;
                        case 5:
                            
                            break;
                        case 6:
                            
                            return;
                        default:
                            // Hanterar ogiltiga val (siffror som inte motsvarar ett menyval)
                            Console.WriteLine("Ogiltigt val. Försök igen.");
                            break;
                    }
                    // Väntar på att användaren ska trycka på en tangent för att återgå till menyn
                    Console.WriteLine("\nTryck på valfri tangent för att återgå till menyn...");
                    Console.ReadKey();
                }
                else
                {
                    // Meddelande för ogiltig inmatning om användaren inte anger ett heltal
                    Console.WriteLine("Ogiltig inmatning. Ange ett heltal.");
                }
            }
        }




        // Privat metod för att samla in ytterligare information om det genererade fordonet
        private void CollectVehicleInfo(Vehicle vehicle)
        {
            // Om fordonet är en bil, fråga om bilen är elektrisk
            if (vehicle is Car car)
            {
                Console.Write("Är bilen elektrisk ? (ja / nej) : ");
                car.Electric = Console.ReadLine()?.ToLower() == "ja";
            }
            // Om fordonet är en motorcykel, fråga efter motorcykelns märke
            else if (vehicle is MC mc)
            {
                Console.Write("Ange motorcykelns märke: ");
                mc.Brand = Console.ReadLine();
            }
            // Om fordonet är en buss, fråga efter antalet passagerare
            else if (vehicle is Bus bus)
            {
                Console.Write("Ange antalet passagerare: ");
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

