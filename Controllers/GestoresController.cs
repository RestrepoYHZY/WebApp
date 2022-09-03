using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Context;
using WebApp.Models;

//Peticiones get post
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestoresController : ControllerBase
        
    {
        //importamos AppContext
        private readonly AppDbContext context;

        public GestoresController(AppDbContext context)
        {
            this.context = context;
        }


        // GET: api/<GestoresController>
        [HttpGet]

        //peticion get 
        public ActionResult<string> Get()
        {
            //manejo de errores 
            try
            {
                //optenemos toda la informacion de la tabla cliente sql
                return Ok(context.cliente.ToList());

            }catch(Exception e)
            {
                //retornamos respuesta erronea
                return BadRequest(e.Message);  
            }
           
        }

        // GET api/<GestoresController>/5
        [HttpGet("{id}",Name ="getCliente")]

        //retorna un solo registro de  la tabla cliente sql
        public ActionResult Get(int id)
        {

            try
            {
                //uso del LINQ
                //busca dentro de los  registros la  coicidencia del  id que nos manda el usuario
                
                var gestor=context.cliente.FirstOrDefault(x => x.Id == id); 

                //retorna el id
                return Ok(gestor);  

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/<GestoresController>
        [HttpPost]

        //le pasamos por parametro la clase Cliente de la carpeta Model al metodo post
        public ActionResult Post([FromBody] Cliente gestor)
        {
            try
            {
                //insertamos el registro dentro de la base da datos 
                context.cliente.Add(gestor);
                context.SaveChanges();
                //retornamos al usuario lo que se inserto y el id autoincrementable 
                return CreatedAtRoute("getCliente", new { id = gestor.Id }, gestor);

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<GestoresController>/5
        [HttpPut("{id}")]
        
       
        public ActionResult Put(int id, [FromBody] Cliente gestor)
        {
            try
            {
                //buscamos por id el registro que queremos modificar 

                if (gestor.Id==id)
                //modificamos los cambios 
                context.Entry(gestor).State = EntityState.Modified;
                //guardamos los cambios 
                context.SaveChanges();
                //retornamos al cliente 
                return CreatedAtRoute("getCliente", new { id = gestor.Id }, gestor);

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
                var gestor = context.cliente.FirstOrDefault(x => x.Id==id);

                //en caso de que exista 
                if (gestor != null)
                {
                    context.cliente.Remove(gestor); 
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
