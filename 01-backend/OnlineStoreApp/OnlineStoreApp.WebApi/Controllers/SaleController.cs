using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineStoreApp.WebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineStoreApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly OnlineStoreAppDbContext context;

        public SaleController(OnlineStoreAppDbContext context)
        {
            this.context = context; 
                
        }
        // GET: api/<GestoresPedidoController>
        [HttpGet]


        public ActionResult  Get()
        {
            try
            {
                return Ok(context.Sales.ToList());


            }catch(Exception e)
            {
                return BadRequest(e.Message);   
            }
        }

        // GET api/<GestoresPedidoController>/5
        [HttpGet("{id}",Name ="getSale")]
        public ActionResult Get(int id)
        {
            try
            {
                var gestor=context.Sales.FirstOrDefault(x => x.IdSale == id);
                return Ok(gestor);

            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/<GestoresPedidoController>
        [HttpPost]
        public ActionResult Post( Sale gestor)
        {
            try
            {
                context.Sales.Add(gestor);
                context.SaveChanges();

                return CreatedAtRoute("getSale",new { id = gestor.IdSale },gestor);

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<GestoresPedidoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id,  Sale gestor)
        {
            try
            {

                if (gestor.IdSale == id)

                context.Entry(gestor).State=EntityState.Modified;
                context.SaveChanges();

                return CreatedAtRoute("getSale", new { id = gestor.IdSale }, gestor);


            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<GestoresPedidoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {

                var gestor = context.Sales.FirstOrDefault(x => x.IdSale == id);

                if (gestor != null)
                {
                    context.Sales.Remove(gestor);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }


            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
