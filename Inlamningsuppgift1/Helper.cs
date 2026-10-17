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
        public static void PrintApplication(JobbApplication application)
        {
            // 1. Välj färg beroende på status
           if (application.status == JobbApplication.ApplicationStatus.Applied)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else if (application.status == JobbApplication.ApplicationStatus.Interview)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            else if (application.status == JobbApplication.ApplicationStatus.Offer)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (application.status == JobbApplication.ApplicationStatus.Rejected)
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
