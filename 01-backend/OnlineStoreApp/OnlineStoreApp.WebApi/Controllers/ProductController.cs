﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineStoreApp.WebApi.DTOs;
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

                var result = await context.Product.Include(x => x.IdProviderNavigation).ProjectTo<ProductDto>(mapper.ConfigurationProvider).ToListAsync();
                return result;


            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        // GET api/<GestoresProductoController>/5
        [HttpGet("{id}")]
        //public ActionResult Get(int id)
        public ActionResult get(int id)
        {
            try
            {


                var gestor = context.Product.FirstOrDefault(x => x.IdProduct == id);



                return Ok(gestor);


            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/<GestoresProductoController>
        [HttpPost("PostRequest")]

        public async Task<ActionResult<ProductRequestDto>> PostRequest(ProductRequestDto gestor)

        {
            try
            {

                var existProduct = await context.Product.AnyAsync(x => x.ProductName == gestor.ProductName);
                if (existProduct)
                {
                    return BadRequest($"Ya existe un producto con el nombre {gestor.ProductName}");
                }

                var product = mapper.Map<Product>(gestor);

                context.Add(product);
                await context.SaveChangesAsync();

                var productDTO = mapper.Map<Product>(product);
                return Ok(productDTO);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);

            }



        }

        // PUT api/<GestoresProductoController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductRequestDto>> PutRequest(int id, ProductRequestDto gestor)
        {
            try
            {

                var existProduct = await context.Product.AnyAsync(x => x.IdProduct == id);
                if (!existProduct)
                {
                    return NotFound();
                }

                var product = mapper.Map<Product>(gestor);
                product.IdProduct = id;

                context.Update(product);
                await context.SaveChangesAsync();
                return NoContent();



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

                var gestor = context.Product.FirstOrDefault(x => x.IdProduct == id);

                if (gestor != null)
                {
                    context.Product.Remove(gestor);
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

    internal record NewRecord(int Id);
}
