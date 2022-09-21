using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineStoreApp.WebApi.DTO;
using OnlineStoreApp.WebApi.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineStoreApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly OnlineStoreAppDbContext context;
        private readonly IMapper mapper;

        public ProductController(OnlineStoreAppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;


        }


        // GET: api/<GestoresProductoController>
        [HttpGet]
        //public ActionResult Get()
        public async Task<ActionResult<IEnumerable<ProductDto>>> getProduct()
        {
            try
            {
                //return Ok(context.product.ToList());

                var result = await context.Products.Include(x=>x.IdProviderNavigation).ToListAsync();
                return await context.Products.ProjectTo<ProductDto>(mapper.ConfigurationProvider).ToListAsync();


            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        // GET api/<GestoresProductoController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {

                var gestor = context.Products.FirstOrDefault(x => x.IdProduct == id);

                return Ok(gestor);


            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/<GestoresProductoController>
        [HttpPost]
        public ActionResult Post( Product gestor)
        {
            try
            {
                context.Products.Add(gestor);
                context.SaveChanges();

                return CreatedAtRoute("Product",new { id=gestor.IdProduct},gestor);

                


            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<GestoresProductoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id,  Product gestor)
        {
            try
            {

                if(gestor.IdProduct==id)
                context.Entry(gestor).State=EntityState.Modified;
                context.SaveChanges();

                return CreatedAtRoute("getProduct", new { id=gestor.IdProduct},gestor);  
                


            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<GestoresProductoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {

                var gestor = context.Products.FirstOrDefault(x => x.IdProduct == id);

                if (gestor != null)
                {
                    context.Products.Remove(gestor);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();

                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
