﻿namespace BeSpoked.Bikes.API.Models
{
    public class Customer
    {
        public Guid CUST_ID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public DateTime startDate { get; set; }
    }
}
