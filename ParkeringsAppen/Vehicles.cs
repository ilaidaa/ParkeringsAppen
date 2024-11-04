using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkeringsAppen
{

    public class Vehicles
    {

        //Basklassen fordon
        public abstract class Vehicle
        {
            //Skapa propertys
            public string Colour { get; set; }
            public string LPlate { get; set; }


            //Construktor
            public Vehicle(string colour, string lPlate)
            {
                Colour = colour;
                LPlate = lPlate;
            }



            //En metod i basklassen som är tom, vilket innebär att dne måste fyllas i subklasserna.
            //Detta skapar möjighet för subklasserna att göra metoden på sitt egna sätt som skiljer från resterande klasser
            //Just denna metod är tänkt att ge information om fordonen
            public abstract void DisplayInfo();





            // Statisk metod för att generera ett slumpmässigt fordon. Kan vara en bil, motorcykel eller buss

            public static Vehicle GenerateRandomVehicle()

            {

                // Array med möjliga färger för fordonen

                string[] colors = { "Röd", "Svart", "Grön", "Gul", "Blå" };


                // Slumpmässigt val av färg från colors-arrayen

                string color = colors[Random.Shared.Next(colors.Length)];


                // Genererar en slumpmässig registreringsskylt i formatet "ABC123" med slumpmässiga siffror

                string licensePlate = $"ABC{Random.Shared.Next(100, 999)}";


                // Slumpmässigt val av fordonstyp (1 för bil, 2 för motorcykel, annars buss)

                int type = Random.Shared.Next(1, 4);


                // If-sats som bestämmer vilken typ av fordon som ska skapas baserat på det slumpmässiga numret

                if (type == 1)

                    // Skapar en bil (Car) med ett slumpmässigt värde (sant eller falskt) för om den är elektrisk

                    return new Car(licensePlate, color, Random.Shared.Next(2) == 1);


                if (type == 2)

                    // Skapar en motorcykel (MC) med ett förinställt märke, "Yamaha"

                    return new MC(licensePlate, color, "Yamaha");


                // Skapar en buss (Bus) med ett slumpmässigt antal passagerare mellan 10 och 60

                return new Bus(licensePlate, color, Random.Shared.Next(10, 60));

            }



        }






            //Subklass 1 personbil
            public class Car : Vehicle
            {
                //Unik Property
                public bool Electric { get; set; } = true;


                //Construktor
                public Car(string colour, string lPlate, bool electric) : base(colour, lPlate)
                {
                    Electric = electric;
                }


                //Här används metoden i basklassen för att ge information om just fordonet som finns i denna subklass
                public override void DisplayInfo() //override måste användas då metoden som tas över av basklassen är abstact
                {
                    Console.Write("Bil:\t" + LPlate + "\t" + Colour + "\t" + Electric); //\t är för design d.v.s. mellanrum mellan alla propertys
                }
            }







            //Subklass 2 MC
            public class MC : Vehicle
            {
                //Property
                public string Brand { get; set; }


                //Construktor
                public MC(string colour, string lPlate, string brand) : base(colour, lPlate)
                {
                    Brand = brand;
                }


                //Här används metoden i basklassen för att ge information om just fordonet som finns i denna subklass
                public override void DisplayInfo()
                {
                    Console.Write("MC:\t" + LPlate + "\t" + Colour + "\t" + Brand);
                }
            }







            //Subklass 3 Buss
            public class Bus : Vehicle
            {
                //Property
                public int Passengers { get; set; }


                //Construktor
                public Bus(string colour, string lPlate, int passengers) : base(colour, lPlate)
                {
                    Passengers = passengers;
                }


                //Här används metoden i basklassen för att ge information om just fordonet som finns i denna subklass
                public override void DisplayInfo()
                {
                    Console.Write("Buss:\t" + LPlate + "\t" + Colour + "\t" + Passengers);
                }

            }




        }

    }

