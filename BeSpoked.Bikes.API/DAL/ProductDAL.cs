using BeSpoked.Bikes.API.Models;
using BeSpoked.Bikes.API.Models.Dto;
using BeSpoked.Bikes.API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BeSpoked.Bikes.API.DAL
{
    public class ProductDAL : IProductDal
    {
        private readonly IProductDal productDal;
        private readonly IProductRepo productRepo;

        public ProductDAL(IProductRepo productRepo)
        {
            this.productRepo = productRepo;
        }

        public async Task<Products> AddProdcutAsync(AddProductReq productreq)
        {
            if (await productRepo.IsProductDuplicateAsync(productreq))
            {
                throw new InvalidOperationException("Product Already exist");
            }
            return await productRepo.AddProdcutAsync(productreq);
        }


        public async Task<List<Products>> GetProductAsync()
        {
            return await productRepo.GetProductAsync();
        }

        public async Task<Products> GetProductByIDAsync(Guid id)
        {
            return await productRepo.GetProductByIDAsync(id);
        }

        public async Task<Products> GetProductByNameAsync(string prodName)
        {
            return await productRepo.GetProductByNameAsync(prodName);
        }

        public async Task<Products?> UpdateProdcutAsync( Guid id, AddProductReq productreq)
        {

            return await productRepo.UpdateProdcutAsync(id, productreq);
        }
    }
}
