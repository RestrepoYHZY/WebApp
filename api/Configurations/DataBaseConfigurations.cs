//administrar paquetes nuget e instalamos Entity
using Microsoft.EntityFrameworkCore;
using WebApp.Context;

namespace WebApp.Configurations
{
    //configurando conexion con la base de datos 
    public static class DataBaseConfigurations
    {   
        public static IServiceCollection DataBaseConfiguration(this IServiceCollection builder)
        {
            //cadena de conexion 
            builder.AddDbContext<AppDbContext>(
            options => options.UseSqlServer("data source=DUBAN;initial catalog=gestionPedidos; user id=sa; password=123;MultipleActiveResultSets=true")
             );
            return builder;
        }
        
    }
}
