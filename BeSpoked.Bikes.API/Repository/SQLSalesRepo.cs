using AutoMapper;
using BeSpoked.Bikes.API.Data;
using BeSpoked.Bikes.API.Models;
using BeSpoked.Bikes.API.Models.Dto;

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

            
            await bikesDbContext.Sales.AddAsync(sellReq);
            await bikesDbContext.SaveChangesAsync();
            return sellReq;
        }

        public Task<List<Sales>> GetSellAsync()
        {
            throw new NotImplementedException();
        }
    }
}
