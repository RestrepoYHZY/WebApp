using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Context

    
{
    public class AppDbContext:DbContext
    {
        
        //llamar el modelo

        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {

        }
        //importamos la clase Cliente de la carpeta Models 
        //representacion la tabla cliente sql
        //get para consultar  set para modificar 
        public DbSet<Cliente> cliente { get; set; }

    }
}
