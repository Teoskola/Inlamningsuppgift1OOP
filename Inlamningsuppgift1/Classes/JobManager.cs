using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Inlamningsuppgift1.Classes
{
    public class JobManager
    {
        

        // Applications | List<JobApplication> - Samling av alla ansökningar
        public List<JobbApplication> Applications { get; set; } = new List<JobbApplication>();
        
        

        //METODER
        //Lägger till en ny ansökan
        public void AddJob(JobbApplication application)
        {//Ber användaren att ange information om ansökan
            Console.WriteLine("Till vilket företag ansöker du?");
            application.CompanyName = Console.ReadLine();
            Console.WriteLine("Till vilken position ansöker du?");
            application.PositionTitle = Console.ReadLine();
            application.ApplicationDate = DateTime.Now;
            Console.WriteLine("Hur mycket lön förväntar du dig skriv en siffra:");
            application.SalaryExpectation = int.Parse(Console.ReadLine());
            Console.WriteLine($"Din ansökan har tagits emot.");
            //Lägger till ansökan i listan
            Applications.Add(application);


        }
        //Ändrar status på en befintlig ansökan
        public void UpdateStatus()
        {   //Om det inte finns några ansökningar skrivs ett meddelande ut och metoden avslutas
            if (Applications.Count == 0)
            {
                Console.WriteLine("Det finns inga ansökningar att uppdatera.");
                return;
            }
            int count = 0; //räknar ut applikationsnummer för att kunna välja vilken ansökan man vill ändra
            foreach (var application in Applications)
            {
                Console.WriteLine($" Applikationsnummer: {count++}, Företag: {application.CompanyName}, Position: {application.PositionTitle}, Status: {application.status}, Ansökningsdatum: {application.ApplicationDate.ToShortDateString()}, Svarsdagen: {(application.ResponseDate.HasValue ? application.ResponseDate.Value.ToShortDateString() : "Ingen")}, Löneförväntning: {application.SalaryExpectation}");

            }
            //Ber användaren att ange applikationsnummer för att ändra status på en ansökan
            Console.WriteLine("Ange applikationsnummer för att ändra ansökan:");
            int index = int.Parse(Console.ReadLine());
            //Om index är giltigt uppdateras status på ansökan
            if (index >= 0 && index < Applications.Count)
            {
                Console.WriteLine("Ange ny status för ansökan:");
                Console.WriteLine("1. Applied");
                Console.WriteLine("2. Interview");
                Console.WriteLine("3. Offer");
                Console.WriteLine("4. Rejected");

                //Switch statement uppdaterar status baserat på input
                Applications[index].status = Console.ReadLine()
                switch
                {   
                    "1" => JobbApplication.ApplicationStatus.Applied,
                    "2" => JobbApplication.ApplicationStatus.Interview,
                    "3" => JobbApplication.ApplicationStatus.Offer,
                    "4" => JobbApplication.ApplicationStatus.Rejected,
                    _ => Applications[index].status// om det är fel input ha kvar status
                };

                Applications[index].ResponseDate = DateTime.Now;
            }
            
            
            
        }
        //Visar alla ansökningar
        public void ShowAll()
        {   //Om det finns ansökningar skrivs de ut annars skrivs ett meddelande ut
            if (Applications.Count > 0)
                foreach (var application in Applications)
                {
                    Helper.PrintApplication(application);
                }
            else
            { Console.WriteLine("Det finns inga ansökningar"); }

        }
        //Filtrerar efter status
        public void ShowByStatus()
        {
            //Väljer status att filtrera efter och visar alla ansökningar med den statusen
            Console.WriteLine("Välj status att filtrera efter:");
            Console.WriteLine("1. Applied");
            Console.WriteLine("2. Interview");
            Console.WriteLine("3. Offer");
            Console.WriteLine("4. Rejected");
            JobbApplication.ApplicationStatus SelectedStatus;

            //Switch statement för att välja status baserat på input
            string input = Console.ReadLine();
            switch(input)
            {
                case "1":
                    SelectedStatus = JobbApplication.ApplicationStatus.Applied;
                    break;
                case "2":
                    SelectedStatus = JobbApplication.ApplicationStatus.Interview;
                    break;
                case "3":
                    SelectedStatus = JobbApplication.ApplicationStatus.Offer;
                    break;
                case "4":
                    SelectedStatus = JobbApplication.ApplicationStatus.Rejected;
                    break;
                default:
                    Console.WriteLine("Felaktig input, visar alla ansökningar.");
                    return;

            }//Filtrerar ansökningar baserat på vald status och skriver ut dem
            var filteredApplications = Applications.Where(a => a.status == SelectedStatus);
            foreach (var application in filteredApplications)
            {
                Helper.PrintApplication(application);
            }
        }

        public void SortApplicationsByDate()
        {
            // Sorterar ansökningarna efter datum med OrderBy och skriver ut dem
            var ordered = Applications.OrderBy(a => a.ApplicationDate);
            Console.WriteLine("Ansökningar sorterade efter datum:");
            foreach (var application in ordered)
            {
                Helper.PrintApplication(application);
            }
        }

        public void RemoveApplication()
        {
            if (Applications.Count > 0)
            {
                int count = 0;
                foreach (var application in Applications)
                {
                    Console.WriteLine($" Applikationsnummer: {count++}, Företag: {application.CompanyName}, Position: {application.PositionTitle}, Status: {application.status}, Ansökningsdatum: {application.ApplicationDate.ToShortDateString()}, Svarsdagen: {(application.ResponseDate.HasValue ? application.ResponseDate.Value.ToShortDateString() : "Ingen")}, Löneförväntning: {application.SalaryExpectation}");

                }

                Console.WriteLine("Ange applikationsnummer för att ta bort ansökan:");
                int index = int.Parse(Console.ReadLine());
                if (index >= 0 && index < Applications.Count)
                {
                    Applications.RemoveAt(index);

                }
                else
                {
                    Console.WriteLine("Ogiltigt applikationsnummer.");
                }
                
            }
            else
            {
                Console.WriteLine("Det finns inga ansökningar att ta bort.");
               
            }
        }
        // Visar statistik antal applikationer och genomsnittlig löneförväntning samt genomsnittlig svarstid
        public void ShowStatistics()
        {   //räknar ut total antal ansökningar
            var totalApplications = Applications.Count;
            //räknar ut genomsnittlig löneförväntan
            var averageSalaryExpectation = Applications.Average(app => app.SalaryExpectation);
            //räknar ut antal ansökningar per status
            var applicationsByStatus = Applications.GroupBy(app => app.status)
            .Select(group => new { Status = group.Key, Count = group.Count() })//selecterar key och count för att kunna skriva ut
            .OrderBy(group => group.Status); //sorterar efter status i alfabetisk ordning

            //räknar ut genomsnittlig svarstid i dagar
            var averageResponseTime = Applications
            .Where(a => a.ResponseDate != null)
            .Average(a => (a.ResponseDate - a.ApplicationDate)?.TotalDays);
            //tar totaldays och konverterar till TimeSpan
            TimeSpan averageResponseTimeSpan = TimeSpan.FromDays(averageResponseTime ?? 0);

            //Skriver ut statistiken
            Console.WriteLine($"Totala ansökningar: {totalApplications}");
            Console.WriteLine($"Genomsnittlig löneförväntan: {averageSalaryExpectation}");
            Console.WriteLine($"Genomsnittlig svarstid: {averageResponseTimeSpan.Days} dagar och {averageResponseTimeSpan.Hours} timmar.");
            
            //Skriver ut antal ansökningar per status
            foreach (var statusGroup in applicationsByStatus)
            {
                Console.WriteLine($"Status: {statusGroup.Status}, Count: {statusGroup.Count}");
            }
        }
    }
}
