using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineStoreApp.WebApi.Models;

//Peticiones get post
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineStoreApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
        
    {
        //declaramos context de tipo AppDbContext 
        private readonly OnlineStoreAppDbContext context;


        //constructor 
        public CustomerController(OnlineStoreAppDbContext context)
        {
            this.context = context;
        }


        // GET: api/<GestoresController>
        [HttpGet]

        //peticion get 
        //optenemos toda la informacion de la tabla cliente sql
        public ActionResult Get()
        {
            //manejo de errores 
            try
            {                
                return Ok(context.Customers.ToList());

            }catch(Exception e)
            {
                //retornamos respuesta erronea
                return BadRequest(e.Message);  
            }
           
        }

        // GET api/<GestoresController>/5
        [HttpGet("{id}",Name ="getCustomer")]

        //retorna un solo registro de  la tabla cliente sql
        public ActionResult Get(int id)
        {

            try
            {
                //uso del LINQ
                //acemos coincidir el ID que nos manda el usuario con los registros de la tabla cliente sql
                
                var gestor=context.Customers.FirstOrDefault(x => x.IdCustomer == id); 

                //retorna el ID
                return Ok(gestor);  

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/<GestoresController>
        [HttpPost]

        //le pasamos por parametro la clase Cliente de la carpeta Model al metodo post
        public ActionResult Post(Customer gestor)
        {
            try
            {
                //insertamos el registro dentro dentro de la tabla cliente sql
                context.Customers.Add(gestor);

                //guarda los cambios 
                context.SaveChanges();

                //retornamos al usuario lo que se inserto y el ID autoincrementable 
                return CreatedAtRoute("getCustomer", new { id = gestor.IdCustomer }, gestor);

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<GestoresController>/5
        [HttpPut("{id}")]
     
       
        public ActionResult Put(int id, Customer gestor)
        {
            try
            {
                //si la condicion es cierta retornamos los cambios 

                if (gestor.IdCustomer==id)

                //modificamos los cambios 
                context.Entry(gestor).State = EntityState.Modified;

                //guardamos los cambios 
                context.SaveChanges();

                //retornamos al cliente los cambios  
                return CreatedAtRoute("getCustomer", new { id = gestor.IdCustomer}, gestor);

            }
            catch (Exception e)
            {
                //respuesta erronea 
                return BadRequest(e.Message);
            }

        }

        // DELETE api/<GestoresController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                //buscamos que el registro exista  
                var gestor = context.Customers.FirstOrDefault(x => x.IdCustomer==id);

                //en caso de que exista
                if (gestor != null)
                {
                    context.Customers.Remove(gestor); 
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
