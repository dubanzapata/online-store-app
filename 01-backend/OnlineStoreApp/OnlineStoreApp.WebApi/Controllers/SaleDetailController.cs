using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineStoreApp.WebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineStoreApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleDetailController : ControllerBase
    {
        private readonly OnlineStoreAppDbContext context;

        public SaleDetailController(OnlineStoreAppDbContext context)
        {
            this.context = context;
        }

    
        // GET: api/<GestorDetalleController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                
                return Ok(context.SaleDetails.ToList());

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/<GestorDetalleController>/5
        [HttpGet("{id}",Name ="getDetail")]
        public ActionResult Get(int id)
        {
            try
            {

                var gestor = context.SaleDetails.FirstOrDefault(x => x.IdDetail == id);
                return Ok(gestor);


            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        // POST api/<GestorDetalleController>
        [HttpPost]
        public ActionResult Post(SaleDetail gestor)
        {
            context.SaleDetails.Add(gestor);    
            context.SaveChanges();
            return CreatedAtRoute("getDetail", new {id=gestor.IdDetail},gestor);

        }

        // PUT api/<GestorDetalleController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id,  SaleDetail gestor)
        {
            try
            {
                if (gestor.IdDetail == id)
                     context.Entry(gestor).State = EntityState.Modified;
                     context.SaveChanges();
                     return CreatedAtRoute("getDetail", new { id = gestor.IdDetail }, gestor);


            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            

        }

        // DELETE api/<GestorDetalleController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                
                var gestor = context.SaleDetails.FirstOrDefault(x => x.IdDetail == id);

                
                if (gestor != null)
                {
                    context.SaleDetails.Remove(gestor);
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
