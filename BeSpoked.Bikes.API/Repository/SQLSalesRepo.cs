using AutoMapper;
using BeSpoked.Bikes.API.Data;
using BeSpoked.Bikes.API.Models;
using BeSpoked.Bikes.API.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace BeSpoked.Bikes.API.Repository
{
    public class SQLSalesRepo : IsaleRepo
    {
        private readonly BikesDbContext bikesDbContext;
        private readonly IMapper mapper;

        public SQLSalesRepo(BikesDbContext bikesDbContext, IMapper mapper)
        {
            this.bikesDbContext = bikesDbContext;
            this.mapper = mapper;
        }
        public async Task<Sales> CreateSellAsync(Sales sellReq)
        {
            try
            {

                await bikesDbContext.Sales.AddAsync(sellReq);
                await bikesDbContext.SaveChangesAsync();
                return sellReq;
            }
            catch(Exception ex)
            {
                return null;

            }
        }

        public async Task<List<Sales>> GetSellAsync()
        {
            var result = await bikesDbContext.Sales.Include("Products").Include("SalesPerson").Include("Customer").ToListAsync();
            return result;
        }
    }
}
