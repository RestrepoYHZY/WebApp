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
        public DbSet<Customer> customer { get; set; }

        public DbSet<Sale> sale { get; set; }
        
        public DbSet<Product> product { get; set; }

        public DbSet<Provider> provider { get; set; }

        public DbSet<SaleDetail> saleDetail { get; set; } 



    }
}
