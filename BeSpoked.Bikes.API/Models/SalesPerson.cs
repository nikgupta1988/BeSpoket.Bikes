using System.Security.Principal;

namespace BeSpoked.Bikes.API.Models
{
    public class SalesPerson
    {
        public Guid SP_ID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public DateTime startDate { get; set; }
        public DateTime terminationdate { get; set; }
        public string manager { get; set; }
    }
}
