using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineStoreApp.WebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineStoreApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {

        private readonly OnlineStoreAppDbContext context;

        public ProviderController(OnlineStoreAppDbContext context)
        {
            this.context = context;
        }


    
        // GET: api/<GestoresProveedorController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Providers.ToList());

            }catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/<GestoresProveedorController>/5
        [HttpGet("{id}",Name ="getProvider")]
        public ActionResult Get(int id)
        {
            try
            {

                var gestor=context.Providers.FirstOrDefault(x=>x.IdProvider == id);

                return Ok(gestor);  

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        // POST api/<GestoresProveedorController>
        [HttpPost]
        public ActionResult   Post( Provider gestor)
        {
            try
            {
                context.Add(gestor);
                context.SaveChanges();
                return CreatedAtRoute("getProvider",new { id = gestor.IdProvider },gestor);   



            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<GestoresProveedorController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id,  Provider gestor)
        {
            try
            {
               if(gestor.IdProvider == id)

                context.Entry(gestor).State = EntityState.Modified;
                context.SaveChanges();
                return CreatedAtRoute("getProvider", new { id = gestor.IdProvider },gestor);
                


            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<GestoresProveedorController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var gestor=context.Providers.FirstOrDefault(x => x.IdProvider == id);
                if (gestor != null)
                     context.Providers.Remove(gestor);
                     context.SaveChanges();
                     return Ok(id);


            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
