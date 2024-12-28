using BeSpoked.Bikes.API.Data;
using BeSpoked.Bikes.API.Models;
using BeSpoked.Bikes.API.Models;
using BeSpoked.Bikes.API.Models.Dto;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BeSpoked.Bikes.API.Repository
{
    public class SqlProductRepo : IProductRepo
    {
        private readonly BikesDbContext bikesDbContext;

        public SqlProductRepo(BikesDbContext bikesDbContext)
        {
            this.bikesDbContext = bikesDbContext;
        }
        public async Task<List<Products>> GetProductAsync()
        {

            var result = await bikesDbContext.Products.ToListAsync();
            return result;
        }

       

        public async Task<Products> AddProdcutAsync(AddProductReq addproductreq)
        {

            var product = new Products
            {
                ProdName = addproductreq.ProdName,
                Manufacturer = addproductreq.Manufacturer,
                Purchase_Price = addproductreq.Purchase_Price,
                Commission_Percentage = addproductreq.Commission_Percentage,
                Qty_On_Hand = addproductreq.Qty_On_Hand,
                Sale_Price = addproductreq.Sale_Price,
                Style = addproductreq.Style
            };

            await bikesDbContext.Products.AddAsync(product);
            await bikesDbContext.SaveChangesAsync();
            return product;

        }

        public async Task<bool> IsProductDuplicateAsync(AddProductReq product)
        {
            return await bikesDbContext.Products.AnyAsync(p => p.ProdName.ToUpper() == product.ProdName.ToUpper());
        }

        public async Task<Products> GetProductByNameAsync(string prodName)
        {
            return await bikesDbContext.Products.FirstOrDefaultAsync(p=>p.ProdName.ToUpper()==prodName.ToUpper());
        }

        public async Task<Products> GetProductByIDAsync(Guid id)
        {
            return await bikesDbContext.Products.FirstAsync(p=>p.ProductID==id);
        }

        public async Task<Products?> UpdateProdcutAsync(Guid id, AddProductReq productreq)
        {
            // check if prodcut available 
            var productexist = await bikesDbContext.Products.FirstOrDefaultAsync(p => p.ProductID == id);
            if (productexist == null)
            {
                return null;
            }
            productexist.Purchase_Price = productreq.Purchase_Price;
            productexist.Sale_Price = productreq.Sale_Price;
            productexist.Manufacturer = productreq.Manufacturer;
            productexist.ProdName = productreq.ProdName;
            productexist.Commission_Percentage = productreq.Commission_Percentage;
            productexist.Qty_On_Hand = productreq.Qty_On_Hand;
            productexist.Style = productreq.Style;
            await bikesDbContext.SaveChangesAsync();
            return productexist;


        }
    }
}
