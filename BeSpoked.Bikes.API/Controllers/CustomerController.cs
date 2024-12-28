using AutoMapper;
using BeSpoked.Bikes.API.Models.Dto;
using BeSpoked.Bikes.API.Models;
using BeSpoked.Bikes.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeSpoked.Bikes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IcustomerRepo customerRepo;
        private readonly IMapper mapper;

        public CustomerController( IcustomerRepo customerRepo , IMapper mapper)
        {
            this.customerRepo = customerRepo;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomer()
        {

            var CustomerList = await customerRepo.GetCustomerAsync();
            return Ok(CustomerList);
        }

        [Route("AddCustomer")]
        [HttpPost]
        public async Task<IActionResult> AddSalePersonAsync([FromBody] AddorUpdateCustomerReq CustomerReq)
        {
            try
            {
               

                var salePersonDetaildto = await customerRepo.AddCustomerAsync(CustomerReq);

                // convert dto into model back
                var salePerson = mapper.Map<Customer>(CustomerReq);


                return Ok(salePerson);
            }

            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while adding the sale person.", detail = ex.Message });
            }


        }


    }
}
