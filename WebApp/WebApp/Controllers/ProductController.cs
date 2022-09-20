using Microsoft.AspNetCore.Mvc;
using WebApp.Context;
using WebApp.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using WebApp.DTO;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public ProductController(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;


        }


        // GET: api/<GestoresProductoController>
        [HttpGet("getProduct")]
        //public ActionResult Get()
        public async Task<ActionResult<IEnumerable<ProductDto>>> getProduct()
        {
            try
            {
                //return Ok(context.product.ToList());

                var result = await context.product.Include(x=>x.Provider).ToListAsync();
                return await context.product.ProjectTo<ProductDto>(mapper.ConfigurationProvider).ToListAsync();


            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        // GET api/<GestoresProductoController>/5
        [HttpGet("{id}",Name ="getProduct")]
        public ActionResult Get(int id)
        {
            try
            {

                var gestor = context.product.FirstOrDefault(x => x.idProduct == id);

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
                context.product.Add(gestor);
                context.SaveChanges();

                return CreatedAtRoute("getProduct",new { id=gestor.idProduct},gestor);

                


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

                if(gestor.idProduct==id)
                context.Entry(gestor).State=EntityState.Modified;
                context.SaveChanges();

                return CreatedAtRoute("getProduct", new { id=gestor.idProduct},gestor);  
                


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

                var gestor = context.product.FirstOrDefault(x => x.idProduct == id);

                if (gestor != null)
                {
                    context.product.Remove(gestor);
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
