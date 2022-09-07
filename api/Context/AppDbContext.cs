//importamos EntityFrameworkCore desde nuget
using Microsoft.EntityFrameworkCore;

//importamos la carpeta Models
using WebApp.Models;

namespace WebApp.Context

    
{
    //heredamos  DbContext
    public class AppDbContext:DbContext
    {
        
            

        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {

        }
        
        //representamos las tablas  sql
        public DbSet<Cliente> cliente { get; set; }

        public DbSet<Pedido> pedido { get; set; }
        
        public DbSet<Producto> produto { get; set; }

        public DbSet<Proveedor> proveedor { get; set; }

        public DbSet<Detalle_venta>detalle_Venta { get; set; } 



    }
}
