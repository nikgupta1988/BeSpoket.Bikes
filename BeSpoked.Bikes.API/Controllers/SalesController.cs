using AutoMapper;
using BeSpoked.Bikes.API.Data;
using BeSpoked.Bikes.API.Models.Dto;
using BeSpoked.Bikes.API.Models;
using BeSpoked.Bikes.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeSpoked.Bikes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly IsaleRepo saleRepo;
        private readonly IMapper mapper;

        public SalesController(IsaleRepo saleRepo, IMapper mapper)
        {
            this.saleRepo = saleRepo;
            this.mapper = mapper;
        }

        [Route("Createsale")]
        [HttpPost]
        public async Task<IActionResult> CreatesaleAsync([FromBody] CreateSellRequest saleReq)
        {
            try
            {
                var salerequest = mapper.Map<Sales>(saleReq);

                var salePersonDetaildto = await saleRepo.CreateSellAsync(salerequest);

                // convert dto into model back
                var saleDetail = mapper.Map<Sales>(salePersonDetaildto);
                return Ok(saleDetail);
            }

            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while adding the sale person.", detail = ex.Message });
            }


        }
    }
}
