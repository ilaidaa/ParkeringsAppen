using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ParkeringsAppen.Vehicles;

namespace ParkeringsAppen
{
  
        // Intern klass för parkeringsplats - hanterar parkering och övervakning av fordon
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
        }
}
