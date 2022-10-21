using Microsoft.AspNetCore.Mvc;
using OlineStore.Contrats.Interfaces.Services;
using OlineStore.Dto.Request;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineStoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        // GET: api/<InvoiceController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var invoice = await _invoiceService.ListInvoice();
            return Ok(invoice);
            
        }

        // GET api/<InvoiceController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var invoice= await _invoiceService.GetInvoice(id);  
            return Ok(invoice);
        }

        // POST api/<InvoiceController>
        [HttpPost]
        public async Task<IActionResult> Post(InvoiceRequest invoiceRequest)
        {
            var invoice = await _invoiceService.AddInvoice(invoiceRequest);
            return Ok(invoice);
        }

        // PUT api/<InvoiceController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(InvoiceRequest invoiceRequest, int id)
        {
            var invoice = await _invoiceService.UpdateInvoice(invoiceRequest, id);
            return Ok(invoice);
        }

        // DELETE api/<InvoiceController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var invoice=await _invoiceService.DeleteInvoice(id);
            return Ok(invoice);
        }
    }
}
