using System.Runtime.ConstrainedExecution;
using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using Inlamningsuppgift1.Classes;

namespace Inlamningsuppgift1
{
    public class Program
    {
        static void Main(string[] args)
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



            //Gör två nya objekt från klasserna
            JobbApplication ApplicationObject = new JobbApplication();
            JobManager ManagerObject = new JobManager();

            //En meny med switchcase i en while loop där du hanterar ansökningarna
            while (true)
            {
                
                Console.WriteLine("Hej välj ett av följande alternativ:");
                Console.WriteLine("1. Lägg till ny ansökan");
                Console.WriteLine("2. Visa alla ansökningar");
                Console.WriteLine("3. Filtrera ansökningar efter status");
                Console.WriteLine("4. Sortera ansökningar efter datum");
                Console.WriteLine("5. Totalt antal ansökningar");
                Console.WriteLine("6. Antal per status");
                Console.WriteLine("7. Genomsnittlig svarstid");
                Console.WriteLine("8.Uppdatera status på en ansökan ");
                Console.WriteLine("9.Ta bort en ansökan ");
                Console.WriteLine("0. Avsluta programmet ");


                // Läs användar input och välj från switch case
                string val = Console.ReadLine();
                switch (val)
                {
                    case "1":
                        Console.WriteLine("Lägg till ny ansökan");
                        ManagerObject.AddJob(ApplicationObject);
                        break;
                    case "2":
                        Console.WriteLine("Visa alla ansökningar");
                        ManagerObject.ShowAll();
                        break; 
                    case "3":
                        Console.WriteLine("Filtrera ansökningar efter status - ej implementerat");
                        break;
                    case "4":
                        Console.WriteLine("Sortera ansökningar efter datum - ej implementerat");
                        break;

                    case "5":
                        Console.WriteLine("Totalt antal ansökningar - ej implementerat");
                        break;
                    case "6":
                        Console.WriteLine("Antal per status - ej implementerat");
                        break;
                    case "7":
                        Console.WriteLine("Genomsnittlig svarstid - ej implementerat");
                        break;
                    case "8":
                        Console.WriteLine("Uppdatera status på en ansökan - ej implementerat");
                        break;
                    case "9":
                        Console.WriteLine("Ta bort en ansökan - ej implementerat");
                        break;
                    case "0":
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
