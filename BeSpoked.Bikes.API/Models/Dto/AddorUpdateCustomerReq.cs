﻿namespace BeSpoked.Bikes.API.Models.Dto
{
    public class AddorUpdateCustomerReq
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public DateTime startDate { get; set; }
    }
}
