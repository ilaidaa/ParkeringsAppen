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

