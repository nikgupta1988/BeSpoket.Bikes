using BeSpoked.Bikes.API.Models.Dto;
using BeSpoked.Bikes.API.Models;

namespace BeSpoked.Bikes.API.Repository
{
    public interface ISalesPersonRepo
    {
        Task<List<SalesPerson>> GetsalePersonAsync();
        
        Task<SalesPerson> GetsalePersonByIDAsync(Guid id);

        Task<SalesPerson> AddsalePersonAsync(AddorUpdateSalePerson sapePersonreq);

        Task<SalesPerson?> UpdatesalePersonAsync(Guid id, AddorUpdateSalePerson sapePersonreq);

        Task<bool> IssalePersonDuplicateAsync(AddorUpdateSalePerson sapePersonreq);
    }
}
