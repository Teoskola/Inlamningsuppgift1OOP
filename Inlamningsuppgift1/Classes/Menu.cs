using System;
using System.Collections.Generic;
using System.Text;

namespace Inlamningsuppgift1.Classes
{
    public static class Menu
    {
        public static void ShowMenu()
        {




            //MALL FÖR MENY

            //            Meny(krav) while loop med en switch case


            //Programmet ska innehålla minst följande alternativ:
            //Lägg till ny ansökan
            //Visa alla ansökningar
            //Filtrera ansökningar efter status(LINQ) (VG del)
            //Sortera ansökningar efter datum(OrderBy) (VG del)
            //Visa statistik:
            //Totalt antal ansökningar
            //Antal per status(VG del)
            //Genomsnittlig svarstid(VG del)
            // Uppdatera status på en ansökan
            // Ta bort en ansökan
            // Avsluta programmet





            //Skapa en instans av JobManager-klassen
            JobManager ManagerObject = new JobManager();




            //En meny med switchcase i en while loop där du hanterar ansökningarna
            while (true)
            {
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("Jobbansökningshanteraren!");
                Console.WriteLine("Välj ett av följande alternativ:");
                Console.WriteLine("1. Lägg till ny ansökan"); //klar
                Console.WriteLine("2. Visa alla ansökningar"); //klar
                Console.WriteLine("3. Filtrera ansökningar efter status");//klar
                Console.WriteLine("4. Sortera ansökningar efter datum");//klar
                Console.WriteLine("5. Visa statistik"); //klar
                Console.WriteLine("6. Uppdatera status på en ansökan");//klar
                Console.WriteLine("7. Ta bort en ansökan"); //klar
                Console.WriteLine("8.Avsluta "); //klar



                // Läs användar input och välj från switch case
                string val = Console.ReadLine();
                switch (val)
                {
                    case "1"://
                        Console.WriteLine("Lägg till ny ansökan");
                        // Skapa en ny instans av JobbApplication och lägg till den i listan
                        JobbApplication ApplicationObject = new JobbApplication();
                        ManagerObject.AddJob(ApplicationObject);
                        break;
                    case "2":
                        Console.WriteLine("Visa alla ansökningar");
                        ManagerObject.ShowAll();
                        break;
                    case "3":
                        Console.WriteLine("Filtrera ansökningar efter status");

                        ManagerObject.ShowByStatus();
                        break;
                    case "4":
                        Console.WriteLine("Sortera ansökningar efter datum  ");
                        // Sorterar ansökningarna efter datum med OrderBy och skriver ut dem
                        ManagerObject.SortApplicationsByDate();
                        break;

                    case "5":
                        Console.WriteLine("Statistik");
                        ManagerObject.ShowStatistics();

                        break;
                    case "6":
                        Console.WriteLine("Uppdatera status på en ansökan");

                        ManagerObject.UpdateStatus();

                        break;
                    case "7":
                        Console.WriteLine("Ta bort en ansökan");
                        ManagerObject.RemoveApplication();
                        break;


                    case "8":
                        Console.WriteLine("Avslutar...");
                        return;
                    default:
                        Console.WriteLine("Ogiltigt val.");
                        break;
                }

            }
        }

    }




        }



    

