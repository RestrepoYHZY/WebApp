using Microsoft.AspNetCore.Mvc;
using WebApp.Context;
using WebApp.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleDetailController : ControllerBase
    {
        private readonly AppDbContext context;

        public SaleDetailController(AppDbContext context)
        {
            this.context = context;
        }

    
        // GET: api/<GestorDetalleController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                
                return Ok(context.saleDetail.ToList());

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

                var gestor = context.saleDetail.FirstOrDefault(x => x.idDetail == id);
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
            context.saleDetail.Add(gestor);    
            context.SaveChanges();
            return CreatedAtRoute("getDetail", new {id=gestor.idDetail},gestor);

        }

        // PUT api/<GestorDetalleController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id,  SaleDetail gestor)
        {
            try
            {
                if (gestor.idDetail == id)
                     context.Entry(gestor).State = EntityState.Modified;
                     context.SaveChanges();
                     return CreatedAtRoute("getDetail", new { id = gestor.idDetail }, gestor);


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
                
                var gestor = context.saleDetail.FirstOrDefault(x => x.idDetail == id);

                
                if (gestor != null)
                {
                    context.saleDetail.Remove(gestor);
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
