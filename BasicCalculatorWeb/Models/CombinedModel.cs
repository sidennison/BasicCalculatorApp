using System.Collections.Generic;

namespace BasicCalculatorWeb.Models
{
    // Combines two models into a single model for return to the view
    public class CombinedModel
    {
        public Calculation Calculation { get; set; }
        public IEnumerable<RequestLog> RequestLogs { get; set; }
    }
}
