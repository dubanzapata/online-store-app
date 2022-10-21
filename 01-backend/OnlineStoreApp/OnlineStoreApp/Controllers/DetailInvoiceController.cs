using Microsoft.AspNetCore.Mvc;
using OlineStore.Contrats.Interfaces.Services;
using OlineStore.Dto.Request;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineStoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailInvoiceController : ControllerBase
    {
        private readonly IDetailInvoiceService _detailInvoiceService;

        public DetailInvoiceController(IDetailInvoiceService detailInvoiceService)
        {
            _detailInvoiceService = detailInvoiceService;
        }


        // GET: api/<DetailInvoiceController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var detail = await _detailInvoiceService.ListDetail();
            return Ok(detail);
        }

        // GET api/<DetailInvoiceController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var detail= await _detailInvoiceService.GetDetail(id);
            return Ok(detail);
        }

        // POST api/<DetailInvoiceController>
        [HttpPost]
        public async Task<IActionResult> Post(DetailInvoiceRequest detailInvoiceRequest )
        {
            var detail =await _detailInvoiceService.AddDetail(detailInvoiceRequest);
            return Ok(detail);
        }

        // PUT api/<DetailInvoiceController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(DetailInvoiceRequest detailInvoiceRequest,int id)
        {
            var detail = await _detailInvoiceService.UpdateDetail(detailInvoiceRequest, id);
            return Ok(detail);
        }

        // DELETE api/<DetailInvoiceController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var detail= await _detailInvoiceService.DeleteDetail(id);
            return Ok(detail);
        }
    }
}
