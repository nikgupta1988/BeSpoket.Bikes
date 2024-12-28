using BeSpoked.Bikes.API.Data;
using BeSpoked.Bikes.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeSpoked.Bikes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly BikesDbContext bikesDbContext;

        public ProductController(BikesDbContext bikesDbContext)
        {
            this.bikesDbContext = bikesDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            var productList = bikesDbContext.Products.ToListAsync();
            return Ok(productList);
        }
    }
}
