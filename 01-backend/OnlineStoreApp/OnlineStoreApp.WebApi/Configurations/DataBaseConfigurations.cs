//EntityFrameworkCore importamos desde nuget
using Microsoft.EntityFrameworkCore;

//importamos la carpeta Context
using OnlineStoreApp.WebApi.Models;

namespace OnlineStoreApp.WebApi.Configurations
{
    //conectamos con la cadena de conexion .json
    public static class DataBaseConfigurations
    {
        //metodo statico
        public static IServiceCollection DataBaseConfiguration(this IServiceCollection builder)
        {
            //optenemos cadena de conexion 
            builder.AddDbContext<OnlineStoreAppDbContext>(
            options => options.UseSqlServer(Environment.GetEnvironmentVariable("CONNECTION_STRING")));


            return builder;
        }

    }
}
