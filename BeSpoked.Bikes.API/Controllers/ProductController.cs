using BeSpoked.Bikes.API.BAL;
using BeSpoked.Bikes.API.Data;
using BeSpoked.Bikes.API.Models;
using BeSpoked.Bikes.API.Models.Dto;
using BeSpoked.Bikes.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeSpoked.Bikes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductBAL productBAL;
        private readonly IProductRepo productRepo;
        private readonly BikesDbContext bikesDbContext;

        public ProductController(IProductBAL productBAL, IProductRepo productRepo, BikesDbContext bikesDbContext)
        {
            this.productBAL = productBAL;
            this.productRepo = productRepo;
            this.bikesDbContext = bikesDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {

            var productList = await productBAL.GetProductAsync();
            return Ok(productList);
        }
        //[Route("{id:prodname}")]
        //[HttpGet]
        //public async Task<IActionResult> GetProductByName([FromRoute ] string prodname)
        //{

        //    var product = await productBAL.GetProductByNameAsync(prodname);
        //    return Ok(product);
        //}

        [Route("{id:Guid}")]
        [HttpGet]
        public async Task<IActionResult> GetProductByName([FromRoute] Guid id)
        {

            var product = await productBAL.GetProductByIDAsync(id);
            return Ok(product);
        }

        [Route("AddProduct")]
        [HttpPost]
        public async Task<IActionResult> AddProductAsync([FromBody] AddProductReq prodreq)
        {
            try
            {

                var productDetaildto = await productBAL.AddProdcutAsync(prodreq);

                // convert dto into model back
                var productdetail = new Products
                {
                    ProductID = productDetaildto.ProductID,
                    Commission_Percentage = productDetaildto.Commission_Percentage,
                    Manufacturer = productDetaildto.Manufacturer,
                    ProdName = productDetaildto.ProdName,
                    Purchase_Price = productDetaildto.Purchase_Price,
                    Qty_On_Hand = productDetaildto.Qty_On_Hand,
                    Sale_Price = productDetaildto.Sale_Price,
                    Style = productDetaildto.Style
                };
                return Ok(productdetail);
            }

            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while adding the product.", detail = ex.Message });
            }

            
        }
        //Update product
        [Route("{id:Guid}")]
        [HttpPut]
        public async Task<IActionResult> UpdateProductAsync([FromRoute] Guid id, [FromBody] AddProductReq prodreq)
        {

            var updatedprodres = await productBAL.UpdateProdcutAsync(id, prodreq);
            var updatedprod = new Products
            {
                Purchase_Price = updatedprodres.Purchase_Price,
                Sale_Price = updatedprodres.Sale_Price,
                Manufacturer = updatedprodres.Manufacturer,
                ProdName = updatedprodres.ProdName,
                Commission_Percentage = updatedprodres.Commission_Percentage,
                Qty_On_Hand = updatedprodres.Qty_On_Hand,
                Style = updatedprodres.Style,
            };
            return Ok(updatedprod);
        }
    }
}
