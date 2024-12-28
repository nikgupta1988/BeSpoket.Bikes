using BeSpoked.Bikes.API.DAL;
using BeSpoked.Bikes.API.Models;
using BeSpoked.Bikes.API.Models.Dto;

namespace BeSpoked.Bikes.API.BAL
{
    public class ProductBAL : IProductBAL
    {
        private readonly ProductDAL productDAL;
        private readonly IProductDal productDal;

        public ProductBAL(IProductDal productDal )
        {
            this.productDal = productDal;
        }

        public async Task<Products> AddProdcutAsync(AddProductReq productreq)
        {
            return await productDal.AddProdcutAsync(productreq);
        }

        public async Task<List<Products>> GetProductAsync()
        {
           return await productDal.GetProductAsync();
        }

        public async Task<Products> GetProductByIDAsync(Guid id)
        {
            return await productDal.GetProductByIDAsync(id);
        }

        public async Task<Products> GetProductByNameAsync(string prodName)
        {
            return await productDal.GetProductByNameAsync(prodName);
        }

        public async Task<Products?> UpdateProdcutAsync(Guid id, AddProductReq productreq)
        {
            return await productDal.UpdateProdcutAsync(id, productreq);
        }
    }
}
