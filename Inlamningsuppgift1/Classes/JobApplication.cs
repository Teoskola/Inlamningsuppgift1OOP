using System;
using System.Collections.Generic;
using System.Text;

namespace Inlamningsuppgift1.Classes
{
    public  class JobApplication
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
        public ApplicationStatus Status { get; set; }
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
            return $"Företag: {CompanyName}, Position: {PositionTitle}, Status: {Status}, AnsökningsDatum: {ApplicationDate.ToShortDateString()}, Respons: {(ResponseDate.HasValue ? ResponseDate.Value.ToShortDateString() : "N/A")}, Förväntad lön: {SalaryExpectation}";
        }


    }
}
