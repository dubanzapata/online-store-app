using Microsoft.AspNetCore.Mvc;
using OlineStore.Contrats.Interfaces.Services;
using OlineStore.Dto.Request;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineStoreApp.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customer = await _customerService.ListCustomer();
            return Ok(customer);
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var customer= await _customerService.GetCustomer(id);
            return Ok(customer);
            
        }

        // POST api/<CustomerController>
        [HttpPost]
        public async Task<IActionResult> Post(CustomerRequest customerRequest )
        {
            var customer= await _customerService.AddCustomer(customerRequest);
            return Ok(customer);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(CustomerRequest customerRequest,int id)
        {
            var customer=await _customerService.UpdateCustomer(customerRequest,id);
            return Ok(customer);
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var customer= await _customerService.DeleteCustomer(id);
            return Ok(customer);
        }
    }
}
