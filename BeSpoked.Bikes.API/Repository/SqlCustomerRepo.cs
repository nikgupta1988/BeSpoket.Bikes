using AutoMapper;
using BeSpoked.Bikes.API.Data;
using BeSpoked.Bikes.API.Models;
using BeSpoked.Bikes.API.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace BeSpoked.Bikes.API.Repository
{
    public class SqlCustomerRepo : IcustomerRepo
    {
        private readonly BikesDbContext bikesDbContext;
        private readonly IMapper mapper;

        public SqlCustomerRepo( BikesDbContext bikesDbContext , IMapper mapper)
        {
            this.bikesDbContext = bikesDbContext;
            this.mapper = mapper;
        }
        public async Task<Customer> AddCustomerAsync(AddorUpdateCustomerReq customerReq)
        {
            var Customer = mapper.Map<Customer>(customerReq);
            await bikesDbContext.Customer.AddAsync(Customer);
            await bikesDbContext.SaveChangesAsync();
            return Customer;
        }

        public async Task<List<Customer>> GetCustomerAsync()
        {
            return await bikesDbContext.Customer.ToListAsync();
        }

        public async Task<Customer> GetCustomerByIDAsync(Guid id)
        {
            return await bikesDbContext.Customer.FirstAsync(p => p.CUST_ID == id);
        }
    }
}
