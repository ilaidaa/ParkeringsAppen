using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkeringsAppen
{

    // Basklassen fordon
    public abstract class Vehicle
    {
        // Skapa propertys
        public string Colour { get; set; }
        public string LPlate { get; set; }  // Registreringsnummer

        // Konstruktor
        public Vehicle(string colour, string lPlate)
        {
            Colour = colour;
            LPlate = lPlate;
        }

        // Abstrakt metod som ska implementeras av subklasserna för att visa information om fordonet
        public abstract void DisplayInfo();

        // Statisk metod för att generera ett slumpmässigt fordon. Kan vara en bil, motorcykel eller buss
        public static Vehicle GenerateRandomVehicle()
        {
            string[] colors = { "Röd", "Svart", "Grön", "Gul", "Blå" };
            string color = colors[Random.Shared.Next(colors.Length)];
            string licensePlate = $"ABC{Random.Shared.Next(100, 999)}";  // Genererar registreringsnummer i formatet ABC123

            int type = Random.Shared.Next(1, 4);  // Slumpmässigt val av fordonstyp

            if (type == 1)
                return new Car(color, licensePlate, Random.Shared.Next(2) == 1);
            if (type == 2)
                return new MC(color, licensePlate, "Yamaha");

            return new Bus(color, licensePlate, Random.Shared.Next(10, 60));
        }
    }

    // Subklass för personbil
    public class Car : Vehicle
    {
        public bool Electric { get; set; }

        // Konstruktor
        public Car(string colour, string lPlate, bool electric) : base(colour, lPlate)
        {
            Electric = electric;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Bil:\tRegistreringsnummer: {LPlate}\tFärg: {Colour}\tElektrisk: {Electric}");
        }
    }

    // Subklass för MC
    public class MC : Vehicle
    {
        public string Brand { get; set; }

        // Konstruktor
        public MC(string colour, string lPlate, string brand) : base(colour, lPlate)
        {
            Brand = brand;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"MC:\tRegistreringsnummer: {LPlate}\tFärg: {Colour}\tMärke: {Brand}");
        }
    }

    // Subklass för Buss
    public class Bus : Vehicle
    {
        public int Passengers { get; set; }

        // Konstruktor
        public Bus(string colour, string lPlate, int passengers) : base(colour, lPlate)
        {
            Passengers = passengers;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Buss:\tRegistreringsnummer: {LPlate}\tFärg: {Colour}\tPassagerare: {Passengers}");
        }
    }



}

    

