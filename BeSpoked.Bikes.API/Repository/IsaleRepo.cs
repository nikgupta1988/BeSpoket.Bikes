using BeSpoked.Bikes.API.Models;
using BeSpoked.Bikes.API.Models.Dto;

namespace BeSpoked.Bikes.API.Repository
{
    public interface IsaleRepo
    {
        Task<List<Sales>> GetSellAsync(DateTime ? startDate, DateTime? EmdDate);

        Task<Sales> CreateSellAsync(Sales sellReq);
    }
}
