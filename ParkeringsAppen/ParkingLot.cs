using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static ParkeringsAppen.Vehicle;

namespace ParkeringsAppen
{

    public class ParkingLot
    {
        private int totalSpots = 25;
        private double earningsFromParking = 0;
        private double earningsFromFines = 0;
        private bool[] spots = new bool[25];
        private Dictionary<int, int> mcCount = new Dictionary<int, int>();
        private List<(Vehicle vehicle, int startSpot, DateTime endTime, bool hasFine)> parkedVehicles = new List<(Vehicle, int, DateTime, bool)>();

        public void ParkVehicle(Vehicle vehicle, int durationInSeconds)
        {
            int startSpot = FindAvailableSpot(vehicle);
            if (startSpot != -1)
            {
                DateTime endTime = DateTime.Now.AddSeconds(durationInSeconds);
                parkedVehicles.Add((vehicle, startSpot, endTime, false));

                if (vehicle is MC)
                {
                    if (mcCount.ContainsKey(startSpot))
                    {
                        mcCount[startSpot] += 1;
                        if (mcCount[startSpot] == 2) spots[startSpot] = true;
                    }
                    else
                    {
                        mcCount[startSpot] = 1;
                    }
                    Console.WriteLine($"{vehicle.GetType().Name} {vehicle.LPlate} parkerad på plats {startSpot}");
                }
                else if (vehicle is Bus)
                {
                    spots[startSpot] = true;
                    spots[startSpot + 1] = true;
                    Console.WriteLine($"{vehicle.GetType().Name} {vehicle.LPlate} parkerad på platser {startSpot}-{startSpot + 1}");
                }
                else
                {
                    spots[startSpot] = true;
                    Console.WriteLine($"{vehicle.GetType().Name} {vehicle.LPlate} parkerad på plats {startSpot}");
                }
            }
            else
            {
                Console.WriteLine("Inga lediga platser för detta fordon.");
            }
        }

        public int FindAvailableSpot(Vehicle vehicle)
        {
            for (int i = 0; i < totalSpots; i++)
            {
                if (vehicle is MC)
                {
                    if (!spots[i] || (mcCount.ContainsKey(i) && mcCount[i] < 2))
                    {
                        return i;
                    }
                }
                else if (vehicle is Bus)
                {
                    if (i + 1 < totalSpots && !spots[i] && !spots[i + 1] &&
                        !mcCount.ContainsKey(i) && !mcCount.ContainsKey(i + 1))
                    {
                        return i;
                    }
                }
                else
                {
                    if (!spots[i] && !mcCount.ContainsKey(i))
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        public void ShowParkedVehicles()
        {
            if (parkedVehicles.Count == 0)
            {
                Console.WriteLine("Inga fordon är parkerade.");
                return;
            }

            Console.WriteLine("Parkerade fordon:");
            foreach (var (vehicle, startSpot, endTime, hasFine) in parkedVehicles)
            {
                string timeRemaining = (endTime > DateTime.Now) ? $"{(endTime - DateTime.Now).Seconds} sek kvar" : "Tiden ute";
                Console.WriteLine($"{vehicle.GetType().Name} - {vehicle.LPlate} - {vehicle.Colour} - Plats {startSpot}" +
                                  (vehicle is Bus ? $"-{startSpot + 1}" : "") + $" - {timeRemaining} {(hasFine ? "- Botad" : "")}");
            }
        }

        public void CheckForExpiredVehicles()
        {
            for (int i = 0; i < parkedVehicles.Count; i++)
            {
                var (vehicle, startSpot, endTime, hasFine) = parkedVehicles[i];
                if (endTime < DateTime.Now && !hasFine)
                {
                    Console.WriteLine($"{vehicle.LPlate} har överstigit parkeringstiden. Bot på 500 kr.");
                    earningsFromFines += 500;
                    parkedVehicles[i] = (vehicle, startSpot, endTime, true); // Sätter hasFine till true
                }
            }
        }

        public void ShowStatistics()
        {
            int totalVehicles = parkedVehicles.Count;
            Console.WriteLine($"Antal fordon i parkeringen: {totalVehicles}");
            Console.WriteLine($"Totala intäkter från parkering: {earningsFromParking} kr");
            Console.WriteLine($"Totala intäkter från böter: {earningsFromFines} kr");
        }

        public void CheckoutVehicle(string lPlate)
        {
            // Hitta index för fordonet i listan baserat på registreringsnummer
            var entryIndex = parkedVehicles.FindIndex(p => p.vehicle.LPlate.Equals(lPlate, StringComparison.OrdinalIgnoreCase));

            if (entryIndex >= 0)
            {
                var (vehicle, startSpot, endTime, hasFine) = parkedVehicles[entryIndex];
                double baseParkingDuration = (endTime - DateTime.Now).TotalSeconds; // Planerad tid
                double overstayDuration = Math.Max(0, (DateTime.Now - endTime).TotalSeconds); // Tid utöver planerat

                // Totala kostnaden är planerad tid + övertid
                double totalCost = (baseParkingDuration + overstayDuration) * 1.5;
                earningsFromParking += totalCost;

                // Frigör parkeringsplatsen
                if (vehicle is MC && mcCount.ContainsKey(startSpot))
                {
                    mcCount[startSpot]--;
                    if (mcCount[startSpot] == 0) mcCount.Remove(startSpot);
                    spots[startSpot] = mcCount.ContainsKey(startSpot) && mcCount[startSpot] == 2;
                }
                else if (vehicle is Bus)
                {
                    spots[startSpot] = false;
                    spots[startSpot + 1] = false;
                }
                else
                {
                    spots[startSpot] = false;
                }

                parkedVehicles.RemoveAt(entryIndex); // Ta bort fordonet från parkerade fordon

                Console.WriteLine($"Fordon {lPlate} har checkats ut. Total parkeringstid: {baseParkingDuration + overstayDuration} sekunder. Kostnad: {totalCost} kr.");
            }
            else
            {
                Console.WriteLine("Fordonet kunde inte hittas.");
            }
        }
    }
}