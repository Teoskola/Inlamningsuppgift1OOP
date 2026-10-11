using System;
using System.Collections.Generic;
using System.Text;

namespace Inlamningsuppgift1.Classes
{
    public class JobManager
    {
        

        // Applications | List<JobApplication> - Samling av alla ansökningar
        List<JobbApplication> Applications { get; set; } = new List<JobbApplication>();

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
        public void UpdateStatus(JobbApplication application, JobbApplication.ApplicationStatus newStatus)
        {
            application.status = newStatus;
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
        ////Filtrerar med LINQ efter status(VG del)
        //public void ShowByStatus(JobbApplication.ApplicationStatus status)
        //{
        //    var filteredApplications = Applications.Where(a => a.ApplicationStatus == status);
        //    foreach (var application in filteredApplications)
        //    {
        //        Console.WriteLine(application.GetSummary());
        //    }
        //}
        //// Visar statistik med LINQ(Count, Average, OrderBy, Where) (VG del)
        //public void ShowStatistics()
        //{
        //    var totalApplications = Applications.Count;
        //    var averageSalaryExpectation = Applications.Average(a => a.SalaryExpectation);
        //    var applicationsByStatus = Applications.GroupBy(a => a.ApplicationStatus)
        //                                           .Select(g => new { Status = g.Key, Count = g.Count() })
        //                                           .OrderBy(g => g.Status);
        //    Console.WriteLine($"Total Applications: {totalApplications}");
        //    Console.WriteLine($"Average Salary Expectation: {averageSalaryExpectation}");
        //    foreach (var statusGroup in applicationsByStatus)
        //    {
        //        Console.WriteLine($"Status: {statusGroup.Status}, Count: {statusGroup.Count}");
        //    }
        //}
    }
}
