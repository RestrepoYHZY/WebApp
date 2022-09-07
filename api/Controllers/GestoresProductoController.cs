using Microsoft.AspNetCore.Mvc;
using WebApp.Context;
using WebApp.Models;
using Microsoft.EntityFrameworkCore;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestoresProductoController : ControllerBase
    {
        private readonly AppDbContext context;

        public GestoresProductoController(AppDbContext context)
        {
            this.context = context;


        }


        // GET: api/<GestoresProductoController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {


                return Ok(context.produto.ToList());

            } catch (Exception e)
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

                var gestor = context.produto.FirstOrDefault(x => x.Id == id);

                return Ok(gestor);


            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/<GestoresProductoController>
        [HttpPost]
        public ActionResult Post([FromBody] Producto gestor)
        {
            try
            {
                context.produto.Add(gestor);
                context.SaveChanges();

                return CreatedAtRoute("getProducto",new { id=gestor.Id});

                


            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<GestoresProductoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Producto gestor)
        {
            try
            {

                if(gestor.Id==id)
                context.Entry(gestor).State=EntityState.Modified;
                context.SaveChanges();

                return CreatedAtRoute("getProducto", new { id=gestor.Id},gestor);  
                


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

                var gestor = context.produto.FirstOrDefault(x => x.Id == id);

                if (gestor != null)
                {
                    context.produto.Remove(gestor);
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
