using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BasicCalculatorWeb.Models
{
    public class RequestLog
    {
        // Max records to display
        public const int Limit = 10;

        public int Id { get; set; }

        [Display(Name = "IP Address:")]
        public String IPAddress { get; set; }

        [Display(Name = "Calculation Performed:")]
        public String Calculation { get; set; }

        [Display(Name = "Date:")]
        public DateTime RequestDate { get; set; }
    }
}
