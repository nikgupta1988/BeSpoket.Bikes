using BeSpoked.Bikes.API.Models;
using BeSpoked.Bikes.API.Models.Dto;

namespace BeSpoked.Bikes.API.DAL
{
    public interface IProductDal
    {
         Task<List<Products>> GetProductAsync();

        Task<Products> GetProductByIDAsync(Guid id);
        Task<Products> GetProductByNameAsync(string prodName);
        Task<Products> AddProdcutAsync(AddProductReq productreq);
        Task<Products?> UpdateProdcutAsync( Guid id, AddProductReq productreq);
    }
}
