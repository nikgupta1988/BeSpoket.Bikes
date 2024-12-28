using BeSpoked.Bikes.API.Models;
using BeSpoked.Bikes.API.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BeSpoked.Bikes.API.Repository
{
    public interface IProductRepo
    {
         Task<List<Products>> GetProductAsync();

        Task<Products> GetProductByNameAsync(string prodName);
        Task<Products> GetProductByIDAsync(Guid id);

        Task<Products> AddProdcutAsync(AddProductReq productreq);

        Task<Products?> UpdateProdcutAsync(Guid id, AddProductReq productreq);

        Task<bool> IsProductDuplicateAsync(AddProductReq product);

    }
}
