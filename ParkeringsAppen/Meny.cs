using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkeringsAppen
{
        internal class Meny
        {
            //En metod som ska hantera val när ett fordon anlädder till parkeringen
            public void ShowMenu()
            {
                Console.WriteLine("Hej! Välkommen till ParkeringSöder!");
                Console.WriteLine(); //För design
                Console.WriteLine("1. Parkera BIL");
                Console.WriteLine("2. Parkera MC");
                Console.WriteLine("3. Parkera BUSS");
                Console.WriteLine("4. Jag är Parkeringsvakt");
                Console.WriteLine("5. Jag är Parekringschef");
                Console.WriteLine(); //För design

                //Variabel för att lagra användaren val den ska in i switch satsen längre ner sen
                int choice;


                //en evighets loop som ska köra till användaen skriver in rätt tal. Syftet med loopen är att hantera fel inmatningar av användaren
                while (true)
                {
                    Console.Write("Vänligen knappa in heltalet ovan som passar in dig bäst: ");

                    // Försök att parsa ANVÄNDARENS input till ett heltal, choice deklarerade du innan whileloppen
                    if (int.TryParse(Console.ReadLine(), out choice))
                    {
                        // Om input är inom giltiga alternaticv vilket är från 1-5, bryt ut ur loopen
                        if (choice >= 1 && choice <= 5)
                        {
                            break;
                        }
                        else //Om den inte är det be användare försöka igen
                        {
                            Console.Write("Vänligen ange ett tal mellan 1 och 5: ");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ogiltig inmatning. Vänligen ange ett heltal.");
                    }
                }

                // Hantera val baserat på användarens input
                switch (choice)
                {
                    case 1:
                        // Kod för att hantera parkering av bil Kommer senare
                        break;
                    case 2:
                        // Kod för att hantera parkering av MC Kommer senare
                        break;
                    case 3:
                        // Kod för att hantera parkering av buss Kommer senare
                        break;
                    case 4:
                        // Kod för parkeringsvaktens alternativ Kommer senare
                        break;
                    case 5:
                        // Kod för parkeringschefens alternativ Kommer senare
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val. Vänligen försök igen.");
                        break;
                }

            }



        }
    }

