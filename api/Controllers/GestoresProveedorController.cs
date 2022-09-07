using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Context;
using WebApp.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestoresProveedorController : ControllerBase
    {

        private readonly AppDbContext context;

        public GestoresProveedorController(AppDbContext context)
        {
            this.context = context;
        }


    
        // GET: api/<GestoresProveedorController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.proveedor.ToList());

            }catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/<GestoresProveedorController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {

                var gestor=context.proveedor.FirstOrDefault(x=>x.Id == id);

                return Ok(gestor);  

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        // POST api/<GestoresProveedorController>
        [HttpPost]
        public ActionResult   Post([FromBody] Proveedor gestor)
        {
            try
            {
                context.Add(gestor);
                context.SaveChanges();
                return CreatedAtRoute("getProveedro",new { id = gestor.Id },gestor);   



            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<GestoresProveedorController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Proveedor gestor)
        {
            try
            {
               if(gestor.Id == id)

                context.Entry(gestor).State = EntityState.Modified;
                context.SaveChanges();
                return CreatedAtRoute("getProveedor", new { id = gestor.Id },gestor);
                


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
                var gestor=context.proveedor.FirstOrDefault(x => x.Id == id);
                if (gestor != null)
                     context.Remove(gestor);
                     context.SaveChanges();
                     return Ok(id);


            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
