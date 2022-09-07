using Microsoft.AspNetCore.Mvc;
using WebApp.Context;
using WebApp.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestorDetalleController : ControllerBase
    {
        private readonly AppDbContext context;

        public GestorDetalleController(AppDbContext context)
        {
            this.context = context;
        }

    
        // GET: api/<GestorDetalleController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                
                return Ok(context.detalle_Venta.ToList());

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/<GestorDetalleController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {

                var gestor = context.detalle_Venta.FirstOrDefault(x => x.Id == id);
                return Ok(gestor);


            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        // POST api/<GestorDetalleController>
        [HttpPost]
        public ActionResult Post([FromBody] Detalle_venta gestor)
        {
            context.detalle_Venta.Add(gestor);    
            context.SaveChanges();
            return CreatedAtRoute("getDetalle", new {id=gestor.Id},gestor);

        }

        // PUT api/<GestorDetalleController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Detalle_venta gestor)
        {
            try
            {
                if (gestor.Id == id)
                     context.Entry(gestor).State = EntityState.Modified;
                     context.SaveChanges();
                     return CreatedAtRoute("getDetalle", new { id = gestor.Id }, gestor);


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
                
                var gestor = context.detalle_Venta.FirstOrDefault(x => x.Id == id);

                
                if (gestor != null)
                {
                    context.detalle_Venta.Remove(gestor);
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
