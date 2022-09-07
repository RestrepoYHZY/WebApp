﻿using Microsoft.AspNetCore.Mvc;
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
        //declaramos context de tipo AppDbContext 
        private readonly AppDbContext context;


        //constructor 
        public GestoresController(AppDbContext context)
        {
            this.context = context;
        }


        // GET: api/<GestoresController>
        [HttpGet]

        //peticion get 
        //optenemos toda la informacion de la tabla cliente sql
        public ActionResult<string> Get()
        {
            //manejo de errores 
            try
            {
                
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
                //acemos coincidir el ID que nos manda el usuario con los registros de la tabla cliente sql
                
                var gestor=context.cliente.FirstOrDefault(x => x.Id == id); 

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
        public ActionResult Post([FromBody] Cliente gestor)
        {
            try
            {
                //insertamos el registro dentro dentro de la tabla cliente sql
                context.cliente.Add(gestor);

                //guarda los cambios 
                context.SaveChanges();

                //retornamos al usuario lo que se inserto y el ID autoincrementable 
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
                //si la condicion es cierta retornamos los cambios 

                if (gestor.Id==id)

                //modificamos los cambios 
                context.Entry(gestor).State = EntityState.Modified;

                //guardamos los cambios 
                context.SaveChanges();

                //retornamos al cliente los cambios  
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
