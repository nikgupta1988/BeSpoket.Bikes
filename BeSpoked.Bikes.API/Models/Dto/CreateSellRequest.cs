namespace BeSpoked.Bikes.API.Models.Dto
{
    public class CreateSellRequest
    {
        
        public DateTime sellDate { get; set; }

        public Guid ProductID { get; set; }

        public Guid SP_ID { get; set; }
        public Guid CUST_ID { get; set; }
        
    }
}
