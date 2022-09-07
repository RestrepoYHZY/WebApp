using Microsoft.AspNetCore.Mvc;
using WebApp.Context;
using WebApp.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestoresPedidoController : ControllerBase
    {
        private readonly AppDbContext context;

        public GestoresPedidoController(AppDbContext context)
        {
            this.context = context; 
                
        }
        // GET: api/<GestoresPedidoController>
        [HttpGet]


        public ActionResult<string> Get()
        {
            try
            {
                return Ok(context.pedido.ToList());


            }catch(Exception e)
            {
                return BadRequest(e.Message);   
            }
        }

        // GET api/<GestoresPedidoController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                var gestor=context.pedido.FirstOrDefault(x => x.Id == id);
                return Ok(gestor);

            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/<GestoresPedidoController>
        [HttpPost]
        public ActionResult Post([FromBody] Pedido gestor)
        {
            try
            {
                context.pedido.Add(gestor);
                context.SaveChanges();

                return CreatedAtRoute("getPedido",new { id = gestor.Id });

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<GestoresPedidoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Pedido gestor)
        {
            try
            {

                if (gestor.Id == id)

                context.Entry(gestor).State=EntityState.Modified;
                context.SaveChanges();

                return CreatedAtRoute("getPedido", new { id = gestor.Id }, gestor);


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

                var gestor = context.pedido.FirstOrDefault(x => x.Id == id);

                if (gestor != null)
                {
                    context.pedido.Remove(gestor);
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
