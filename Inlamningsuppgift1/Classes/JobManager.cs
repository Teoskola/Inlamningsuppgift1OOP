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
        {
            Console.WriteLine("Till vilket företag ansöker du?");
            application.CompanyName = Console.ReadLine();
            Console.WriteLine("Till vilken position ansöker du?");
            application.PositionTitle = Console.ReadLine();
            application.ApplicationDate = DateTime.Now;
            Console.WriteLine("Hur mycket lön förväntar du dig skriv en siffra:");
            application.SalaryExpectation = int.Parse(Console.ReadLine());
            Console.WriteLine($"Din ansökan har tagits emot.");
            
            Applications.Add(application);


        }
        //Ändrar status på en befintlig ansökan
        public void UpdateStatus()
        {
            if (Applications.Count == 0)
            {
                Console.WriteLine("Det finns inga ansökningar att uppdatera.");
                return;
            }
            int count = 0;
            foreach (var application in Applications)
            {
                Console.WriteLine($" Applikationsnummer: {count++}, Företag: {application.CompanyName}, Position: {application.PositionTitle}, Status: {application.status}, Ansökningsdatum: {application.ApplicationDate.ToShortDateString()}, Svarsdagen: {(application.ResponseDate.HasValue ? application.ResponseDate.Value.ToShortDateString() : "Ingen")}, Löneförväntning: {application.SalaryExpectation}");

            }

            Console.WriteLine("Ange applikationsnummer för att ändra ansökan:");
            int index = int.Parse(Console.ReadLine());
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
        {
            if (Applications.Count > 0)
                foreach (var application in Applications)
                {
                    Console.WriteLine(application.GetSummary());
                }
            else
            { Console.WriteLine("Det finns inga ansökningar"); }

        }
        //Filtrerar med LINQ efter status
        public void ShowByStatus(JobbApplication.ApplicationStatus status)
        {
            var filteredApplications = Applications.Where(a => a.status == status);    
            foreach (var application in filteredApplications)
            {
                Console.WriteLine(application.GetSummary());
            }
        }
        // Visar statistik antal applikationer och genomsnittlig löneförväntning samt genomsnittlig svarstid
        public void ShowStatistics()
        {   
            var totalApplications = Applications.Count;
            
            var averageSalaryExpectation = Applications.Average(app => app.SalaryExpectation); //
            var applicationsByStatus = Applications.GroupBy(app => app.status)
            .Select(group => new { Status = group.Key, Count = group.Count() })
            .OrderBy(group => group.Status);

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

            foreach (var statusGroup in applicationsByStatus)
            {
                Console.WriteLine($"Status: {statusGroup.Status}, Count: {statusGroup.Count}");
            }
        }
    }
}
