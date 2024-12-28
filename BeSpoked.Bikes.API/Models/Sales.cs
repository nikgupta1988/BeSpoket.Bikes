namespace BeSpoked.Bikes.API.Models
{
    public class Sales
    {
        public Guid SaleID { get; set; }
        public DateTime sellDate { get; set; }

        public Guid ProductsProductID { get; set; }

        public Guid SalesPersonSP_ID { get; set; }
        public Guid CustomerCUST_ID { get; set; }

        //Nabigation props 
        public Products Products { get; set; }
        public SalesPerson SalesPerson { get; set; }
        public Customer Customer { get; set; }

    }
}
