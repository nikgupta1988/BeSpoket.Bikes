namespace BeSpoked.Bikes.API.Models
{
    public class Sales
    {
        public Guid SaleID { get; set; }
        public Guid ProductID { get; set; }

        public Guid SP_ID { get; set; }
        public Guid CUST_ID { get; set; }

        public DateTime sellDate { get; set; }


        //Nabigation props 
        public Products Products { get; set; }
        public SalesPerson SalesPerson { get; set; }
        public Customer Customer { get; set; }

    }
}
