//EntityFrameworkCore importamos desde nuget
using Microsoft.EntityFrameworkCore;

//importamos la carpeta Context
using WebApp.Context;

namespace WebApp.Configurations
{
    //conectamos con la cadena de conexion .json
    public static class DataBaseConfigurations
    {
        //metodo statico
        public static IServiceCollection DataBaseConfiguration(this IServiceCollection builder)
        {
            //optenemos cadena de conexion 
            builder.AddDbContext<AppDbContext>(
            options => options.UseSqlServer(Environment.GetEnvironmentVariable("CONNECTION_STRING")));


            return builder;
        }

    }
}
