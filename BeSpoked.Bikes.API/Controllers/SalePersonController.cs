using BeSpoked.Bikes.API.BAL;
using BeSpoked.Bikes.API.Models.Dto;
using BeSpoked.Bikes.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BeSpoked.Bikes.API.Repository;
using AutoMapper;

namespace BeSpoked.Bikes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalePersonController : ControllerBase
    {
        private readonly ISalesPersonRepo salesPersonRepo;
        private readonly IMapper mapper;

        public SalePersonController(ISalesPersonRepo salesPersonRepo , IMapper mapper )
        {
            this.salesPersonRepo = salesPersonRepo;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSalePerson()
        {

            var salePersonList = await salesPersonRepo.GetsalePersonAsync();
            return Ok(salePersonList);
        }

        [Route("AddsalePerson")]
        [HttpPost]
        public async Task<IActionResult> AddSalePersonAsync([FromBody] AddorUpdateSalePerson salePersonReq)
        {
            try
            {
               //Check for duplicate sale person
               if(await salesPersonRepo.IssalePersonDuplicateAsync(salePersonReq))
                {
                    throw new InvalidOperationException("Sale person Already exist");
                }

                var salePersonDetaildto = await salesPersonRepo.AddsalePersonAsync(salePersonReq);
                
                // convert dto into model back
                var salePerson = mapper.Map<SalesPerson>(salePersonDetaildto);

                
                return Ok(salePerson);
            }

            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while adding the sale person.", detail = ex.Message });
            }


        }

        [Route("{id:Guid}")]
        [HttpPut]
        public async Task<IActionResult> UpdateSalePerson([FromRoute] Guid id, [FromBody] AddorUpdateSalePerson salePersonReq)
        {
            try
            {

                var updateSalePerson = await salesPersonRepo.UpdatesalePersonAsync( id, salePersonReq);

                // convert dto into model back
                var salePerson = mapper.Map<SalesPerson>(salePersonReq);


                return Ok(salePerson);
            }

            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while adding the product.", detail = ex.Message });
            }


        }
    }
}
