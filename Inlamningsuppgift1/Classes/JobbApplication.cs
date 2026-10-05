using System;
using System.Collections.Generic;
using System.Text;

namespace Inlamningsuppgift1.Classes
{
    public  class JobbApplication
    {


        //ATTRIBUTER
        
        public string CompanyName { get; set; }
        
        public string PositionTitle { get; set; }
       
        public enum ApplicationStatus
        {
            Applied,
            Interview,
            Offer,
            Rejected
        }
        
        public DateTime ApplicationDate { get; set; }
        
        public DateTime? ResponseDate { get; set; }
        
        public int SalaryExpectation { get; set; }

        //METODER
        //Returnerar antal dagar sedan ansökan skickades.
        public int GetDaysSinceApplied()
        {
            return (DateTime.Now - ApplicationDate).Days;
        }
        //Returnerar en kort sammanfattning av ansökan.
        public string GetSummary()
        {
            return $"Company: {CompanyName}, Position: {PositionTitle}, Status: {ApplicationStatus}, Applied: {ApplicationDate.ToShortDateString()}, Response: {(ResponseDate.HasValue ? ResponseDate.Value.ToShortDateString() : "N/A")}, Salary Expectation: {SalaryExpectation}";
        }


    }
}
