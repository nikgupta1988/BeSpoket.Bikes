using AutoMapper;
using BeSpoked.Bikes.API.Data;
using BeSpoked.Bikes.API.Models;
using BeSpoked.Bikes.API.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace BeSpoked.Bikes.API.Repository
{
    public class SqlSalesPersonRepo : ISalesPersonRepo
    {
        private readonly IMapper mapper;
        private readonly BikesDbContext bikesDbContext;

        public SqlSalesPersonRepo(IMapper mapper, BikesDbContext bikesDbContext)
        {
            this.mapper = mapper;
            this.bikesDbContext = bikesDbContext;
        }
        public async Task<SalesPerson> AddsalePersonAsync(AddorUpdateSalePerson salePersonreq)
        {
            var salePerson = mapper.Map<SalesPerson>(salePersonreq);
            await bikesDbContext.SalesPerson.AddAsync(salePerson);
            await bikesDbContext.SaveChangesAsync();
            return salePerson;
        }

        public async Task<List<SalesPerson>> GetsalePersonAsync()
        {
            return await bikesDbContext.SalesPerson.ToListAsync();
        }

        public async Task<SalesPerson> GetsalePersonByIDAsync(Guid id)
        {
            return await bikesDbContext.SalesPerson.FirstAsync(p => p.SP_ID == id);
        }
        

        public async Task<bool> IssalePersonDuplicateAsync(AddorUpdateSalePerson salePersonreq)
        {
            string Combination = salePersonreq.firstName + salePersonreq.lastName + salePersonreq.address;
            
            return await bikesDbContext.SalesPerson.AnyAsync(p => (p.firstName+p.lastName+p.address).ToUpper() == Combination.ToUpper());
        }

        public async Task<SalesPerson?> UpdatesalePersonAsync(Guid id, AddorUpdateSalePerson sapePersonreq)
        {
            var salePersonxist = await bikesDbContext.SalesPerson.FirstOrDefaultAsync(p => p.SP_ID == id);
            if (salePersonxist == null)
            {
                return null;
            }

            var salepersonReq = mapper.Map<SalesPerson>(sapePersonreq);
            await bikesDbContext.SaveChangesAsync();
            return salePersonxist;

        }
    }
}
