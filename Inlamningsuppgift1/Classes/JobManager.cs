using System;
using System.Collections.Generic;
using System.Text;

namespace Inlamningsuppgift1.Classes
{
    public class JobManager
    {
        //ATTRIBUTER

        // Applications | List<JobApplication> - Samling av alla ansökningar
        List<JobbApplication> Applications { get; set; } = new List<JobbApplication>();

        //METODER
        //Lägger till en ny ansökan
        public void AddJob(JobbApplication application)
        {
            Applications.Add(application);
        }
        //Ändrar status på en befintlig ansökan
        public void UpdateStatus(JobbApplication application, JobbApplication.ApplicationStatus newStatus)
        {
            application.ApplicationStatus = newStatus;
        }
        //Visar alla ansökningar
        public void ShowAll()
        {
            foreach (var application in Applications)
            {
                Console.WriteLine(application.GetSummary());
            }
        }
        //Filtrerar med LINQ efter status(VG del)
        public void ShowByStatus(JobbApplication.ApplicationStatus status)
        {
            var filteredApplications = Applications.Where(a => a.ApplicationStatus == status);
            foreach (var application in filteredApplications)
            {
                Console.WriteLine(application.GetSummary());
            }
        }
        // Visar statistik med LINQ(Count, Average, OrderBy, Where) (VG del)
        public void ShowStatistics()
        {
            var totalApplications = Applications.Count;
            var averageSalaryExpectation = Applications.Average(a => a.SalaryExpectation);
            var applicationsByStatus = Applications.GroupBy(a => a.ApplicationStatus)
                                                   .Select(g => new { Status = g.Key, Count = g.Count() })
                                                   .OrderBy(g => g.Status);
            Console.WriteLine($"Total Applications: {totalApplications}");
            Console.WriteLine($"Average Salary Expectation: {averageSalaryExpectation}");
            foreach (var statusGroup in applicationsByStatus)
            {
                Console.WriteLine($"Status: {statusGroup.Status}, Count: {statusGroup.Count}");
            }
        }
    }
}
