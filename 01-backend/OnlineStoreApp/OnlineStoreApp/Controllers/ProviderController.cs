using Microsoft.AspNetCore.Mvc;
using OlineStore.Contrats.Interfaces.Services;
using OlineStore.Dto.Request;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineStoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private readonly IProviderService _providerService;

        public ProviderController(IProviderService providerService)
        {
            _providerService = providerService;
        }


        // GET: api/<ProviderController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var provider = await _providerService.ListProvider();
            return Ok(provider);
        }

        // GET api/<ProviderController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var provider = await _providerService.GetProvider(id);
            return Ok(provider);
        }

        // POST api/<ProviderController>
        [HttpPost]
        public async Task<IActionResult> Post(ProviderRequest providerRequest)
        {
            var provider = await _providerService.AddProvider(providerRequest);
            return Ok(provider);
        }

        // PUT api/<ProviderController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(ProviderRequest productRequest, int id)
        {
            var provider = await _providerService.UpdateProvider(productRequest,id);
            return Ok(provider);
        }

        // DELETE api/<ProviderController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult>  Delete(int id)
        {
            var provider = await _providerService.DeleteProvider(id);
            return Ok(provider);
        }
    }
}
