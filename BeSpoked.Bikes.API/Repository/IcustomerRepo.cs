using BeSpoked.Bikes.API.Models.Dto;
using BeSpoked.Bikes.API.Models;

namespace BeSpoked.Bikes.API.Repository
{
    public interface IcustomerRepo
    {
        Task<List<Customer>> GetCustomerAsync();

        Task<Customer> GetCustomerByIDAsync(Guid id);

        Task<Customer> AddCustomerAsync(AddorUpdateCustomerReq customerReq);
    }
}
