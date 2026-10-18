using Inlamningsuppgift1.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace Inlamningsuppgift1
{
    public static class Helper
    {
        // Ändrar färgen på texten i konsolen beroende på status och skriver ut en sammanfattning av ansökan
        public static void PrintApplication(JobApplication application)
        {
            // 1. Välj färg beroende på status
           if (application.Status == JobApplication.ApplicationStatus.Applied)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else if (application.Status == JobApplication.ApplicationStatus.Interview)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            else if (application.Status == JobApplication.ApplicationStatus.Offer)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (application.Status == JobApplication.ApplicationStatus.Rejected)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            // 2. Skriv ut application.GetSummary()
            Console.WriteLine(application.GetSummary());
            // 3. Återställ färgen
            Console.ResetColor();
        }


    }
}
