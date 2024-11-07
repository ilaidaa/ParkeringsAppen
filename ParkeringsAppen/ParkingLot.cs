using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static ParkeringsAppen.Vehicles;

namespace ParkeringsAppen
{

    internal class ParkingLot
    {
        // Totala antalet parkeringsplatser i parkeringen, här satt till 25
        private int totalSpots = 25;

        // Variabel för att spåra intäkter från parkering
        private double earningsFromParking = 0;

        // Variabel för att spåra intäkter från böter
        private double earningsFromFines = 0;

        // Array för att hålla reda på parkeringsplatsernas status; true = full plats, false = ledig plats
        private bool[] spots = new bool[25];

        // Ordbok för att spåra antalet motorcyklar (MC) på varje plats
        private Dictionary<int, int> mcCount = new Dictionary<int, int>();

        // Lista för att hålla information om parkerade fordon, startplats, sluttid och om fordonet har fått böter
        private List<(Vehicle vehicle, int startSpot, DateTime endTime, bool hasFine)> parkedVehicles =
            new List<(Vehicle, int, DateTime, bool)>();

        // Metod för att parkera ett fordon under en viss tidsperiod
        public void ParkVehicle(Vehicle vehicle, int durationInSeconds)
        {
            // Hitta ledig plats för fordonet
            int startSpot = FindAvailableSpot(vehicle);

            // Kontrollera om det finns en ledig plats
            if (startSpot != -1)
            {
                // Beräkna sluttiden för parkeringen och lägg till fordonet i listan över parkerade fordon
                DateTime endTime = DateTime.Now.AddSeconds(durationInSeconds);
                parkedVehicles.Add((vehicle, startSpot, endTime, false));

                // Kontrollera om fordonet är en motorcykel (MC)
                if (vehicle is MC)
                {
                    if (mcCount.ContainsKey(startSpot))
                    {
                        mcCount[startSpot] += 1; // Öka antalet MC på denna plats
                        if (mcCount[startSpot] == 2) spots[startSpot] = true; // Markera platsen som full om det finns två MC
                    }
                    else
                    {
                        mcCount[startSpot] = 1; // Lägg till första MC på platsen
                    }
                }
                else if (vehicle is Bus)
                {
                    // Markera två sammanhängande platser som upptagna för bussen
                    spots[startSpot] = true;
                    spots[startSpot + 1] = true;
                    Console.WriteLine($"{vehicle.GetType().Name} {vehicle.LPlate} parkerad på platser {startSpot}-{startSpot + 1}");
                }
                else
                {
                    // Markera en plats som upptagen för en bil
                    spots[startSpot] = true;
                    Console.WriteLine($"{vehicle.GetType().Name} {vehicle.LPlate} parkerad på plats {startSpot}");
                }
            }
            else
            {
                Console.WriteLine("Inga lediga platser för detta fordon.");
            }
        }










        //Metod som ska testas 
        public int FindAvailableSpot(Vehicle vehicle)
        {
            return 0;
        }





        // Metod för att visa alla parkerade fordon 
        public string ShowParkedVehicles()
        {
            return null;
        }






        // Metod för att checka ut ett fordon från parkeringen baserat på registreringsskylt 
        public string CheckoutVehicle(string lPlate)
        {
            return null;
        }





        // Metod för att kontrollera om något fordon har överskridit sin parkeringstid
        public void CheckForExpiredVehicles()
        {
           
        }





        // Metod för att visa statistik om parkeringsintäkter och antal parkerade fordon
        public void ShowStatistics()
        {
            
        }

    }
}
